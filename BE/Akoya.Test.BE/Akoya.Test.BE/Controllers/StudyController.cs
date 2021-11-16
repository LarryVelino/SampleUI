using Akoya.Test.Domain.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Akoya.Test.BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyController : ControllerBase
    {
        public StudyController(IStudyManager studyManager, ILogger<StudyController> logger)
        {
            _studyManager = studyManager;
            _logger = logger;
        }

        [HttpGet("{studyId}/users")]
        public IActionResult GetUsersInStudy(int studyId)
        {
            var result = _studyManager.GetAllUsersInStudy(studyId);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetStudiesWithUserId([FromQuery(Name = "userId")] int? userId)
        {
            if (userId != default)
            {
                var queriedStudies = _studyManager.GetAllStudiesWithUser((int)userId);
                return Ok(queriedStudies);
            }

            var allStudies = _studyManager.GetStudies();
            return Ok(allStudies);
        }

        // should use a JSON Body, but for simplicity's sake.
        [HttpDelete("{studyId}/users/{userId}")]
        public IActionResult RemoveUserFromStudy(int studyId, int userId)
        {
            var result = _studyManager.RemoveUserFromStudy(userId, studyId);
            return Ok(result);
        }

        // should use a JSON Body, but for simplicity's sake.
        [HttpPut("{studyId}/users/{userId}")]
        public IActionResult AddUserToStudy(int studyId, int userId)
        {
            var result = _studyManager.AddUserToStudy(userId, studyId);
            return Ok(result);
        }

        private IStudyManager _studyManager;
        private ILogger<StudyController> _logger;
    }
}
