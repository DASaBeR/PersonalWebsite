using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Contracts
{

    public interface IMyInfoRepository
    {
        MyInfoModel GetMyInfo(bool trackChanges);
        void UpdateMyInfo(MyInfoModel myInfo);
    }
}
