using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{

    [Route("api/careercloud/jobapplication/v1")]
    [ApiController]
    public class ApplicantJobApplicationController : ControllerBase
    {
        private ApplicantJobApplicationLogic _aj;

        public ApplicantJobApplicationController()
        {
            var repo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            _aj = new ApplicantJobApplicationLogic(repo);
        }

        [HttpGet]
        [Route("jobapplication/all")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantJobApplicationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllApplicantJobApplication()
        {
            var res = _aj.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("jobapplication/{applicantjobapplicationId}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantJobApplicationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetApplicantJobApplication(Guid id)
        {
            try
            {
                var res = _aj.Get(id);
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
        [Route("education/{create}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantJobApplicationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostApplicantJobApplication(ApplicantJobApplicationPoco[] poco)
        {
            try
            {
                _aj.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("education/{update}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantJobApplicationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutApplicantJobApplication(ApplicantJobApplicationPoco[] poco)
        {
            try
            {
                _aj.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("education/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantJobApplicationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteApplicantJobApplication(ApplicantJobApplicationPoco[] poco)
        {
            try
            {
                _aj.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }


    }
}

