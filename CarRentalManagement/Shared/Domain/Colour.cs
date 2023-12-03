using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Shared.Domain
{
    public class Colour : BaseDomainModel
    {
        public string? Name { get; set; }
        //Additionally, the use of ? after string (string?) indicates that the property can be nullable. In C# 8.0 and later, you can use nullable reference types, and adding
        //? to a reference type explicitly allows it to be assigned the value null
    }
}
