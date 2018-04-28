using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Community_Trust.Models;
using Community_Trust.ViewModels;
using System.Data.Entity;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Web.Http;
using System.Net;

namespace Community_Trust.Controllers
{
    // authorization to protect against anonymous access for all the actions in the crontoller
   // [Authorize]
    public class SubmissionController : Controller
    {

        private ApplicationDbContext _context;

        public SubmissionController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        // GET: Submission/Index\//optional parameters to sort submissions
        // int? makes it a nullable integer
        // [Route("submission")]
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            
            if (pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "grantCategory";
            }
            var sub = new Submission() { nameOfCause = "Homeless"};

            //return Content(String.Format("pageIndex={0}%sortBy={1}", pageIndex, sortBy));   
            //can override parameters by : localhost:submission?pageIndex=2&sortBy=submittedBy
            return View(sub);

           
        }

        
        public ActionResult NewCause()
        {

        
            return View();
        }

        // submit button, can only be called by HttpPost, not get
        [System.Web.Http.HttpPost]
        public ActionResult Save(Submission sub)
        {
            //controller method for new customers and updating current customer
            //if submission id is 0 then its a new customer so save it,  if it is not 0 then its a current customer so update and save
            if (sub.subKey == 0)
            {
                //default actionbs before submitting
                sub.paid = false; sub.winner = false; sub.externalVotes = 0; sub.internalVotes = 0;
                //first statement adds the submission to memory, the second line persists the changes you make by generating SQL at runtime and making the changes
                _context.Submissions.Add(sub);

                try
                {
                    if (ModelState.IsValid)
                    {
                        _context.SaveChanges();
                        ViewData["Success"] = "New Cause Submitted Successfully, Thanks";
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ViewData["Fail"] = "Submission Failed";
                        
                        return  View("NewCause", sub);
                    }

                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Console.WriteLine(dbEx);
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }

                
                //if model state is in valid
                
            }
            else{
                //get the submission from the database, update and then save current customer
                var subinDB = _context.Submissions.Single(c => c.subKey == sub.subKey);
                //Mapper.Map(sub, subinDB);
                //set all the properties of the submission object to be saved
                subinDB.submitterLocation = sub.submitterLocation;
                subinDB.nameOfCause = sub.nameOfCause;
                subinDB.currentStatus = sub.currentStatus;
                subinDB.organisationType = sub.organisationType;
                subinDB.descriptionOfCause = sub.descriptionOfCause;
                subinDB.grantCategory = sub.grantCategory;
                subinDB.pitch = sub.pitch;
                subinDB.vidLink = sub.vidLink;
                subinDB.facebookUrl = sub.facebookUrl;
                subinDB.twittUrl = sub.twittUrl;
                subinDB.submitterLocation = sub.submitterLocation;
                subinDB.useOfFunds = sub.useOfFunds;
                subinDB.yearAndQuarter = sub.yearAndQuarter;
                subinDB.winner = sub.winner;
                subinDB.paid = sub.paid;
                subinDB.externalVotes = sub.externalVotes;
                subinDB.internalVotes = sub.internalVotes;
                subinDB.region = sub.region;
                subinDB.notes = sub.notes;
                subinDB.causeWebsite = sub.causeWebsite;
                subinDB.termsAndConds = sub.termsAndConds;
                try
                {
                    _context.SaveChanges();
                    
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
                ViewData["Success"] = "Submission updated successfully, Thanks";
                return RedirectToAction("ShowAllSubmissions", "Submission");

            }
        }


        
        public ActionResult ShowAllSubmissions()
        {
            
            var submissions = _context.Submissions.ToList();
            foreach (var i in submissions)
            {
                string listOfUserVotedFor = i.StringListOfSubsVotedFor;
                if(listOfUserVotedFor == null)
                {
                    listOfUserVotedFor = "";
                }
                List<String> ListOfUsersVotedFor = listOfUserVotedFor.Split(',').ToList<string>();
                var userId = User.Identity.GetUserId();
                if (userId == null)
                    throw new HttpResponseException(HttpStatusCode.NoContent);
                if (ListOfUsersVotedFor.Contains(userId))
                {
                    i.hasVotedFor = true;
                }
            }
            
            if (User.IsInRole("CanManageSubmissions"))
                return View("ShowAllSubmissions",submissions);

            
            return View("ReadOnlyAllSubmissions", submissions);
        }

        //to view each submission in detail-
        public ActionResult Details(int id)
        {
            //immediately executes the sql when called
            var sub = _context.Submissions.SingleOrDefault(c => c.subKey == id);
            string listOfUserVotedFOr = sub.StringListOfSubsVotedFor;
            if(listOfUserVotedFOr == null)
            {
                listOfUserVotedFOr = "";
            }
            List<String> ListOfUsersVotedFor = listOfUserVotedFOr.Split(',').ToList<string>();
            var userId = User.Identity.GetUserId();
            if (userId == null)
                throw new HttpResponseException(HttpStatusCode.NoContent);

            
            if (ListOfUsersVotedFor.Contains(userId))
            {
                Console.WriteLine("found the user");
                //return view without vote button
                return View("ReadOnlyDetailsCantVote",sub);
            }

            if (User.IsInRole("CanManageSubmissions"))
            {
                
                if (sub == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Edit", sub);
                }
            }
            else
            {
                return View("ReadOnlyDetails", sub);
            }
           
            
        }
        //an action for our custom route: URL must match the route pattern from the RouteConfig file
        //added constraints for Attribute Routing
        [System.Web.Http.Route("localhost:49554/submission/SubmissionsByGrantCategory/{amount:regex(\\500|1000|5000{4})}/{quarter:regex(\\[1-4]{1})}")]
        public ActionResult SubmissionsByGrantCategory(int? amount, int? quarter)
        {
            var subsList = new List<Submission>() { new Submission { nameOfCause = "Homeless" }, new Submission { nameOfCause = "food"} };
            var user = new AdminUser() { Username = "Rory" , HasAdminRights = true,AdminType =new  AdminType()};
            //have to initialize the ViewModel
            var viewModel = new SubmissionsViewModel
            {
                Submissions = subsList,
                User = user

            };
            return View(viewModel);
        }

        //to call the paramter embedded in the URL
        //Get: livehost/Submission/Edit/1
        //Query String: livehost/Submission/Edit?id=1  //int? id, 
        [System.Web.Http.Authorize(Roles = RoleName.CanManageSubmissions)]
        public ActionResult Edit(int id)
        {
            
            var editSub = _context.Submissions.SingleOrDefault(c => c.subKey == id);
            if (editSub == null)
            {
                return HttpNotFound();
            }
            else
            {
                editSub.subKey = id;
                return View("NewCause",editSub);
            }
        }

        public ActionResult Test(int id)
        {
            //another way to call the View
            //return new ViewResult(sub);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index","Home", new {page = 1 , sortBy= "name"});
            return View();
        }
        
        

        public bool VoteSub(Submission sub)
        {
            if(sub != null)
            {
                //update this submission
                int id = sub.subKey;
                sub.internalVotes++;
                var subslist = _context.Submissions.Where(x => x.subKey == id).FirstOrDefault();
                
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false ;    
            }
            
        }
    }
}