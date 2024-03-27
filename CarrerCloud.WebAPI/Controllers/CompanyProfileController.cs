using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{

    [Route("api/careercloud/companyprofile/v1")]
    [ApiController]
    public class CompanyProfileController : ControllerBase
    {
        private CompanyProfileLogic _cp;

        public CompanyProfileController()
        {
            var repo = new EFGenericRepository<CompanyProfilePoco>();
            _cp = new CompanyProfileLogic(repo);
        }

        [HttpGet]
        [Route("profile/all")]
        [ProducesResponseType(typeof(IEnumerable<CompanyProfilePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllCompanyProfile()
        {
            var res = _cp.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("profile/{companyprofileId}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyProfilePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetCompanyProfile(Guid id)
        {
            try
            {
                var res = _cp.Get(id);
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
        [Route("profile/{create}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyProfilePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostCompanyProfile(CompanyProfilePoco[] poco)
        {
            try
            {
                _cp.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("profile/{update}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyProfilePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutCompanyProfile(CompanyProfilePoco[] poco)
        {
            try
            {
                _cp.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("profile/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<CompanyProfilePoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteCompanyProfile(CompanyProfilePoco[] poco)
        {
            try
            {
                _cp.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
