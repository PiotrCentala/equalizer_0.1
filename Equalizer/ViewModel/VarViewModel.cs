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
    public class VarViewModel :BaseViewModel
    {
        /// <summary>
        /// In here all the objects are created
        /// </summary>
        public VarViewModel()
        {
            
            
            VariableInput = new Variable();
            LatexTest = new string('a',1);
            LatexTest = "a_12=12";


            VariablesList = new ObservableCollection<Variable>(Structure.InitializeList());
        }
        public string LatexTest { get; set; }
        /// <summary>
        /// Input given by user
        /// </summary>
        public string EquationInput { get; set; }
        /// <summary>
        /// output from python sympy function 
        /// </summary>
        public string EquationOuptut { get; set; }
        /// <summary>
        /// List containig all equations given bys user 
        /// </summary>
        public Variable VariableInput { get; set; }

        /// <summary>
        /// It indicates witch variable has to be deleted 
        /// </summary>
        public Variable SelectedVar { get; set; }

        /// <summary>
        /// list containing all equations given by user
        /// </summary>
        public ObservableCollection<Equation> EquationsList { get; set; }
        /// <summary>
        /// list containing all variables given by user
        /// </summary>
        public ObservableCollection<Variable> VariablesList { get; set; }
        
        /// <summary>
        /// handling response for private _clickCommand question, triggers Action
        /// </summary>                 
        public ICommand ClickCommand { get { return new CommandHandler(() => ButtonClicked()); } }
       
        
        public ICommand DeleteCommand { get { return new CommandHandler(() => DeleteItem()); } }

        /// <summary>
        /// Action triggered when button clicked
        /// </summary>
        public void ButtonClicked()
        {
            
            //List<float> list = new List<float>(new float[]{ 460, 12, 420, 5 });
            //PythonFun.RunPython("pi*((dk+a)^2-(d1+2*r)^2)/4",list, "dk+a+d1+r", 6);
            VariablesList.Add( Structure.UpdateList(VariableInput, VariablesList.ToList()).Last());
            VariableInput = new Variable();
        }
        public void DeleteItem()
        {
         this.VariablesList.Remove(this.SelectedVar);
        }
    }
}
