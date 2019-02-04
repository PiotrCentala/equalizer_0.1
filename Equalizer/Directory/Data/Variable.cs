using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equalizer
{
    /// <summary>
    /// This class stores variable 
    /// </summary>
   public class Variable
    {
        /// <summary>
        /// Name of the variable given by user
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Value of the variable given by user
        /// </summary>
        public float Value { get; set; }
        /// <summary>
        /// Latex expression
        /// </summary>
        public string Latex { get { return Structure.VariableToLatex(this.Name, this.Value); }  }

    }
}
