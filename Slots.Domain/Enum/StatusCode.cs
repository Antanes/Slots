using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slots.Domain.Enum
{
    public enum StatusCode
    {
        

        DrinkNotFound = 10,
        DrinksAreOut = 11,


        OK = 200,
        InternalServerError = 500
    }
}
