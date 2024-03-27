using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{

    [Route("api/careercloud/countrycode/v1")]
    [ApiController]
    public class SystemCountryCodeController : ControllerBase
    {
        private SystemCountryCodeLogic _scc;

        public SystemCountryCodeController()
        {
            var repo = new EFGenericRepository<SystemCountryCodePoco>();
            _scc = new SystemCountryCodeLogic(repo);
        }

        [HttpGet]
        [Route("countrycode/all")]
        [ProducesResponseType(typeof(IEnumerable<SystemCountryCodePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllSystemCountryCode()
        { 
            var res =  _scc.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("countrycode/{SystemCountryCodeCode}")]
        [ProducesResponseType(typeof(IEnumerable<SystemCountryCodePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetSystemCountryCode(string Code)
        {
            try
            {
                var res = _scc.Get(Code);
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
        [Route("countrycode/{create}")]
        [ProducesResponseType(typeof(IEnumerable<SystemCountryCodePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostSystemCountryCode(SystemCountryCodePoco[] poco)
        {
            try
            {
                _scc.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("countrycode/{update}")]
        [ProducesResponseType(typeof(IEnumerable<SystemCountryCodePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutSystemCountryCode(SystemCountryCodePoco[] poco)
        {
            try
            {
                _scc.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("countrycode/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<SystemCountryCodePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteSystemCountryCode(SystemCountryCodePoco[] poco)
        {
            try
            {
                _scc.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
