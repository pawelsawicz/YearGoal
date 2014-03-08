using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YearGoal.Service.Models.Goal;

namespace YearGoal.Service.Service.Interface
{
    public interface IGoalService : IService
    {
        string AddGoal(CreateGoalViewModel model);
        bool DeleteGoal(string goalId);
        GoalViewModel GetGoalViewModel(string goalId);
        bool Update(UpdateGoalViewModel model);

    }
}
