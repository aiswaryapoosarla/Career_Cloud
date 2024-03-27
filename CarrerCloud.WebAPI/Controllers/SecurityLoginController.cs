using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{

    [Route("api/careercloud/securitylogin/v1")]
    [ApiController]
    public class SecurityLoginController : ControllerBase
    {
        private SecurityLoginLogic _sl;

        public SecurityLoginController()
        {
            var repo = new EFGenericRepository<SecurityLoginPoco>();
            _sl = new SecurityLoginLogic(repo);
        }

        [HttpGet]
        [Route("login/all")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllSecurityLogin()
        {
            var res = _sl.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("login/{securityloginId}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetSecurityLogin(Guid id)
        {
            try
            {
                var res = _sl.Get(id);
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
        [Route("login/{create}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostSecurityLogin(SecurityLoginPoco[] poco)
        {
            try
            {
                _sl.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("login/{update}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutSecurityLogin(SecurityLoginPoco[] poco)
        {
            try
            {
                _sl.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("login/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteSecurityLogin(SecurityLoginPoco[] poco)
        {
            try
            {
                _sl.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
