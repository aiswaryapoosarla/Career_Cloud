using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginService : SecurityLogin.SecurityLoginBase
    {
        private readonly SecurityLoginLogic _securityLoginLogic;

        public SecurityLoginService()
        {
            var repo = new EFGenericRepository<SecurityLoginPoco>();
            _securityLoginLogic = new SecurityLoginLogic(repo);
        }

        public override Task<SecurityLoginReply> GetSecurityLogin(IdRequestSecurityLogin request, ServerCallContext context)
        {
            var securityLogin = _securityLoginLogic.Get(Guid.Parse(request.Id));

            return Task.FromResult(FromPoco(securityLogin));
        }

        private SecurityLoginReply FromPoco(SecurityLoginPoco poco)
        {
            return new SecurityLoginReply()
            {
                Id = poco.Id.ToString(),
                Login = poco.Login,
                Password = poco.Password,
                Created = Timestamp.FromDateTime(poco.Created),
                PasswordUpdate = poco.PasswordUpdate is null ? null : Timestamp.FromDateTime((DateTime)poco.PasswordUpdate),
                AgreementAccepted = poco.AgreementAccepted is null ? null : Timestamp.FromDateTime((DateTime)poco.AgreementAccepted),
                IsLocked = poco.IsLocked,
                IsInactive = poco.IsInactive,
                EmailAddress = poco.EmailAddress,
                PhoneNumber = poco.PhoneNumber,
                FullName = poco.FullName,
                ForceChangePassword = poco.ForceChangePassword,
                PrefferredLanguage = poco.PrefferredLanguage

            };
        }

        public override Task<SecurityLoginReply> CreateSecurityLogin(SecurityLoginPayload request, ServerCallContext context)
        {
            SecurityLoginPoco[] pocos = { new SecurityLoginPoco()
            {
               Id = Guid.Parse(request.Id),
                Login = request.Login,
                Password = request.Password,
                Created = request.Created.ToDateTime(),
                PasswordUpdate = request.Created.ToDateTime(),
                AgreementAccepted = request.AgreementAccepted.ToDateTime(),
                IsLocked = request.IsLocked,
                IsInactive = request.IsInactive,
                EmailAddress = request.EmailAddress,
                PhoneNumber = request.PhoneNumber,
                FullName = request.FullName,
                ForceChangePassword = request.ForceChangePassword,
                PrefferredLanguage = request.PrefferredLanguage
            } };
            _securityLoginLogic.Add(pocos);
            return new Task<SecurityLoginReply>(() => new SecurityLoginReply());
        }

        public override Task<SecurityLoginReply> UpdateSecurityLogin(SecurityLoginPayload request, ServerCallContext context)
        {
            SecurityLoginPoco[] pocos = { new SecurityLoginPoco()
            {
               Id = Guid.Parse(request.Id),
                Login = request.Login,
                Password = request.Password,
                Created = request.Created.ToDateTime(),
                PasswordUpdate = request.Created.ToDateTime(),
                AgreementAccepted = request.AgreementAccepted.ToDateTime(),
                IsLocked = request.IsLocked,
                IsInactive = request.IsInactive,
                EmailAddress = request.EmailAddress,
                PhoneNumber = request.PhoneNumber,
                FullName = request.FullName,
                ForceChangePassword = request.ForceChangePassword,
                PrefferredLanguage = request.PrefferredLanguage
            } };
            _securityLoginLogic.Update(pocos);
            return new Task<SecurityLoginReply>(() => new SecurityLoginReply());
        }

        public override Task<SecurityLoginReply> DeleteSecurityLogin(SecurityLoginPayload request, ServerCallContext context)
        {
            SecurityLoginPoco poco = _securityLoginLogic.Get(Guid.Parse(request.Id));
            _securityLoginLogic.Delete(new SecurityLoginPoco[] { poco });
            return new Task<SecurityLoginReply>(() => new SecurityLoginReply());
        }
    }
}





