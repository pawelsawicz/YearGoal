using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using YearGoal.Data.Repository.Interface;
using Moq;
using FluentAssertions;
namespace YearGoal.Test.Goal
{
    [TestFixture]
    public class GoalTest
    {
        private readonly IGoalService _goalService;
        private readonly Mock<IGoalRepository> mockRepository;

        [SetUp]
        public void SetUp()
        {
            var mockRepository = new Mock<IGoalRepository>();            
        }       

        [Test]
        public void add_goal_by_user_stub()
        {
            //arrange   
            CreateGoalViewModel model = new CreateGoalViewModel()
            {
                Name = "Test Goal"
            };            
            mockRepository.Setup(repository => repository.Add(new Data.Model.Goal()
            {
                Name = "Test Goal"
            })).Verifiable();            
            _goalService = new GoalService(mockRepository.Object);

            //act
            _goalService.AddGoal(model);
           
            //assert
            mockRepository.Verify(x => x.Add(new Data.Model.Goal() { Name = "Test Goal" }));
        }


    }
}
