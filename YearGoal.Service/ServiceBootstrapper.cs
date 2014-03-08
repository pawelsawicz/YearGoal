using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YearGoal.Service.AutoMapperConfig;

namespace YearGoal.Service
{
    public static class ServiceBootstrapper
    {
        public static void RegisterAutoMapperConfig()
        {
            Mapper.Initialize(x => x.AddProfile<GoalMapping>());
        }
    }
}
