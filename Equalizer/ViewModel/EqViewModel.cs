using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Equalizer
{
    /// <summary>
    /// In this class we put all ViewModels 
    /// </summary>
    public class EqViewModel : BaseViewModel
    {
        /// <summary>
        /// In here all the objects are created
        /// </summary>
        public EqViewModel()
        {

                     
            
                        
        }

        /// <summary>
        /// Input given by user
        /// </summary>
        public string EquationInput { get; set; }
        /// <summary>
        /// output from python sympy function 
        /// </summary>
        public string EquationOuptut { get; set; }
   

        /// <summary>
        /// list containing all equations given by user
        /// </summary>
        public ObservableCollection<Equation> EquationsList { get; set; }
      

        
    }
}
