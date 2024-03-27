using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobService : CompanyJob.CompanyJobBase
    {
        private readonly CompanyJobLogic _companyJobLogic;

        public CompanyJobService()
        {
            var repo = new EFGenericRepository<CompanyJobPoco>();
            _companyJobLogic = new CompanyJobLogic(repo);
        }

        public override Task<CompanyJobReply> GetCompanyJob(IdRequestCompanyJob request, ServerCallContext context)
        {
            var companyJob = _companyJobLogic.Get(Guid.Parse(request.Id));

            return Task.FromResult(FromPoco(companyJob));
        }

        private CompanyJobReply FromPoco(CompanyJobPoco poco)
        {
            return new CompanyJobReply()
            {
                Id = poco.Id.ToString(),
                Company = poco.Company.ToString(),
                IsCompanyHidden = poco.IsCompanyHidden,
                IsInactive = poco.IsInactive,
                ProfileCreated = Timestamp.FromDateTime(poco.ProfileCreated)

            };
        }

        public override Task<CompanyJobReply> CreateCompanyJob(CompanyJobPayload request, ServerCallContext context)
        {
            CompanyJobPoco[] pocos = { new CompanyJobPoco()
            {
                Id = Guid.Parse(request.Id),
                Company = Guid.Parse(request.Company),
                IsCompanyHidden = request.IsCompanyHidden,
                IsInactive = request.IsInactive,
                ProfileCreated = request.ProfileCreated.ToDateTime()
            } };
            _companyJobLogic.Add(pocos);
            return new Task<CompanyJobReply>(() => new CompanyJobReply());
        }

        public override Task<CompanyJobReply> UpdateCompanyJob(CompanyJobPayload request, ServerCallContext context)
        {
            CompanyJobPoco[] pocos = { new CompanyJobPoco()
            {
               Id = Guid.Parse(request.Id),
                Company = Guid.Parse(request.Company),
                IsCompanyHidden = request.IsCompanyHidden,
                IsInactive = request.IsInactive,
                ProfileCreated = request.ProfileCreated.ToDateTime()
            } };
            _companyJobLogic.Update(pocos);
            return new Task<CompanyJobReply>(() => new CompanyJobReply());
        }

        public override Task<CompanyJobReply> DeleteCompanyJob(CompanyJobPayload request, ServerCallContext context)
        {
            CompanyJobPoco poco = _companyJobLogic.Get(Guid.Parse(request.Id));
            _companyJobLogic.Delete(new CompanyJobPoco[] { poco });
            return new Task<CompanyJobReply>(() => new CompanyJobReply());
        }
    }
}




