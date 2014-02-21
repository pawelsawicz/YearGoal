using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using YearGoal.Data.Repository.Interface;

namespace YearGoal.Modules.Home
{
    public class HomeModule : NancyModule 
    {
        private readonly IGoalRepository _goalRepository;

        public HomeModule(IGoalRepository goalRepository)
        {
           

        }
    }
}