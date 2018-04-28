using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Community_Trust.Models;
using Community_Trust.DTOs;

namespace Community_Trust.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Submission,SubmissionDTO>();
            });

            IMapper mapper = config.CreateMapper();
            var source = new Submission();
            var dest = mapper.Map<Submission, SubmissionDTO>(source);
           
        }
    }
}