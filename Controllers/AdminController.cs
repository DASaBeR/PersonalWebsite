using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Contracts;
using PersonalWebsite.Models;
using PersonalWebsite.Models.ViewModels;
using PersonalWebsite.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly IRepositoryManager _repository;
        public AdminController(IWebHostEnvironment hostingEnv, IRepositoryManager repository)
        {
            _hostingEnv = hostingEnv;
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Informations()
        {
            var myInfo = _repository.MyInfo.GetMyInfo(trackChanges: false);
            var vm = new MyInfoVM
            {
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
                Phone = myInfo.Phone,
                ImageName = myInfo.ImageName,
                CvName = myInfo.CVName
            };
            return View("Informations", vm);
        }

        [HttpPost]
        public IActionResult MyInformation(MyInfoVM vm)
        {
            var myInfo = _repository.MyInfo.GetMyInfo(trackChanges: false);
            if (vm.MyCV != null && vm.Image != null)
            {
                //upload files to wwwroot
                var cvName = Path.GetFileName(vm.MyCV.FileName);
                //judge if it is pdf file
                string ext = Path.GetExtension(vm.MyCV.FileName);
                if (ext.ToLower() != ".pdf")
                {
                    return View();
                }
                var cvPath = Path.Combine(_hostingEnv.WebRootPath, "cv", cvName);

                using (var fileStream = new FileStream(cvPath, FileMode.Create))
                {
                    vm.MyCV.CopyToAsync(fileStream);
                }

                //upload files to wwwroot
                var imageName = Path.GetFileName(vm.Image.FileName);
                //judge if it is pdf file
                string ext2 = Path.GetExtension(vm.Image.FileName);
                if (ext2.ToLower() != ".jpg")
                {
                    return View();
                }
                var imagePath = Path.Combine(_hostingEnv.WebRootPath, "images", imageName);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    vm.Image.CopyToAsync(fileStream);
                }
                MyInfoModel model2 = new MyInfoModel
                {
                    Id = myInfo.Id,
                    Name = vm.Name,
                    Specialty = vm.Specialty,
                    Description = vm.Description,
                    From = vm.From,
                    LivesIn = vm.LivesIn,
                    Age = vm.Age,
                    Phone = vm.Phone,
                    Email = vm.Email,
                    TelegramId = vm.TelegramId,
                    Linkdin = vm.Linkdin,
                    Github = vm.Github,
                    CVPath = cvPath,
                    CVName = cvName,
                    ImagePath = imagePath,
                    ImageName = imageName
                };
            }

            MyInfoModel model = new MyInfoModel
            {
                Id = myInfo.Id,
                Name = vm.Name,
                Specialty = vm.Specialty,
                Description = vm.Description,
                From = vm.From,
                LivesIn = vm.LivesIn,
                Age = vm.Age,
                Phone = vm.Phone,
                Email = vm.Email,
                TelegramId = vm.TelegramId,
                Linkdin = vm.Linkdin,
                Github = vm.Github,
            };
            _repository.MyInfo.UpdateMyInfo(model);
            _repository.Save();
            return RedirectToAction("Informations");
        }

        [HttpGet]
        public IActionResult Experiences()
        {
            var expList = _repository.Experience.GetExperiences(trackChanges: false);
            var vm = new List<ExpVM>();
            foreach (var item in expList)
            {
                ExpVM exp = new ExpVM();
                exp.Id = item.Id;
                exp.StartYear = item.StartYear;
                exp.EndYear = item.EndYear;
                exp.IsCurrent = item.IsCurrent;
                exp.SubjectOfactivity = item.SubjectOfactivity;
                exp.Institute = item.Institute;
                exp.Description = item.Description;
                vm.Add(exp);
            }

            return View("Experiences", vm);
        }

        [HttpGet]
        public IActionResult Experience(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                return View("Experience");

            }
            var exp = _repository.Experience.GetExperiences(trackChanges: false).Where(x => x.Id == guid).SingleOrDefault();
            var vm = new ExpVM
            {
                Id = exp.Id,
                StartYear = exp.StartYear,
                EndYear = exp.EndYear,
                IsCurrent = exp.IsCurrent,
                SubjectOfactivity = exp.SubjectOfactivity,
                Institute = exp.Institute,
                Description = exp.Description
            };
            return View("Experience", vm);
        }

        [HttpPost]
        public IActionResult Experience(ExpVM vm)
        {
            if (vm.Id == Guid.Empty)
            {
                ExperienceModel exp = new ExperienceModel
                {
                    StartYear = vm.StartYear,
                    EndYear = vm.EndYear,
                    IsCurrent = vm.IsCurrent,
                    SubjectOfactivity = vm.SubjectOfactivity,
                    Institute = vm.Institute,
                    Description = vm.Description
                };
                _repository.Experience.AddExp(exp);
                _repository.Save();
                return RedirectToAction("Experiences");
            }
            else
            {
                var exp = _repository.Experience.GetExperiences(trackChanges: false).Where(x => x.Id == vm.Id).SingleOrDefault();
                if (exp != null)
                {
                    exp.StartYear = vm.StartYear;
                    exp.EndYear = vm.EndYear;
                    exp.IsCurrent = vm.IsCurrent;
                    exp.SubjectOfactivity = vm.SubjectOfactivity;
                    exp.Institute = vm.Institute;
                    exp.Description = vm.Description;
                    _repository.Experience.UpdateExp(exp);
                    _repository.Save();
                    return RedirectToAction("Experiences");
                }
                return View("Experience", vm);
            }

        }

        public IActionResult DeleteExperience(Guid guid)
        {
            var exp = _repository.Experience.GetExperiences(trackChanges: false).Where(x => x.Id == guid).SingleOrDefault();
            if (exp != null)
            {
                _repository.Experience.DeleteExp(exp);
                _repository.Save();
            }
            return RedirectToAction("Experiences");
        }







        [HttpGet]
        public IActionResult Educations()
        {
            var expList = _repository.Education.GetEducations(trackChanges: false);
            var vm = new List<EduVM>();
            foreach (var item in expList)
            {
                EduVM exp = new EduVM();
                exp.Id = item.Id;
                exp.Year = item.Year;
                exp.FieldOfStudy = item.FieldOfStudy;
                exp.Institute = item.Institute;
                exp.Description = item.Description;
                vm.Add(exp);
            }

            return View("Educations", vm);
        }

        [HttpGet]
        public IActionResult Education(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                return View("Education");

            }
            var exp = _repository.Education.GetEducations(trackChanges: false).Where(x => x.Id == guid).SingleOrDefault();
            var vm = new EduVM
            {
                Id = exp.Id,
                Year = exp.Year,
                FieldOfStudy = exp.FieldOfStudy,
                Institute = exp.Institute,
                Description = exp.Description
            };
            return View("Education", vm);
        }

        [HttpPost]
        public IActionResult Education(EduVM vm)
        {
            if (vm.Id == Guid.Empty)
            {
                EducationModel exp = new EducationModel
                {
                    Year = vm.Year,
                    FieldOfStudy = vm.FieldOfStudy,
                    Institute = vm.Institute,
                    Description = vm.Description
                };
                _repository.Education.AddEdu(exp);
                _repository.Save();
                return RedirectToAction("Educations");
            }
            else
            {
                var exp = _repository.Education.GetEducations(trackChanges: false).Where(x => x.Id == vm.Id).SingleOrDefault();
                if (exp != null)
                {
                    exp.Year = vm.Year;
                    exp.FieldOfStudy = vm.FieldOfStudy;
                    exp.Institute = vm.Institute;
                    exp.Description = vm.Description;
                    _repository.Education.UpdateEdu(exp);
                    _repository.Save();
                    return RedirectToAction("Educations");
                }
                return View("Educations", vm);
            }

        }

        public IActionResult DeleteEducation(Guid guid)
        {
            var exp = _repository.Education.GetEducations(trackChanges: false).Where(x => x.Id == guid).SingleOrDefault();
            if (exp != null)
            {
                _repository.Education.DeleteEdu(exp);
                _repository.Save();
            }
            return RedirectToAction("Educations");
        }
    }
}
