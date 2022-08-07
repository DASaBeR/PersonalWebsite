﻿using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Contracts
{
    public interface IExperienceRepository
    {
        IEnumerable<ExperienceModel> GetExperiences(bool trackChanges);
    }
}
