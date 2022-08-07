using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Contracts;
using PersonalWebsite.Repository;
using PersonalWebsite.Models;
using PersonalWebsite.Models.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace PersonalWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var myInfo = _repository.MyInfo.GetMyInfo(trackChanges: false);
            var skills = _repository.Skills.GetSkills(trackChanges: false);
            var educations = _repository.Education.GetEducations(trackChanges: false);
            var experiences = _repository.Experience.GetExperiences(trackChanges: false);
            var services = _repository.Services.GetServices(trackChanges: false);
            var vm = new IndexVM
            {
                AboutMe = new AboutMeVM
                {
                    MyInfo = new MyInfoModel
                    {
                        Id = myInfo.Id,
                        Name = myInfo.Name,
                        Specialty = myInfo.Specialty,
                        Description = myInfo.Description,
                        From = myInfo.From,
                        LivesIn = myInfo.LivesIn,
                        Age = myInfo.Age,
                        Email = myInfo.Email,
                        Github = myInfo.Github,
                        TelegramId = myInfo.TelegramId,
                        Linkdin = myInfo.Linkdin,
                        Phone = myInfo.Phone
                    },
                    Skills = skills,
                    Educations = educations,
                    Experiences = experiences
                },
                Services = services
            };


            return View(vm);
        }
        [HttpPost]
        public IActionResult Index([FromForm] CreateMessageVM vm)
        {
            var myInfo = _repository.MyInfo.GetMyInfo(trackChanges: false);
            var skills = _repository.Skills.GetSkills(trackChanges: false);
            var educations = _repository.Education.GetEducations(trackChanges: false);
            var experiences = _repository.Experience.GetExperiences(trackChanges: false);
            var services = _repository.Services.GetServices(trackChanges: false);
            
            if (!ModelState.IsValid)
            {
                var indexVm = new IndexVM
                {
                    AboutMe = new AboutMeVM
                    {
                        MyInfo = new MyInfoModel
                        {
                            Id = myInfo.Id,
                            Name = myInfo.Name,
                            Specialty = myInfo.Specialty,
                            Description = myInfo.Description,
                            From = myInfo.From,
                            LivesIn = myInfo.LivesIn,
                            Age = myInfo.Age,
                            Email = myInfo.Email,
                            Github = myInfo.Github,
                            TelegramId = myInfo.TelegramId,
                            Linkdin = myInfo.Linkdin,
                            Phone = myInfo.Phone
                        },
                        Skills = skills,
                        Educations = educations,
                        Experiences = experiences
                    },
                    Services = services,
                    messageVM = new CreateMessageVM
                    {
                        Name = vm.Name,
                        Email = vm.Email,
                        Subject = vm.Subject,
                        Message = vm.Message
                    }
                };

                return View("Index", indexVm);
            }
            var contactMessage = new ContactModel
            {
                Name = vm.Name,
                EmailAdrress = vm.Email,
                Subject = vm.Subject,
                Message = vm.Message
            };
            _repository.Contact.SaveContactMessage(contactMessage);
            _repository.Save();
            return View("MsgSent",vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
