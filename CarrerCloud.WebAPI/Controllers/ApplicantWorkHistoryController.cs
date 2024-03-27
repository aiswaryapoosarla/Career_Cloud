using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/workhistory/v1")]
    [ApiController]
    public class ApplicantWorkHistoryController : ControllerBase
    {
        private ApplicantWorkHistoryLogic _aw;

        public ApplicantWorkHistoryController()
        {
            var repo = new EFGenericRepository<ApplicantWorkHistoryPoco>();
            _aw = new ApplicantWorkHistoryLogic(repo);
        }

        [HttpGet]
        [Route("workhistory/all")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantWorkHistoryPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetAllApplicantWorkHistory()
        {
            var res = _aw.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("workhistory/{applicantworkhistoryId}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantWorkHistoryPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult GetApplicantWorkHistory(Guid id)
        {
            try
            {
                var res = _aw.Get(id);
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
        [Route("workhistory/{create}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantWorkHistoryPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostApplicantWorkHistory(ApplicantWorkHistoryPoco[] poco)
        {
            try
            {
                _aw.Add(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("workhistory/{update}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantWorkHistoryPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutApplicantWorkHistory(ApplicantWorkHistoryPoco[] poco)
        {
            try
            {
                _aw.Update(poco);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("workhistory/{delete}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicantWorkHistoryPoco>), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteApplicantWorkHistory(ApplicantWorkHistoryPoco[] poco)
        {
            try
            {
                _aw.Delete(poco);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
