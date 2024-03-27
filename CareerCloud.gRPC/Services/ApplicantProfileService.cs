using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantProfileService : ApplicantProfile.ApplicantProfileBase
    {
        private readonly ApplicantProfileLogic _applicantProfileLogic;

        public ApplicantProfileService()
        {
            var repo = new EFGenericRepository<ApplicantProfilePoco>();
            _applicantProfileLogic = new ApplicantProfileLogic(repo);
        }

        public override Task<ApplicantProfileReply> GetApplicantProfile(IdRequestApplicantProfile request, ServerCallContext context)
        {
            var applicantprofile = _applicantProfileLogic.Get(Guid.Parse(request.Id));

            return Task.FromResult(FromPoco(applicantProfile));
        }

        private ApplicantProfileReply FromPoco(ApplicantprofilePoco poco)
        {
            return new ApplicantProfileReply()
            {
                Id = poco.Id.ToString(),
                Login = poco.Login.ToString(),
                Street = poco.Street,
                City = poco.City,
                Province = poco.Province,
                PostalCode = poco.PostalCode,
                Country = poco.Country,
                Currency = poco.Currency,
                CurrentRate = (double?)poco.CurrentRate,
                CurrentSalary = (double?)poco.CurrentSalary

            };
        }

        public override Task<ApplicantProfileReply> CreateApplicantProfile(ApplicantProfilePayload request, ServerCallContext context)
        {
            ApplicantProfilePoco[] pocos = { new ApplicantProfilePoco()
            {
                Id = Guid.Parse(request.Id),
                CurrentSalary = (decimal?)request.CurrentSalary,
                CurrentRate = (decimal?)request.CurrentRate,
                Currency = request.Currency,
                Street =request.Street,
                City = request.City,
                Province = request.Province,
                Country = request.Country,
                PostalCode=request.PostalCode,
                Login = Guid.Parse(request.Login)
            } };
            _applicantProfileLogic.Add(pocos);
            return new Task<ApplicantProfileReply>(() => new ApplicantProfileReply());
        }

        public override Task<ApplicantProfileReply> UpdateApplicantProfile(ApplicantProfilePayload request, ServerCallContext context)
        {
            ApplicantProfilePoco[] pocos = { new ApplicantProfilePoco()
            {
                Id = Guid.Parse(request.Id),
                CurrentSalary = (decimal?)request.CurrentSalary,
                CurrentRate = (decimal?)request.CurrentRate,
                Currency = request.Currency,
                Street =request.Street,
                City = request.City,
                Province = request.Province,
                Country = request.Country,
                PostalCode=request.PostalCode,
                Login = Guid.Parse(request.Login)
            } };
            _applicantProfileLogic.Update(pocos);
            return new Task<ApplicantProfileReply>(() => new ApplicantProfileReply());
        }

        public override Task<ApplicantProfileReply> DeleteApplicantProfile(ApplicantProfilePayload request, ServerCallContext context)
        {
            ApplicantProfilePoco poco = _applicantProfileLogic.Get(Guid.Parse(request.Id));
            _applicantProfileLogic.Delete(new ApplicantProfilePoco[] { poco });
            return new Task<ApplicantProfileReply>(() => new ApplicantProfileReply());
        }
    }
}

