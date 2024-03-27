using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services
{
    public class CompanyDescriptionService : CompanyDescription.CompanyDescriptionBase
    {
        private readonly CompanyDescriptionLogic _companyDescriptionLogic;

        public CompanyDescriptionService()
        {
            var repo = new EFGenericRepository<CompanyDescriptionPoco>();
            _companyDescriptionLogic = new CompanyDescriptionLogic(repo);
        }

        public override Task<CompanyDescriptionReply> GetCompanyDescription(IdRequestCompanyDescription request, ServerCallContext context)
        {
            var companyDescription = _companyDescriptionLogic.Get(Guid.Parse(request.Id));

            return Task.FromResult(FromPoco(companyDescription));
        }

        private CompanyDescriptionReply FromPoco(CompanyDescriptionPoco poco)
        {
            return new CompanyDescriptionReply()
            {
                Id = poco.Id.ToString(),
                Company = poco.Company.ToString(),
                CompanyName = poco.CompanyName,
                CompanyDescription = poco.CompanyDescription,
                LanguageId = poco.LanguageId

            };
        }

        public override Task<CompanyDescriptionReply> CreateCompanyDescription(CompanyDescriptionPayload request, ServerCallContext context)
        {
            CompanyDescriptionPoco[] pocos = { new CompanyDescriptionPoco()
            {
                Id = Guid.Parse(request.Id),
                Company = Guid.Parse(request.Company),
                CompanyDescription = request.CompanyDescription,
                CompanyName = request.CompanyName,
                LanguageId = request.LanguageId
            } };
            _companyDescriptionLogic.Add(pocos);
            return new Task<CompanyDescriptionReply>(() => new CompanyDescriptionReply());
        }

        public override Task<CompanyDescriptionReply> UpdateCompanyDescription(CompanyDescriptionPayload request, ServerCallContext context)
        {
            CompanyDescriptionPoco[] pocos = { new CompanyDescriptionPoco()
            { Id = Guid.Parse(request.Id),
                Company = Guid.Parse(request.Company),
                CompanyDescription = request.CompanyDescription,
                CompanyName = request.CompanyName,
                LanguageId = request.LanguageId
            } };
            _companyDescriptionLogic.Update(pocos);
            return new Task<CompanyDescriptionReply>(() => new CompanyDescriptionReply());
        }

        public override Task<CompanyDescriptionReply> DeleteCompanyDescription(CompanyDescriptionPayload request, ServerCallContext context)
        {
            CompanyDescriptionPoco poco = _companyDescriptionLogic.Get(Guid.Parse(request.Id));
            _companyDescriptionLogic.Delete(new CompanyDescriptionPoco[] { poco });
            return new Task<CompanyDescriptionReply>(() => new CompanyDescriptionReply());
        }
    }
}


