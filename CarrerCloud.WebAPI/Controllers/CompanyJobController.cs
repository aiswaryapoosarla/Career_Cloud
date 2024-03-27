using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/companyjob/v1")]
    [ApiController]
    public class CompanyJobController : ControllerBase
    {
        private CompanyJobLogic _cj;

        public CompanyJobController()
        {
            var repo = new EFGenericRepository<CompanyJobPoco>();
            _cj = new CompanyJobLogic(repo);
        }

        [HttpGet]
        [Route("companyjob/all")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllCompanyJob()
        {
            var res = _cj.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("companyjob/{companyjobId}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetCompanyJob(Guid id)
        {
            try
            {
                var res = _cj.Get(id);
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
        [Route("companyjob/{create}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostCompanyJob(CompanyJobPoco[] poco)
        {
            try
            {
                _cj.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("companyjob/{update}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutCompanyJob(CompanyJobPoco[] poco)
        {
            try
            {
                _cj.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("companyjob/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteCompanyJob(CompanyJobPoco[] poco)
        {
            try
            {
                _cj.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }

    }
}
