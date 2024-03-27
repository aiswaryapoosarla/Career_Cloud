using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/jobdescription/v1")]
    [ApiController]
    public class CompanyJobsDescriptionController : ControllerBase
    {
        private CompanyJobDescriptionLogic _cjd;

        public CompanyJobsDescriptionController()
        {
            var repo = new EFGenericRepository<CompanyJobDescriptionPoco>();
            _cjd = new CompanyJobDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("jobdescription/all")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobDescriptionPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllCompanyJobDescription()
        {
            var res = _cjd.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("jobdescription/{companyjobdescriptionId}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobDescriptionPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetCompanyJobsDescription(Guid id)
        {
            try
            {
                var res = _cjd.Get(id);
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
        [Route("jobdescription/{create}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobDescriptionPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostCompanyJobsDescription(CompanyJobDescriptionPoco[] poco)
        {
            try
            {
                _cjd.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("jobdescription/{update}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobDescriptionPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutCompanyJobsDescription(CompanyJobDescriptionPoco[] poco)
        {
            try
            {
                _cjd.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("jobdescription/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyJobDescriptionPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteCompanyJobsDescription(CompanyJobDescriptionPoco[] poco)
        {
            try
            {
                _cjd.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
