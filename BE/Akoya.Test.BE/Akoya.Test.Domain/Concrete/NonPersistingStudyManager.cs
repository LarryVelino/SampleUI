using Akoya.Test.Domain.Abstract;
using Akoya.Test.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Akoya.Test.Domain.Concrete
{
    public class NonPersistingStudyManager : IStudyManager
    {
        public List<Study> Studies { get; private set; }
        public List<User> Users { get; private set; }

        public NonPersistingStudyManager()
        {
            InitStudies();
            Users = new List<User> { _larry, _otherOne, _otherTwo, _otherThree, _user };
        }

        public ResultWithData<List<Study>> GetStudies()
        {
            return new ResultWithData<List<Study>>(Studies, true, "Found");
        }

        public Result AddUserToStudy(int userId, int studyId)
        {
            _ = GetUserOrThrowNotFoundException(userId);
            _ = GetStudyOrThrowNotFoundException(studyId);

            // since not persisting, just returning a result

            return new Result(true, $"User with ID {userId} added to Study with ID {studyId}.");
        }

        public Result RemoveUserFromStudy(int userId, int studyId)
        {
            _ = GetUserOrThrowNotFoundException(userId);
            _ = GetStudyOrThrowNotFoundException(studyId);

            // since not persisting, just returning a result

            return new Result(true, $"User with ID {userId} removed from Study with ID {studyId}.");
        }

        public ResultWithData<List<User>> GetAllUsersInStudy(int studyId)
        {
            Study study = GetStudyOrThrowNotFoundException(studyId);

            return new ResultWithData<List<User>>(study.Users, true, $"Found Users for Study ID {studyId}");
        }

        public ResultWithData<List<Study>> GetAllStudiesWithUser(int userId)
        {
            List<Study> result = new();

            // not the best. O(n). 
            foreach (var study in Studies)
            {
                if (study.Users.Any(u => u.ID == userId))
                {
                    // to strip out Users from result
                    result.Add(new Study() { Id = study.Id, Name = study.Name});
                }
            }

            return new ResultWithData<List<Study>>(result, true, $"Found {result.Count} Studies with User Id {userId}");
        }

        private User GetUserOrThrowNotFoundException(int userId)
        {
            User user = Users.Where(u => u.ID == userId).FirstOrDefault();
            if (user == default)
            {
                throw new Exception($"User with ID {userId} does not exist.");
            }

            return user;
        }

        private Study GetStudyOrThrowNotFoundException(int studyId)
        {
            Study study = Studies.Where(s => s.Id == studyId).FirstOrDefault();

            if (study == default)
            {
                throw new Exception($"Study with ID {studyId} does not exist.");
            }

            return study;
        }

        private void InitStudies()
        {

            Studies = new List<Study>()
            {
                new Study()
                {
                    Name = "StudyOne",
                    Id = 123,
                    Users = new List<User>()
                    {
                        _larry,
                        _otherOne
                    }
                },
                new Study()
                {
                    Name = "StudyTwo",
                    Id = 456,
                    Users = new List<User>()
                    {
                        _larry,
                        _otherOne,
                        _otherTwo
                    }
                },
                new Study()
                {
                    Name = "StudyThree",
                    Id = 789,
                    Users = new List<User>()
                    {
                        _larry,
                        _otherTwo,
                        _otherThree
                    }
                }
            };
        }

        readonly User _larry = new()
        {
            Name = "Larry",
            ID = 999
        };
        readonly User _otherOne = new()
        {
            Name = "Other",
            ID = 000
        };
        readonly User _otherTwo = new()
        {
            Name = "Other2",
            ID = 111
        };
        readonly User _otherThree = new()
        {
            Name = "Other3",
            ID = 222
        };
        readonly User _user = new()
        {
            Name = "User",
            ID = 101
        };
    }
}
