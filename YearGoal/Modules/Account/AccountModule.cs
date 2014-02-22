using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace YearGoal.Modules.Account
{
    public class AccountModule : NancyModule
    {
        public AccountModule()
        {
            Get["/login"] = _ =>
            {
                return View["Login"];
            };

            Get["/register"] = _ =>
            {
                return View["Register"];
            };
        }
    }
}