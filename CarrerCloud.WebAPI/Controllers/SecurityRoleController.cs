using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{

    [Route("api/careercloud/securityrole/v1")]
    [ApiController]
    public class SecurityRoleController : ControllerBase
    {
        private SecurityRoleLogic _sr;

        public SecurityRoleController()
        {
            var repo = new EFGenericRepository<SecurityRolePoco>();
            _sr = new SecurityRoleLogic(repo);
        }

        [HttpGet]
        [Route("role/all")]
        [ProducesResponseType(typeof(IEnumerable<SecurityRolePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllSecurityRole()
        {
            var res = _sr.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("role/{securityroleId}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityRolePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetSecurityRole(Guid id)
        {
            try
            {
                var res = _sr.Get(id);
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
        [Route("role/{create}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityRolePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostSecurityRole(SecurityRolePoco[] poco)
        {
            try
            {
                _sr.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("role/{update}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityRolePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutSecurityRole(SecurityRolePoco[] poco)
        {
            try
            {
                _sr.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("role/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityRolePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteSecurityRole(SecurityRolePoco[] poco)
        {
            try
            {
                _sr.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
