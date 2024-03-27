using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicantresume/v1")]
    [ApiController]

    public class ApplicantResumeController : ControllerBase
    {
        private ApplicantResumeLogic _ar;

        public ApplicantResumeController()
        {
            var repo = new EFGenericRepository<ApplicantResumePoco>();
            _ar = new ApplicantResumeLogic(repo);
        }

        [HttpGet]
        [Route("resume/all")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantResumePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllApplicantResume()
        {
            var res = _ar.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("resume/{applicantresumeId}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantResumePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetApplicantResume(Guid id)
        {
            try
            {
                var res = _ar.Get(id);
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
        [Route("resume/{create}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantResumePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostApplicantResume(ApplicantResumePoco[] poco)
        {
            try
            {
                _ar.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("resume/{update}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantResumePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutApplicantResume(ApplicantResumePoco[] poco)
        {
            try
            {
                _ar.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("resume/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantResumePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteApplicantResume(ApplicantResumePoco[] poco)
        {
            try
            {
                _ar.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
