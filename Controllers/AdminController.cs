using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
	[Authorize]
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

		#region Informations

		[HttpGet]
		public IActionResult Informations()
		{
			var myInfo = _repository.MyInfo.GetMyInfo(trackChanges: false);
			if (myInfo == null)
			{
				return View("Informations");
			}
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

		#endregion

		#region Expriences

		[HttpGet]
		public IActionResult Experiences()
		{
			var expList = _repository.Experience.GetExperiences(trackChanges: false);
			if (expList == null)
			{
				return View("Experiences");
			}
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

		#endregion

		#region Educations

		[HttpGet]
		public IActionResult Educations()
		{
			var eduList = _repository.Education.GetEducations(trackChanges: false);
			if (eduList == null)
			{
				return View("Educations");
			}
			var vm = new List<EduVM>();
			foreach (var item in eduList)
			{
				EduVM edu = new EduVM();
				edu.Id = item.Id;
				edu.Year = item.Year;
				edu.FieldOfStudy = item.FieldOfStudy;
				edu.Institute = item.Institute;
				edu.Description = item.Description;
				vm.Add(edu);
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
			var edu = _repository.Education.GetEducations(trackChanges: false).Where(x => x.Id == guid).SingleOrDefault();
			var vm = new EduVM
			{
				Id = edu.Id,
				Year = edu.Year,
				FieldOfStudy = edu.FieldOfStudy,
				Institute = edu.Institute,
				Description = edu.Description
			};
			return View("Education", vm);
		}

		[HttpPost]
		public IActionResult Education(EduVM vm)
		{
			if (vm.Id == Guid.Empty)
			{
				EducationModel edu = new EducationModel
				{
					Year = vm.Year,
					FieldOfStudy = vm.FieldOfStudy,
					Institute = vm.Institute,
					Description = vm.Description
				};
				_repository.Education.AddEdu(edu);
				_repository.Save();
				return RedirectToAction("Educations");
			}
			else
			{
				var edu = _repository.Education.GetEducations(trackChanges: false).Where(x => x.Id == vm.Id).SingleOrDefault();
				if (edu != null)
				{
					edu.Year = vm.Year;
					edu.FieldOfStudy = vm.FieldOfStudy;
					edu.Institute = vm.Institute;
					edu.Description = vm.Description;
					_repository.Education.UpdateEdu(edu);
					_repository.Save();
					return RedirectToAction("Educations");
				}
				return View("Educations", vm);
			}

		}

		public IActionResult DeleteEducation(Guid guid)
		{
			var edu = _repository.Education.GetEducations(trackChanges: false).Where(x => x.Id == guid).SingleOrDefault();
			if (edu != null)
			{
				_repository.Education.DeleteEdu(edu);
				_repository.Save();
			}
			return RedirectToAction("Educations");
		}

		#endregion

		#region Skills

		[HttpGet]
		public IActionResult Skills()
		{
			var skillList = _repository.Skills.GetSkills(trackChanges: false);
			if (skillList == null)
			{
				return View("Skills");
			}
			var vm = new List<SkillVM>();
			foreach (var item in skillList)
			{
				SkillVM skill = new SkillVM();
				skill.Id = item.Id;
				skill.SkillName = item.SkillName;
				skill.Percentage = item.Percentage;
				vm.Add(skill);
			}

			return View("Skills", vm);
		}

		[HttpGet]
		public IActionResult Skill(Guid guid)
		{
			if (guid == Guid.Empty)
			{
				return View("Skill");

			}
			var skill = _repository.Skills.GetSkills(trackChanges: false).Where(x => x.Id == guid).SingleOrDefault();
			var vm = new SkillVM
			{
				Id = skill.Id,
				SkillName = skill.SkillName,
				Percentage = skill.Percentage,
			};
			return View("Skill", vm);
		}

		[HttpPost]
		public IActionResult Skill(SkillVM vm)
		{
			if (vm.Id == Guid.Empty)
			{
				SkillsModel skill = new SkillsModel
				{
					SkillName = vm.SkillName,
					Percentage = vm.Percentage,
				};
				_repository.Skills.AddSkill(skill);
				_repository.Save();
				return RedirectToAction("Skills");
			}
			else
			{
				var skill = _repository.Skills.GetSkills(trackChanges: false).Where(x => x.Id == vm.Id).SingleOrDefault();
				if (skill != null)
				{
					skill.SkillName = vm.SkillName;
					skill.Percentage = vm.Percentage;
					_repository.Skills.UpdateSkill(skill);
					_repository.Save();
					return RedirectToAction("Skills");
				}
				return View("Skills", vm);
			}

		}

		public IActionResult DeleteSkill(Guid guid)
		{
			var skill = _repository.Skills.GetSkills(trackChanges: false).Where(x => x.Id == guid).SingleOrDefault();
			if (skill != null)
			{
				_repository.Skills.DeleteSkill(skill);
				_repository.Save();
			}
			return RedirectToAction("Skills");
		}

		#endregion

		#region Services

		[HttpGet]
		public IActionResult Services()
		{
			var serviceList = _repository.Services.GetServices(trackChanges: false);
			if (serviceList == null)
			{
				return View("Services");
			}
			var vm = new List<ServiceVM>();
			foreach (var item in serviceList)
			{
				ServiceVM service = new ServiceVM();
				service.Id = item.Id;
				service.ServiceName = item.ServiceName;
				service.Description = item.Description;
				vm.Add(service);
			}

			return View("Services", vm);
		}

		[HttpGet]
		public IActionResult Service(Guid guid)
		{
			if (guid == Guid.Empty)
			{
				return View("Service");

			}
			var service = _repository.Services.GetServices(trackChanges: false).Where(x => x.Id == guid).SingleOrDefault();
			var vm = new ServiceVM
			{
				Id = service.Id,
				ServiceName = service.ServiceName,
				Description = service.Description,
			};
			return View("Service", vm);
		}

		[HttpPost]
		public IActionResult Service(ServiceVM vm)
		{
			if (vm.Id == Guid.Empty)
			{
				ServicesModel service = new ServicesModel
				{
					ServiceName = vm.ServiceName,
					Description = vm.Description,
				};
				_repository.Services.AddService(service);
				_repository.Save();
				return RedirectToAction("Services");
			}
			else
			{
				var service = _repository.Services.GetServices(trackChanges: false).Where(x => x.Id == vm.Id).SingleOrDefault();
				if (service != null)
				{
					service.ServiceName = vm.ServiceName;
					service.Description = vm.Description;
					_repository.Services.UpdateService(service);
					_repository.Save();
					return RedirectToAction("Services");
				}
				return View("Services", vm);
			}

		}

		public IActionResult DeleteService(Guid guid)
		{
			var service = _repository.Services.GetServices(trackChanges: false).Where(x => x.Id == guid).SingleOrDefault();
			if (service != null)
			{
				_repository.Services.DeleteService(service);
				_repository.Save();
			}
			return RedirectToAction("Services");
		}

		#endregion
	}
}
