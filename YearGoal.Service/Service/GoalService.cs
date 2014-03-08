using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YearGoal.Data.Repository.Interface;
using YearGoal.Service.Service.Interface;
using YearGoal.Service.Models.Goal;
using AutoMapper;
using YearGoal.Data.Model;

namespace YearGoal.Service.Service
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public string AddGoal(CreateGoalViewModel model)
        {
            if (model != null)
            {
                var entity = Mapper.Map<CreateGoalViewModel, Goal>(model);
                _goalRepository.Add(entity);
                return entity.Id;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public bool DeleteGoal(string goalId)
        {

            _goalRepository.Remove(goalId);

            return true;
        }

        public GoalViewModel GetGoalViewModel(string goalId)
        {
            var entity = _goalRepository.GetById(goalId);

            var model = Mapper.Map<Goal, GoalViewModel>(entity);

            return model;
        }

        public bool Update(UpdateGoalViewModel model)
        {
            var entity = Mapper.Map<UpdateGoalViewModel, Goal>(model);
            
            _goalRepository.Update(entity, model.Id);

            return true;

        }
    }
}
