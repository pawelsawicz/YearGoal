using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YearGoal.Data.Model;
using YearGoal.Data.Repository.Interface;
using YearGoal.Service.Service;
using YearGoal.Service.Service.Interface;
using YearGoal.Service.Models.Goal;
using FluentAssertions;
using YearGoal.Service.AutoMapperConfig;
using YearGoal.Service;
namespace YearGoal.Test.GoalTests
{
    [TestFixture]
    public class GoalServiceTests
    {
        private Mock<IGoalRepository> _mockedGoalRepository { get; set; }
        private IGoalService _goalService { get; set; }
        private string _goalIdRegex { get; set; }

        [SetUp]
        public void SetUp()
        {
            _mockedGoalRepository = new Mock<IGoalRepository>();
            _goalService = new GoalService(_mockedGoalRepository.Object);
            ServiceBootstrapper.RegisterAutoMapperConfig();
            _goalIdRegex = "(?:(goal)+)/(?:[0-9]+)"; //It's regex that check if GoalId is correct - i.e "goal/n" where n is going to -> infinity
        }

        [Test]
        public void succeed_add_goal_repository_mocked()
        {
            //arrange
            var model = new CreateGoalViewModel()
            {
                Name = "Some name",
                Description = "Some desc"
            };
            _mockedGoalRepository.Setup(repository => repository.Add(It.IsAny<Goal>())).Verifiable();

            //act
            var result = _goalService.AddGoal(model);

            //assert
            _mockedGoalRepository.Verify(verify => verify.Add(It.IsAny<Goal>()), Times.Once);            
        }

        [Test]
        public void succeed_delete_goal_repository_mocked()
        {
            //arrange
            _mockedGoalRepository.Setup(repository => repository.Remove(It.IsRegex(_goalIdRegex))).Verifiable();
            string goalId = "goal/1";

            //act
            _goalService.DeleteGoal(goalId);

            //assert
            _mockedGoalRepository.Verify(verify => verify.Remove(goalId), Times.Once);
        }

        [Test]
        public void succeed_get_goal_viewmodel_repository_mocked()
        {
            //arrange
            _mockedGoalRepository.Setup(repository => repository.GetById(It.IsRegex(_goalIdRegex))).Returns(new Goal()
            {
                Id = "goal/1",
                Name = "Some name",
                Description = "Some des"
            });

            //act
            var result = _goalService.GetGoalViewModel("goal/1");


            //assert
            _mockedGoalRepository.Verify(verify => verify.GetById("goal/1"), Times.Once);
            result.Id.Should().MatchRegex("(?:(goal)+)/(?:[0-9]+)");
            result.Name.Should().NotBeNull();
            result.Description.Should().NotBeNull();
        }

        [Test]
        public void succeed_update_goal_repository_mocked()
        {
            //arrange
            string goalId = "goal/1";
            var model = new UpdateGoalViewModel()
            {
                Id = goalId,
                Name = "some new name",
                Description = "some new desc"
            };
            _mockedGoalRepository.Setup(repository=>repository.Update(It.Is<Goal>(goal=>goal.Id == goalId), goalId)).Returns(true).Verifiable();


            //act
            var result = _goalService.Update(model);

            //assert
            _mockedGoalRepository.Verify(verify => verify.Update(It.IsAny<Goal>(), goalId), Times.Once);
            result.Should().Be(true);

        }

    }
}
