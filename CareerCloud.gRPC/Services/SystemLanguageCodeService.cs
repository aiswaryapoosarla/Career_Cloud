using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services
{
    public class SystemLanguageCodeService : SystemLanguageCode.SystemLanguageCodeBase
    {
        private readonly SystemLanguageCodeLogic _systemLanguageCodeLogic;

        public SystemLanguageCodeService()
        {
            var repo = new EFGenericRepository<SystemLanguageCodePoco>();
            _systemLanguageCodeLogic = new SystemLanguageCodeLogic(repo);
        }

        public override Task<SystemLanguageCodeReply> GetSystemLanguageCodeLog(IdRequestSystemLanguageCode request, ServerCallContext context)
        {
            var systemLanguageCode = _systemLanguageCodeLogic.Get(Guid.Parse(request.Id));

            return Task.FromResult(FromPoco(systemLanguageCode));
        }

        private SystemLanguageCodeReply FromPoco(SystemLanguageCodePoco poco)
        {
            return new SystemLanguageCodeReply()
            {
                LanguageID = poco.LanguageID,
                Name = poco.Name,
                NativeName = poco.NativeName

            };
        }

        public override Task<SystemLanguageCodeReply> CreateSystemLanguageCode(SystemLanguageCodePayload request, ServerCallContext context)
        {
            SystemLanguageCodePoco[] pocos = { new SystemLanguageCodePoco()
            {
                LanguageID = request.LanguageID,
                Name = request.Name,
                NativeName= request.NativeName
            } };
            _systemLanguageCodeLogic.Add(pocos);
            return new Task<SystemLanguageCodeReply>(() => new SystemLanguageCodeReply());
        }

        public override Task<SystemLanguageCodeReply> UpdateSystemLanguageCode(SystemLanguageCodePayload request, ServerCallContext context)
        {
            SystemLanguageCodePoco[] pocos = { new SystemLanguageCodePoco()
            {
               LanguageID = request.LanguageID,
                Name = request.Name,
                NativeName= request.NativeName
            } };
            _systemLanguageCodeLogic.Update(pocos);
            return new Task<SystemLanguageCodeReply>(() => new SystemLanguageCodeReply());
        }

        public override Task<SystemLanguageCodeReply> DeleteSystemLanguageCode(SystemLanguageCodePayload request, ServerCallContext context)
        {
            SystemLanguageCodePoco poco = _systemLanguageCodeLogic.Get(Guid.Parse(request.Id));
            _systemLanguageCodeLogic.Delete(new SystemLanguageCodePoco[] { poco });
            return new Task<SystemLanguageCodeReply>(() => new SystemLanguageCodeReply());
        }
    }
}







