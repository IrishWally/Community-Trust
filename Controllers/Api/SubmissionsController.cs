using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Community_Trust.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Community_Trust.DTOs;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Community_Trust.Controllers.Api
{
    public class SubmissionsController : ApiController
    {
        public List<string> aspNetUsersIdsVoted = new List<string>();

        private ApplicationDbContext _context;

        public SubmissionsController()
        {
            _context = new ApplicationDbContext();
        }
        //Api Contoller
        //GET /api/submissions
        // change the return type to the Submission Data Transfer Object
        public IEnumerable<SubmissionDTO> GetSubmissions()
        {
            //using Automapper to retrieve and map the DTOs
            return _context.Submissions.ToList().Select(AutoMapper.Mapper.Map<Submission,SubmissionDTO>);


        }

        // GET /api.submissions/1
        //RESTFUL convention to use IHttpAction Result
        public IHttpActionResult GetSubmission(int id)
        {
            var submission = _context.Submissions.SingleOrDefault(c => c.subKey == id);
           if(submission == null)
            {
                //NotFOund implements IHttpActionResult
                return NotFound();
            }
            else
            {
                //'Ok' method wraps the AutoMapper 
                return Ok(AutoMapper.Mapper.Map<Submission, SubmissionDTO>(submission));
            }
        }

        //POST /api/submssions
        //instead of returning SubmissionDTO, return IHttpActionResult as its the correct return code for creating an object with the API
        [Authorize(Roles =RoleName.CanManageSubmissions)]
        [HttpPost]
        public IHttpActionResult CreateSubmission (SubmissionDTO subDTO)
        {

            Submission sub = new Submission();
            if (!ModelState.IsValid)
                return BadRequest(); // the Bad Request method returns a bad request result which is a class that implements IhttActionResult

           
            try
                {
                var subnew = AutoMapper.Mapper.Map<SubmissionDTO, Submission>(subDTO);
                    _context.Submissions.Add(subnew);
                    Console.WriteLine(subDTO.ToString());
                    _context.SaveChanges();
                subDTO.subKey = sub.subKey;
                    
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }
           
                Console.WriteLine("Finish Statement");
            //RESTFUL convention means we must return the Uri (Unified Resource Identier ) example   /api/submissions/10
            return Created(new Uri(Request.RequestUri + "/" + sub.subKey),subDTO);
            
            

        }

        // PUT  /api/submissions/1
        //id comes from the url,   the submission comes from the request body
        [Authorize(Roles = RoleName.CanManageSubmissions)]
        [ActionName("adminUpdateCause")]
        [HttpPut]
        public void UpdateSubmission (int id, SubmissionDTO subDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
           
                var subinDB = _context.Submissions.SingleOrDefault(c => c.subKey == id);
               // subDTO.internalVotes = subDTO.internalVotes + 1;

            if(subinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

          
            AutoMapper.Mapper.Map(subDTO,subinDB);


            //set all the properties of the submission object to be saved
            /*subinDB.submitterLocation = subDTO.submitterLocation;
            subinDB.nameOfCause = subDTO.nameOfCause;
            subinDB.currentStatus = subDTO.currentStatus;
            subinDB.organisationType = subDTO.organisationType;
            subinDB.descriptionOfCause = subDTO.descriptionOfCause;
            subinDB.grantCategory = subDTO.grantCategory;
            subinDB.pitch = subDTO.pitch;
            subinDB.vidLink = subDTO.vidLink;
            subinDB.facebookUrl = subDTO.facebookUrl;
            subinDB.twittUrl = subDTO.twittUrl;
            subinDB.submitterLocation = subDTO.submitterLocation;
            subinDB.useOfFunds = subDTO.useOfFunds;
            subinDB.yearAndQuarter = subDTO.yearAndQuarter;
            subinDB.winner = subDTO.winner;
            subinDB.paid = subDTO.paid;
            subinDB.externalVotes = subDTO.externalVotes;
            subinDB.internalVotes = subDTO.internalVotes;
            subinDB.region = subDTO.region;
            subinDB.notes = subDTO.notes;
            subinDB.causeWebsite = subDTO.causeWebsite;
            subinDB.termsAndConds = subDTO.termsAndConds;*/

          _context.SaveChanges();
          

       }

        // DELETE /api/submissions/1
        [Authorize(Roles = RoleName.CanManageSubmissions)]
        [HttpDelete]
        public void DeleteSubmission(int id)
        {
            var subinDB = _context.Submissions.SingleOrDefault(c => c.subKey == id);
            if (subinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Submissions.Remove(subinDB);
            _context.SaveChanges();

        }

        
        //   /api/submission/1
        [ActionName("voteRoute")]
        [HttpPut]
        public void VoteOnSubmission(int id , SubmissionDTO subDTO)
        {
            if (!ModelState.IsValid)
            throw new HttpResponseException(HttpStatusCode.BadRequest);

            var subinDB = _context.Submissions.SingleOrDefault(s => s.subKey == id);
            if (subinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var tempvotes = subinDB.internalVotes;
            var userId = User.Identity.GetUserId();
            if (userId == null)
                throw new HttpResponseException(HttpStatusCode.NoContent);

            var stringListOfSubs = subinDB.StringListOfSubsVotedFor + userId + ',';
            //add 1 vote to this submission
            subinDB.internalVotes = tempvotes+1;


            subinDB.StringListOfSubsVotedFor = stringListOfSubs;
            //map the object back to Submission object to put it in the DB
            AutoMapper.Mapper.Map(subDTO, subinDB);

            // aspNetUsersIdsVoted.Add(user);
            
            //subinDB.aspNetUsersIdsVoted(user);
            _context.SaveChanges();
        }

     

    }
}
