using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YearGoal.Data.Model;
using YearGoal.Data.Repository.Interface;

namespace YearGoal.Data.Repository
{
    public class GoalRepository : Repository<Goal>, IGoalRepository
    {    
        public bool CheckIfExist(string Id)
        {            
            try
            {
                if (this.GetById(Id) != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

            return true;
        }
    }
}
