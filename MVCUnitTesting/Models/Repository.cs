using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCUnitTesting.Models
{
    public interface Repository
    {
        List<Product> GetAll();
    }
}
