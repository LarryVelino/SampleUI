using Akoya.Test.Domain.Models;
using System.Collections.Generic;

namespace Akoya.Test.Domain.Abstract
{
    public interface IStudyManager
    {
        public ResultWithData<List<Study>> GetStudies();

        public ResultWithData<List<User>> GetAllUsersInStudy(int studyId);

        public ResultWithData<List<Study>> GetAllStudiesWithUser(int userId);

        public Result RemoveUserFromStudy(int userId, int studyId);

        public Result AddUserToStudy(int userId, int studyId);
    }
}
