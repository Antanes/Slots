using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slots.Domain.Entity
{
    public class Drink
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public byte[]? Avatar { get; set; }
        


    }
}
