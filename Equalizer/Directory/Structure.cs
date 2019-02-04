using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equalizer
{
    /// <summary>
    ///  Here is all the logic behind our data (ecept the python code for generating equations) 
    /// </summary>
    static class Structure
    {
        /// <summary>
        /// Only for tests, 
        /// </summary>
        /// <returns></returns>
        public static List<Variable> InitializeList()
        {
            var a = new Variable();
            a.Name = "test";
            a.Value = 12;
            
            var List = new List<Variable>();
            List.Add(a);
            List.Add(a);
            List.Add(a);
            return List;

        }
        /// <summary>
        /// When button cicked this function fires, it set it to return list but i dont know why i did that 
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="List"></param>
        /// <returns></returns>
        public static List<Variable> UpdateList(Variable Input, List<Variable> List)
        {
            
            List.Add(Input);
            return List;
        }
        /// <summary>
        /// Function converts Variables to Latex form
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
       public static string VariableToLatex(string name, float value)
        {
            string a = name + "=" + value.ToString();
            return a;
        }
       
    }
}
