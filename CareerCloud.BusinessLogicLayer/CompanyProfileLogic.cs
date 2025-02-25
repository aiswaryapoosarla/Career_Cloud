﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {

        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {

        }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);

            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {

                if (!string.IsNullOrEmpty(poco.CompanyWebsite))
                {
                    string extension = "";
                    string[] website = poco.CompanyWebsite.Split('.');

                    extension = "." + website[website.Length - 1];

                    if (extension != ".ca" || extension != ".com" || extension != ".biz")
                    {
                        exceptions.Add(new ValidationException(600, $"Valid websites must end with the following extensions - .ca, .com, .biz"));
                    }
                }
                else
                {
                    exceptions.Add(new ValidationException(600, $"Website address cannot be null"));

                }

                if (!string.IsNullOrEmpty(poco.ContactPhone))
                {
                    var phone = poco.ContactPhone.Replace("-", "");

                    if (phone.ToString().Length < 10)
                    {
                        exceptions.Add(new ValidationException(601, $"Must correspond to a valid phone number (e.g. 416-555-1234)"));
                    }
                }
                else
                {
                    exceptions.Add(new ValidationException(601, $"Contact phone number cannot be null"));
                }

            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }


    }
}
