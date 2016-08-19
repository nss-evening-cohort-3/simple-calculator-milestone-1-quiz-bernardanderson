using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class LastEntries
    {
        public string last { get; set; } = "Nothing Yet!!";
        public string lastq { get; set; } = "Nothing Yet!!";

        public string OutputLastAnswer()
        {
            return $"     {last}";
        }

        public string OutputLastCommand()
        {
            return $"     {lastq}";

        }
    }
}
