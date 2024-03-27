using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/systemlanguagecode/v1")]
    [ApiController]
    public class SystemLanguageCodeController : ControllerBase
    {
        private SystemLanguageCodeLogic _slc;

        public SystemLanguageCodeController()
        {
            var repo = new EFGenericRepository<SystemLanguageCodePoco>();
            _slc = new SystemLanguageCodeLogic(repo);
        }

        [HttpGet]
        [Route("languagecode/all")]
        [ProducesResponseType(typeof(IEnumerable<SystemLanguageCodePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllSystemLanguageCode()
        {
            var res = _slc.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("languagecode/{systemlanguagecodeLanguageID}")]
        [ProducesResponseType(typeof(IEnumerable<SystemLanguageCodePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetSystemLanguageCode(string LanguageID)
        {
            try
            {
                var res = _slc.Get(LanguageID);
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
        [Route("languagecode/{create}")]
        [ProducesResponseType(typeof(IEnumerable<SystemLanguageCodePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostSystemLanguageCode(SystemLanguageCodePoco[] poco)
        {
            try
            {
                _slc.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("languagecode/{update}")]
        [ProducesResponseType(typeof(IEnumerable<SystemLanguageCodePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutSystemLanguageCode(SystemLanguageCodePoco[] poco)
        {
            try
            {
                _slc.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("languagecode/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<SystemLanguageCodePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteSystemLanguageCode(SystemLanguageCodePoco[] poco)
        {
            try
            {
                _slc.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
