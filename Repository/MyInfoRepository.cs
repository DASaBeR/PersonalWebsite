using PersonalWebsite.Contracts;
using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Repository
{
	public class MyInfoRepository : RepositoryBase<MyInfoModel>, IMyInfoRepository
	{
		public MyInfoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public MyInfoModel GetMyInfo(bool trackChanges) =>
				FindAll(trackChanges).FirstOrDefault();

		public void AddMyInfo(MyInfoModel myInfo) =>
						Create(myInfo);
		public void UpdateMyInfo(MyInfoModel myInfo) =>
						Update(myInfo);
	}
}
