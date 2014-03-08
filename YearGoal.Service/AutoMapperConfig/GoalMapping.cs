using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YearGoal.Data.Model;
using YearGoal.Service.Models.Goal;

namespace YearGoal.Service.AutoMapperConfig
{
    public class GoalMapping : Profile
    {
        protected override void Configure()
        {           
            Mapper.CreateMap<CreateGoalViewModel, Goal>();
            Mapper.CreateMap<GoalViewModel, Goal>();
            Mapper.CreateMap<Goal, GoalViewModel>();
            Mapper.CreateMap<UpdateGoalViewModel, Goal>();       
        }
    }
}
