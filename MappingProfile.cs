using AutoMapper;
using PersonalWebsite.Models;
using PersonalWebsite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactModel, CreateMessageVM>();
        }
    }
}
