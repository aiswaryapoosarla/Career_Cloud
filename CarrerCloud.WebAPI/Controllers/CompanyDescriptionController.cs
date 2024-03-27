using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/companydescription/v1")]
    [ApiController]
    public class CompanyDescriptionController : ControllerBase
    {
        private CompanyDescriptionLogic _cd;

        public CompanyDescriptionController()
        {
            var repo = new EFGenericRepository<CompanyDescriptionPoco>();
            _cd = new CompanyDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("description/all")]
        [ProducesResponseType(typeof(IEnumerable<CompanyDescriptionPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllCompanyDescription()
        {
            var res = _cd.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("description/{companydescriptionId}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyDescriptionPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetCompanyDescription(Guid id)
        {
            try
            {
                var res = _cd.Get(id);
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
        [Route("description/{create}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyDescriptionPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostCompanyDescription(CompanyDescriptionPoco[] poco)
        {
            try
            {
                _cd.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("description/{update}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyDescriptionPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutCompanyDescription(CompanyDescriptionPoco[] poco)
        {
            try
            {
                _cd.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("description/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyDescriptionPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteCompanyDescription(CompanyDescriptionPoco[] poco)
        {
            try
            {
                _cd.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }

    }
}
