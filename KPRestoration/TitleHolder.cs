using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPRestoration
{
    class TitleHolder : Customer
    {
        // Members
        private int fee;
        private string feeType;

        // Getters and setters
        public int Fee { get => fee; set => fee = value; }
        public string FeeType { get => feeType; set => feeType = value; }
    }
}
