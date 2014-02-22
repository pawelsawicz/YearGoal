using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
namespace YearGoal.Modules.Goal
{
    public class GoalModule : NancyModule
    {
        
        public GoalModule()
        {
            Get["/goal"] = _ =>
            {
                return View["Index"];
            };
        }
    }
}