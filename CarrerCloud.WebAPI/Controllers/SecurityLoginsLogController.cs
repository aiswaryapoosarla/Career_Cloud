using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/securityloginslog/v1")]
    [ApiController]
    public class SecurityLoginsLogController : ControllerBase
    {
        private SecurityLoginsLogLogic _sll;

        public SecurityLoginsLogController()
        {
            var repo = new EFGenericRepository<SecurityLoginsLogPoco>();
            _sll = new SecurityLoginsLogLogic(repo);
        }

        [HttpGet]
        [Route("loginslog/all")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginsLogPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllSecurityLoginsLog()
        {
            var res = _sll.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("loginslog/{securityloginslogId}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginsLogPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetSecurityLoginLog(Guid id)
        {
            try
            {
                var res = _sll.Get(id);
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
        [Route("loginslog/{create}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginsLogPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostSecurityLoginLog(SecurityLoginsLogPoco[] poco)
        {
            try
            {
                _sll.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("loginslog/{update}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginsLogPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutSecurityLoginLog(SecurityLoginsLogPoco[] poco)
        {
            try
            {
                _sll.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("loginslog/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<SecurityLoginsLogPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteSecurityLoginLog(SecurityLoginsLogPoco[] poco)
        {
            try
            {
                _sll.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
