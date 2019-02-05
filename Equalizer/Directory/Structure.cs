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
    ///  Here is all the logic behind our data (except the python code for generating equations) 
    /// </summary>
    static class Structure
    {
        /// <summary>
        /// Initialization with first vairable for tests, 
        /// </summary>
        /// <returns></returns>
        public static List<Variable> InitializeList()
        {
            var a = new Variable();
            a.Name = "test";
            a.Value = 12;
            
            var List = new List<Variable>();
            
           
            List.Add(a);
            return List;

        }
        /// <summary>
        /// This function adds vvariable to a list
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="List"></param>
        /// <returns></returns>
        public static List<Variable> UpdateList(Variable Input, List<Variable> List)
        {
            if (Input.Name!=null)
            List.Add(Input);
            return List;
        }
        
        public static List<Variable> DeleteFromList(Variable Input, List<Variable> List)
        {
            if (Input.Name != null)
                List.Remove(Input);
            return List;
        }
   
    }
}
