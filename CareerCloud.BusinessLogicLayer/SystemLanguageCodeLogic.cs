using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic
    {
        protected IDataRepository<SystemLanguageCodePoco> _dataRepository;
        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository)
        {
            _dataRepository = repository;
        }

        public void Add(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            _dataRepository.Add(pocos);
        }

        public void Update(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            _dataRepository.Update(pocos);
        }

        public SystemLanguageCodePoco Get(string langId)
        {
            return _dataRepository.GetSingle(c => c.LanguageID == langId);
        }

        public List<SystemLanguageCodePoco> GetAll()
        {
            return _dataRepository.GetAll().ToList();
        }


        public void Delete(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            _dataRepository.Update(pocos);
        }

        protected void Verify(SystemLanguageCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.LanguageID))
                {
                    exceptions.Add(new ValidationException(1000, $"Language ID {poco.LanguageID} cannot be null or empty"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(1001, $"Name {poco.Name} cannot be null or empty"));
                }
                if (string.IsNullOrEmpty(poco.NativeName))
                {
                    exceptions.Add(new ValidationException(1002, $"Native Name {poco.NativeName} cannot be null or empty"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }

        public object Get(Guid guid)
        {
            throw new NotImplementedException();
        }

        public object Get(object value)
        {
            throw new NotImplementedException();
        }
    }
}
