using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/securityloginsrole/v1")]
    [ApiController]
    public class SecurityLoginsRoleController : ControllerBase
    {
        private SecurityLoginsRoleLogic _slr;

        public SecurityLoginsRoleController()
        {
            var repo = new EFGenericRepository<SecurityLoginsRolePoco>();
            _slr = new SecurityLoginsRoleLogic(repo);
        }

        [HttpGet]
        [Route("loginsrole/all")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginsRolePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllSecurityLoginsRole()
        {
            var res = _slr.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("loginsrole/{securityloginsroleId}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginsRolePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetSecurityLoginsRole(Guid id)
        {
            try
            {
                var res = _slr.Get(id);
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
        [Route("loginsrole/{create}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginsRolePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostSecurityLoginRole(SecurityLoginsRolePoco[] poco)
        {
            try
            {
                _slr.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("loginsrole/{update}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginsRolePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutSecurityLoginsRole(SecurityLoginsRolePoco[] poco)
        {
            try
            {
                _slr.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("loginsrole/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginsRolePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteSecurityLoginRole(SecurityLoginsRolePoco[] poco)
        {
            try
            {
                _slr.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
