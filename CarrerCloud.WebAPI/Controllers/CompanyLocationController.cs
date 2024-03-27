using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{

    [Route("api/careercloud/companylocation/v1")]
    [ApiController]
    public class CompanyLocationController : ControllerBase
    {
        private CompanyLocationLogic _cl;

        public CompanyLocationController()
        {
            var repo = new EFGenericRepository<CompanyLocationPoco>();
            _cl = new CompanyLocationLogic(repo);
        }

        [HttpGet]
        [Route("location/all")]
        [ProducesResponseType(typeof(IEnumerable<CompanyLocationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllCompanyLocation()
        {
            var res = _cl.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("location/{companylocationId}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyLocationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetCompanyLocation(Guid id)
        {
            try
            {
                var res = _cl.Get(id);
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
        [Route("location/{create}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyLocationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostCompanyLocation(CompanyLocationPoco[] poco)
        {
            try
            {
                _cl.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("location/{update}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyLocationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutCompanyLocation(CompanyLocationPoco[] poco)
        {
            try
            {
                _cl.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("location/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyLocationPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteCompanyLocation(CompanyLocationPoco[] poco)
        {
            try
            {
                _cl.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
