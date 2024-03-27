using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicantprofile/v1")]
    [ApiController]
    public class ApplicantProfileController : ControllerBase
    {
        private ApplicantProfileLogic _ap;

        public ApplicantProfileController()
        {
            var repo = new EFGenericRepository<ApplicantProfilePoco>();
            _ap = new ApplicantProfileLogic(repo);
        }

        [HttpGet]
        [Route("profile/all")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantProfilePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllApplicantProfile()
        {
            var res = _ap.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("profile/{applicantprofileId}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantProfilePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetApplicantProfile(Guid id)
        {
            try
            {
                var res = _ap.Get(id);
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("profile/{create}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantProfilePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostApplicantProfile(ApplicantProfilePoco[] poco)
        {
            try
            {
                _ap.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("profile/{update}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantProfilePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutApplicantProfile(ApplicantProfilePoco[] poco)
        {
            try
            {
                _ap.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("profile/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantProfilePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteApplicantProfile(ApplicantProfilePoco[] poco)
        {
            try
            {
                _ap.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }

    }
}
    

