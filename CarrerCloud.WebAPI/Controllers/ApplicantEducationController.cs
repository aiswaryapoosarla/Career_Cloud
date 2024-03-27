using Microsoft.AspNetCore.Mvc;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.EntityFrameworkDataAccess;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class ApplicantEducationController : ControllerBase
    {
        private ApplicantEducationLogic _ae;

        public ApplicantEducationController()
        {
            var repo = new EFGenericRepository<ApplicantEducationPoco>();
            _ae = new ApplicantEducationLogic(repo);
        }

        [HttpGet]
        [Route("education/all")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantEducationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllApplicantEducation()
        {
            var res = _ae.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("education/{applicantEducationId}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantEducationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetApplicantEducation(Guid id)
        {
            try
            {
                var res = _ae.Get(id);
                if(res != null)
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
        [ProducesResponseType(typeof(IEnumerable<ApplicantEducationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostApplicantEducation(ApplicantEducationPoco[] poco)
        {
            try
            {
                _ae.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("education/{update}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantEducationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutApplicantEducation(ApplicantEducationPoco[] poco)
        {
            try
            {
                _ae.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("education/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantEducationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteApplicantEducation(ApplicantEducationPoco[] poco)
        {
            try
            {
                _ae.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }

}
}
