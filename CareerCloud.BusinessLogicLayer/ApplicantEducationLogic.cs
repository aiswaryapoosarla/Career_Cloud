using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        private const int saltLengthLimit = 10;

        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            
            base.Add(pocos);
        }

        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            
            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major))
                {
                    exceptions.Add(new ValidationException(107, $" Major property {poco.Id} cannot be null"));
                }
                else if (poco.Major.Length < 3)
                {
                    exceptions.Add(new ValidationException(107, $"The field length for Major {poco.Id} must be more than 3 characters."));
                }
                

                if (poco.StartDate>DateTime.Now)
                {
                    exceptions.Add(new ValidationException(108, $"StartDate for ApplicantEducation {poco.Id} cannot be greater than today"));
                }
               

                if (string.IsNullOrEmpty(poco.CompletionDate.ToString()))
                {
                    exceptions.Add(new ValidationException(109, $" CompletionDate {poco.Id} cannot be null"));
                }
                else if (string.IsNullOrEmpty(poco.StartDate.ToString()))
                {
                    exceptions.Add(new ValidationException(109, $" StartDate {poco.Id} cannot be null"));
                }

                else if (poco.CompletionDate < poco.StartDate)
                {
                    exceptions.Add(new ValidationException(109,$"CompletionDate for ApplicantEducation {poco.Id} cannot be earlier than StartDate"));
                }
                
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

       

    }
}

