using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantEducationService:ApplicantEducation.ApplicantEducationBase
    {
        private readonly ApplicantEducationLogic _applicantEducationLogic;

        public ApplicantEducationService()
        {
            var repo = new EFGenericRepository<ApplicantEducationPoco>();
           _applicantEducationLogic = new ApplicantEducationLogic(repo);
        }

        public override Task<ApplicantEducationReply> GetApplicantEducation(IdRequestApplicantEducation request, ServerCallContext context)
        {
            var applicantEducation = _applicantEducationLogic.Get(Guid.Parse(request.Id));

            return Task.FromResult(FromPoco(applicantEducation));
        }

        private ApplicantEducationReply FromPoco(ApplicantEducationPoco poco)
        {
            return new ApplicantEducationReply()
            {
                Id = poco.Id.ToString(),
                Applicant = poco.Applicant.ToString(),
                Major = poco.Major,
                CertificateDiploma = poco.CertificateDiploma,
                StartDate = poco.StartDate == null ? null :
        Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.StartDate, DateTimeKind.Utc)),

                CompletionDate = poco.CompletionDate == null ? null :
        Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.CompletionDate, DateTimeKind.Utc)),

                CompletionPercent = (byte)poco.CompletionPercent,
                
            };
        }

        public override Task<ApplicantEducationReply> CreateApplicantEducation(ApplicantEducationPayload request, ServerCallContext context)
        {
            ApplicantEducationPoco[] pocos = { new ApplicantEducationPoco()
            {
                Id = Guid.Parse(request.Id),
                Applicant = Guid.Parse(request.Applicant),
                Major = request.Major,
                CertificateDiploma = request.CertificateDiploma,
                CompletionDate = request.CompletionDate.ToDateTime(),
                CompletionPercent = (byte?)request.CompletionPercent,
                StartDate = request.StartDate.ToDateTime()
            } };
            _applicantEducationLogic.Add(pocos);
            return new Task<ApplicantEducationReply>(() => new ApplicantEducationReply());
        }

        public override Task<ApplicantEducationReply> UpdateApplicantEducation(ApplicantEducationPayload request, ServerCallContext context)
        {
            ApplicantEducationPoco[] pocos = { new ApplicantEducationPoco()
            {
                Id = Guid.Parse(request.Id),
                Applicant = Guid.Parse(request.Applicant),
                Major = request.Major,
                CertificateDiploma = request.CertificateDiploma,
                CompletionDate = request.CompletionDate.ToDateTime(),
                CompletionPercent = (byte?)request.CompletionPercent,
                StartDate = request.StartDate.ToDateTime()
            } };
            _applicantEducationLogic.Update(pocos);
            return new Task<ApplicantEducationReply>(() => new ApplicantEducationReply());
        }

        public override Task<ApplicantEducationReply> DeleteApplicantEducation(ApplicantEducationPayload request, ServerCallContext context)
        {
            ApplicantEducationPoco poco = _applicantEducationLogic.Get(Guid.Parse(request.Id));
            _applicantEducationLogic.Delete(new ApplicantEducationPoco[] { poco });
            return new Task<ApplicantEducationReply>(() => new ApplicantEducationReply());
        }
    }
}
