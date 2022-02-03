using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.DAL
{
    public class ExampleRepository : IExampleRepository
    {
        public ExampleRepository()
        {
            //follow this constructor to see how many times it is called depending on it's lifetime
        }
        public int GetNumber()
        {
            return 1;
        }
    }
}
