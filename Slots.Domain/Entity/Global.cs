using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slots.Domain.Entity
{
    public class Global
    {
        public static int Sum { get; set; } = 0;
        public static int Change { get; set; } = 0;
        public static int ChangePrice { get; set; } = 0;
        public static int Coin1 { get; set; } = 0;
        public static int Coin2 { get; set; } = 0;
        public static int Coin5 { get; set; } = 0;
        public static int Coin10 { get; set; } = 0;
       
        public static bool Login { get; set; } = false;

        
        public static bool BlockOne { get; set; } = false;
        public static bool BlockTwo { get; set; } = false;
        public static bool BlockFive { get; set; } = false;
        public static bool BlockTen { get; set; } = false;

    }
}
