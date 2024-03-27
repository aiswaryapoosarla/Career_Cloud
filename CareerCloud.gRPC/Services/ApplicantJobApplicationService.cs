using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantJobApplicationService : ApplicantJobApplication.ApplicantJobApplicationBase
    {
        private readonly ApplicantJobApplicationLogic _applicantJobApplicationLogic;

        public ApplicantJobApplicationService()
        {
            var repo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            _applicantJobApplicationLogic = new ApplicantJobApplicationLogic(repo);
        }

        public override Task<ApplicantJobApplicationReply> GetApplicantJobApplication(IdRequestApplicantJobApplication request, ServerCallContext context)
        {
            var applicantEducation = _applicantJobApplicationLogic.Get(Guid.Parse(request.Id));

            return Task.FromResult(FromPoco(applicantJobApplication));
        }

        private ApplicantJobApplicationReply FromPoco(ApplicantJobApplicationPoco poco)
        {
            return new ApplicantJobApplicationReply()
            {
                Id = poco.Id.ToString(),
                Applicant = poco.Applicant.ToString(),
                Job = poco.Job.ToString(),
                ApplicationDate = Timestamp.FromDateTime(poco.ApplicationDate)

            };
        }

        public override Task<ApplicantJobApplicationReply> CreateApplicantJobApplication(ApplicantJobApplicationPayload request, ServerCallContext context)
        {
            ApplicantJobApplicationPoco[] pocos = { new ApplicantJobApplicationPoco()
            {
                Id = Guid.Parse(request.Id),
                Applicant = Guid.Parse(request.Applicant),
                Job = Guid.Parse(request.Job),
                ApplicationDate = request.ApplicationDate.ToDateTime()
            } };
            _applicantJobApplicationLogic.Add(pocos);
            return new Task<ApplicantJobApplicationReply>(() => new ApplicantJobApplicationReply());
        }

        public override Task<ApplicantJobApplicationReply> UpdateApplicantJobApplication(ApplicantJobApplicationPayload request, ServerCallContext context)
        {
            ApplicantJobApplicationPoco[] pocos = { new ApplicantJobApplicationPoco()
            {
                Id = Guid.Parse(request.Id),
                Applicant = Guid.Parse(request.Applicant),
                Job = Guid.Parse(request.Job),
                ApplicationDate = request.ApplicationDate.ToDateTime()
            } };
            _applicantJobApplicationLogic.Update(pocos);
            return new Task<ApplicantJobApplicationReply>(() => new ApplicantJobApplicationReply());
        }

        public override Task<ApplicantJobApplicationReply> DeleteApplicantJobApplication(ApplicantJobApplicationPayload request, ServerCallContext context)
        {
            ApplicantJobApplicationPoco poco = _applicantJobApplicationLogic.Get(Guid.Parse(request.Id));
            _applicantJobApplicationLogic.Delete(new ApplicantJobApplicationPoco[] { poco });
            return new Task<ApplicantJobApplicationReply>(() => new ApplicantJobApplicationReply());
        }
    }
}
