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
           


            VariablesList = new ObservableCollection<Variable>(Structure.InitializeList());
        }
        
        
        /// <summary>
        /// Input Variable given bys user 
        /// </summary>
        public Variable VariableInput { get; set; }

        /// <summary>
        /// It indicates witch variable has to be deleted 
        /// </summary>
        public Variable SelectedVar { get; set; }

       
        /// <summary>
        /// list containing all variables given by user
        /// </summary>
        public ObservableCollection<Variable> VariablesList { get; set; }
        
        /// <summary>
        /// handling response for sumbit button (add variable) clicked, triggers Action
        /// </summary>                 
        public ICommand ClickCommand { get { return new CommandHandler(() => ButtonClicked()); } }
       
        /// <summary>
        /// When delete button clicked t triggers DeleteItem method
        /// </summary>
        public ICommand DeleteCommand { get { return new CommandHandler(() => DeleteItem()); } }

        /// <summary>
        /// Action triggered when submit button (add new variable) clicked
        /// </summary>
        public void ButtonClicked()
        {

            //List<float> list = new List<float>(new float[]{ 460, 12, 420, 5 });
            //PythonFun.RunPython("pi*((dk+a)^2-(d1+2*r)^2)/4",list, "dk+a+d1+r", 6);
            if (this.VariableInput.Name != null)
                this.VariablesList = new ObservableCollection<Variable>(Structure.UpdateList(this.VariableInput,this.VariablesList.ToList()));
            this.VariableInput = new Variable();
        }
        /// <summary>
        /// When User clicks delete buton this method is called
        /// </summary>
        public void DeleteItem()
        {
         
            this.VariablesList = new ObservableCollection<Variable>(Structure.DeleteFromList(this.SelectedVar, this.VariablesList.ToList()));
            
        }
    }
}
