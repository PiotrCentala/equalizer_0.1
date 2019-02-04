using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equalizer
{
    /// <summary>
    /// In this class we store our equation
    /// </summary>
   public  class Equation
    {
        /// <summary>
        /// This is the raw input given by user
        /// </summary>
        public string UserInput { get; set; }
        /// <summary>
        /// Here is the string given by the python function
        /// </summary>
        public string LatexExpression { get; set; }
    }
}
