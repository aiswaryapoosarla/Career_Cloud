using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class CompanyJobEducationController : ControllerBase
    {
        private CompanyJobEducationLogic _cje;

        public CompanyJobEducationController()
        {
            var repo = new EFGenericRepository<CompanyJobEducationPoco>();
            _cje = new CompanyJobEducationLogic(repo);
        }

        [HttpGet]
        [Route("jobeducation/all")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobEducationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllCompanyJobEducation()
        {
            var res = _cje.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("jobeducation/{companyjobEducationId}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobEducationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetCompanyJobEducation(Guid id)
        {
            try
            {
                var res = _cje.Get(id);
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
        [Route("jobeducation/{create}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobEducationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostCompanyJobEducation(CompanyJobEducationPoco[] poco)
        {
            try
            {
                _cje.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("jobeducation/{update}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobEducationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutCompanyJobEducation(CompanyJobEducationPoco[] poco)
        {
            try
            {
                _cje.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("jobeducation/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobEducationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteCompanyJobEducation(CompanyJobEducationPoco[] poco)
        {
            try
            {
                _cje.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
