using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{

    [Route("api/careercloud/jobskill/v1")]
    [ApiController]
    public class CompanyJobSkillController : ControllerBase
    {
        private CompanyJobSkillLogic _cjs;

        public CompanyJobSkillController()
        {
            var repo = new EFGenericRepository<CompanyJobSkillPoco>();
            _cjs = new CompanyJobSkillLogic(repo);
        }

        [HttpGet]
        [Route("jobskill/all")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobSkillPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllCompanyJobSkill()
        {
            var res = _cjs.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("jobskill/{companyjobskillId}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobSkillPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetCompanyJobSkill(Guid id)
        {
            try
            {
                var res = _cjs.Get(id);
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
        [Route("jobskill/{create}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobSkillPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostCompanyJobSkill(CompanyJobSkillPoco[] poco)
        {
            try
            {
                _cjs.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("jobskill/{update}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobSkillPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutCompanyJobSkill(CompanyJobSkillPoco[] poco)
        {
            try
            {
                _cjs.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("jobskill/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobSkillPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteCompanyJobSkill(CompanyJobSkillPoco[] poco)
        {
            try
            {
                _cjs.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
