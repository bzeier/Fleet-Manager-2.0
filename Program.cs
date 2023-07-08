using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
namespace FleetManager
{
    internal static class Program
    {
        public static string Version = "Version 1.0a";

        public static WebServiceHost hostWeb;
        public static ServiceEndpoint endpoint;
        public static ServiceDebugBehavior serviceDebugBehavior;

        public static List<string> APIRequestsLog = new List<string>();

        public static Form1 mainForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            hostWeb = new WebServiceHost(typeof(FleetManager.Service));
            endpoint = hostWeb.AddServiceEndpoint(typeof(FleetManager.IService), new WebHttpBinding(), "");
            serviceDebugBehavior = hostWeb.Description.Behaviors.Find<ServiceDebugBehavior>();
            serviceDebugBehavior.HttpHelpPageEnabled = false;
            hostWeb.Open();
            Console.WriteLine("Service Host started @ " + DateTime.Now.ToString());
            //Console.Read();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new Form1();
            Application.Run(mainForm);


        }
    }
}
