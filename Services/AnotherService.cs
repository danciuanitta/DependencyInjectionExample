using DependencyInjectionSample.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Services
{
    public class AnotherService : IAnotherService
    {
        private readonly IExampleRepository _repo;
        public AnotherService(IExampleRepository repo)
        {
            _repo = repo;
        }

        public int GetSomeNumber()
        {
            return _repo.GetNumber();
        }
    }
}
