using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equalizer
{
    public static class PythonFun
    {

        /// <summary>
        /// This function performs calculations and latex transofrmation
        /// </summary>
        /// <param name="equation"> here you put your equation</param>
        /// <param name="values">here you put values of your variables, remember to keep order</param>
        /// <param name="names"> here you put variables that are in your euation, each has to be divided with plus sign ex: "a+b"</param>
        /// <param name="accuracy">here you specify the accuracy of the result</param>
        /// <returns>returns latex expression</returns>
        public static string RunPython(string equation, List<float> values, string names, int accuracy)
        {
            

            string python = @"C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python36_64\python.exe";  //IMPORTANT, change this to your python compiler path 
            string myPythonApp = @"C:\Users\peter\Documents\GitHub\Equalizer\Equalizer\Equalizer\Directory\logic.py";   //IMPORTANT, change this to your python code path 
            // Create new process start info 
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            // make sure we can read the output from stdout 
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.CreateNoWindow = true;
            myProcessStartInfo.RedirectStandardError = true; 


            // start python app with 3 arguments  
            // 1st argument is pointer to itself, 2nd and 3rd are actual arguments we want to send 
            string values_list = string.Join(",", values.ToArray());
            myProcessStartInfo.Arguments = myPythonApp + " " + equation + " " + values_list + " " + names + " " + accuracy;

            Process myProcess = new Process();
            // assign start information to the process 
            myProcess.StartInfo = myProcessStartInfo;

            // start process 
            myProcess.Start();

            // Read the standard output of the app we called.  
            StreamReader myStreamReader = myProcess.StandardOutput;
            string myString = myStreamReader.ReadLine();
            string errors = myProcess.StandardError.ReadToEnd();
            if (errors != "")
                return errors;
            // wait exit signal from the app we called 
            myProcess.WaitForExit();

            // close the process 
            myProcess.Close();


            // write the output we got from python app 
            // Console.WriteLine("Value received from script: " + myString);
            return myString;
        }
        /// <summary>
        /// Doesnt work 
        /// </summary>
        /// <returns></returns>
        static string GetPythonPath()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Installer\Assemblies");
            string regfilepath = "";
            if (key != null) // Make sure there are Assemblies
            {
                foreach (string Keyname in key.GetSubKeyNames())
                {
                    if (Keyname.IndexOf("python.exe") > 0)
                    {
                        regfilepath = Keyname.Replace('|', '\\');
                        return regfilepath;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// IN future we maybe we will use this metod, for now it doesnt work 
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="serviceid"></param>
        /// <returns></returns>
        private static string RunIronPython(string parameter, int serviceid)
        {
            var engine = Python.CreateEngine(); // Extract Python language engine from their grasp
            var scope = engine.CreateScope(); // Introduce Python namespace (scope)
            var d = new Dictionary<string, object>
            {
                { "serviceid", serviceid},
                { "parameter", parameter}
            }; // Add some sample parameters. Notice that there is no need in specifically setting the object type, interpreter will do that part for us in the script properly with high probability

            scope.SetVariable("params", d); // This will be the name of the dictionary in python script, initialized with previously created .NET Dictionary
            ScriptSource source = engine.CreateScriptSourceFromFile("PATH_TO_PYTHON_SCRIPT_FILE"); // Load the script
            object result = source.Execute(scope);
            parameter = scope.GetVariable<string>("parameter"); // To get the finally set variable 'parameter' from the python script
            return parameter;
        }
    }
}
