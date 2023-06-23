using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Python.Runtime;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            TextBlock myTb = new TextBlock();
            myTb.Text = "hello world, ";           
            Console.WriteLine(myTb.Text);
            
            string pythonDll = @"C:\Users\ChZh921\AppData\Local\Programs\Python\Python311\python311.dll";
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", pythonDll);
            Runtime.PythonDLL = @"C:\Users\ChZh921\AppData\Local\Programs\Python\Python311\python311.dll";
            PythonEngine.Initialize();
            string file = @"C:\Users\ChZh921\Desktop\wpfhelloworld\pydecentscale-main\examples\combine.py";

            if (!PythonEngine.IsInitialized)// Since using asp.net, we may need to re-initialize
            {
                PythonEngine.Initialize();
                Py.GIL();
            }

            using (var scope = Py.CreateScope())
            {
                string code = File.ReadAllText(file); // Get the python file as raw text
                var scriptCompiled = PythonEngine.Compile(code, file); // Compile the code/file                
                scope.Execute(scriptCompiled); // Execute the compiled python so we can start calling it.
                myTb.Inlines.Add("embedded python has been executed");          
            }

            this.Content = myTb;
        }
        
    }
}
