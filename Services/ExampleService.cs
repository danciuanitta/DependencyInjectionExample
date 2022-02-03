using DependencyInjectionSample.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Services
{
    public class ExampleService : IExampleService
    {
        private readonly IExampleRepository _repo;
        public ExampleService(IExampleRepository repo)
        {
            _repo = repo;
        }

        public int GetNumber()
        {
            return _repo.GetNumber();
        }
    }
}
