using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginsLogService : SecurityLoginsLog.SecurityLoginsLogBase
    {
        private readonly SecurityLoginsLogLogic _securityLoginsLogLogic;

        public SecurityLoginsLogService()
        {
            var repo = new EFGenericRepository<SecurityLoginsLogPoco>();
            _securityLoginsLogLogic = new SecurityLoginsLogLogic(repo);
        }

        public override Task<SecurityLoginsLogReply> GetSecurityLoginsLog(IdRequestSecurityLoginsLog request, ServerCallContext context)
        {
            var securityLoginsLog = _securityLoginsLogLogic.Get(Guid.Parse(request.Id));

            return Task.FromResult(FromPoco(securityLoginsLog));
        }

        private SecurityLoginsLogReply FromPoco(SecurityLoginsLogPoco poco)
        {
            return new SecurityLoginsLogReply()
            {
                Id = poco.Id.ToString(),
                Login = poco.Id.ToString(),
                SourceIP = poco.SourceIP,
                LogonDate = Timestamp.FromDateTime(poco.LogonDate),
                IsSuccesful = poco.IsSuccesful

            };
        }

        public override Task<SecurityLoginsLogReply> CreateSecurityLoginsLog(SecurityLoginsLogPayload request, ServerCallContext context)
        {
            SecurityLoginsLogPoco[] pocos = { new SecurityLoginsLogPoco()
            {
               Id = Guid.Parse(request.Id),
                Login = Guid.Parse(request.Login),
                SourceIP = request.SourceIP,
                LogonDate = request.LogonDate.ToDateTime(),
                IsSuccesful = request.IsSuccesful
            } };
            _securityLoginsLogLogic.Add(pocos);
            return new Task<SecurityLoginsLogReply>(() => new SecurityLoginsLogReply());
        }

        public override Task<SecurityLoginsLogReply> UpdateSecurityLoginsLog(SecurityLoginsLogPayload request, ServerCallContext context)
        {
            SecurityLoginsLogPoco[] pocos = { new SecurityLoginsLogPoco()
            {
               Id = Guid.Parse(request.Id),
                Login = Guid.Parse(request.Login),
                SourceIP = request.SourceIP,
                LogonDate = request.LogonDate.ToDateTime(),
                IsSuccesful = request.IsSuccesful
            } };
            _securityLoginsLogLogic.Update(pocos);
            return new Task<SecurityLoginsLogReply>(() => new SecurityLoginsLogReply());
        }

        public override Task<SecurityLoginsLogReply> DeleteSecurityLoginsLog(SecurityLoginsLogPayload request, ServerCallContext context)
        {
            SecurityLoginsLogPoco poco = _securityLoginsLogLogic.Get(Guid.Parse(request.Id));
            _securityLoginsLogLogic.Delete(new SecurityLoginsLogPoco[] { poco });
            return new Task<SecurityLoginsLogReply>(() => new SecurityLoginsLogReply());
        }
    }
}






