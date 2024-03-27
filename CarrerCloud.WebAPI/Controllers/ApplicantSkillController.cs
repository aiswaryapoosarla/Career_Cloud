using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicantskill/v1")]
    [ApiController]
    public class ApplicantSkillController : ControllerBase
    {
        private ApplicantSkillLogic _as;

        public ApplicantSkillController()
        {
            var repo = new EFGenericRepository<ApplicantSkillPoco>();
            _as = new ApplicantSkillLogic(repo);
        }

        [HttpGet]
        [Route("skill/all")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantSkillPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllApplicantSkill()
        {
            var res = _as.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("skill/{applicantskillId}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantSkillPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetApplicantSkill(Guid id)
        {
            try
            {
                var res = _as.Get(id);
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
        [Route("skill/{create}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantSkillPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostApplicantSkill(ApplicantSkillPoco[] poco)
        {
            try
            {
                _as.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("skill/{update}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantSkillPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutApplicantSkill(ApplicantSkillPoco[] poco)
        {
            try
            {
                _as.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("skill/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantSkillPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteApplicantSkill(ApplicantSkillPoco[] poco)
        {
            try
            {
                _as.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
