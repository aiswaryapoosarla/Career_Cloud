using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobEducationService : CompanyJobEducation.CompanyJobEducationBase
    {
        private readonly CompanyJobEducationLogic _companyJobEducationLogic;

        public CompanyJobEducationService()
        {
            var repo = new EFGenericRepository<CompanyJobEducationPoco>();
            _companyJobEducationLogic = new CompanyJobEducationLogic(repo);
        }

        public override Task<CompanyJobEducationReply> GetCompanyJobEducation(IdRequestCompanyJobEducation request, ServerCallContext context)
        {
            var companyJobEducation = _companyJobEducationLogic.Get(Guid.Parse(request.Id));

            return Task.FromResult(FromPoco(companyJobEducation));
        }

        private CompanyJobEducationReply FromPoco(CompanyJobEducationPoco poco)
        {
            return new CompanyJobEducationReply()
            {
                Id = poco.Id.ToString(),
                Job = poco.Job.ToString(),
                Importance = poco.Importance,
                Major = poco.Major

            };
        }

        public override Task<CompanyJobEducationReply> CreateCompanyJobEducation(CompanyJobEducationPayload request, ServerCallContext context)
        {
            CompanyJobEducationPoco[] pocos = { new CompanyJobEducationPoco()
            {
                 Id = Guid.Parse(request.Id),
                Job = Guid.Parse(request.Job),
                Importance = (short)request.Importance,
                Major = request.Major
            } };
            _companyJobEducationLogic.Add(pocos);
            return new Task<CompanyJobEducationReply>(() => new CompanyJobEducationReply());
        }

        public override Task<CompanyJobEducationReply> UpdateCompanyJobEducation(CompanyJobEducationPayload request, ServerCallContext context)
        {
            CompanyJobEducationPoco[] pocos = { new CompanyJobEducationPoco()
            {
                Id = Guid.Parse(request.Id),
                Job = Guid.Parse(request.Job),
                Importance = (short)request.Importance,
                Major = request.Major
            } };
            _companyJobEducationLogic.Update(pocos);
            return new Task<CompanyJobEducationReply>(() => new CompanyJobEducationReply());
        }

        public override Task<CompanyJobEducationReply> DeleteCompanyJobEducation(CompanyJobEducationPayload request, ServerCallContext context)
        {
            CompanyJobEducationPoco poco = _companyJobEducationLogic.Get(Guid.Parse(request.Id));
            _companyJobEducationLogic.Delete(new CompanyJobEducationPoco[] { poco });
            return new Task<CompanyJobEducationReply>(() => new CompanyJobEducationReply());
        }
    }
}



