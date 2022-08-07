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
        private readonly IHostingEnvironment _hostingEnv;
        private readonly IRepositoryManager _repository;
        public AdminController(IHostingEnvironment hostingEnv, IRepositoryManager repository)
        {
            _hostingEnv = hostingEnv;
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MyInformation()
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
            return View("MyInfo" , vm);
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
            return RedirectToAction("Myinformation");
        }
    }
}
