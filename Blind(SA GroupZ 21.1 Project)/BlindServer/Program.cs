using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BlindServer
{
    internal class Program
    {
        [ServiceContract]
        public interface IBrailleService
        {
            [OperationContract]
            string[] GetAvailableText();

            [OperationContract]
            void SendChapter(string message);

            [OperationContract]
            int GetDots(string text);

            [OperationContract]
            double GetInk(int dots);
        }

        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]

        public class BlindService : IBrailleService
        {
            //send to client
            //..................
            
            public string[] GetAvailableText()
            {
            BrailleService brailleService = new BrailleService();    

                // Call the GetSupported method to retrieve a list of supported characters
                return brailleService.GetSupported();
            }

            public int GetDots(string chapter)
            {
                string text = chapter;
                BrailleService brailleService = new BrailleService();

                // Call the GetSupported method to retrieve a list of supported characters
                return brailleService.GetBrailleDots(text);
            }

            public double GetInk(int dots)
            {
                
                double inkPerDot = 1.63;

                return dots * inkPerDot;
            }

            //.................

            //Get from client
            private List<string> Text = new List<string>();

            public void SendChapter(string message)
            {
                Text.Add(message);
            }
        }



        static void Main(string[] args)
        {


            var uris = new Uri[1];

            string address = "net.tcp://localhost:6565/BlindService";

            uris[0] = new Uri(address);

            IBrailleService message = new BlindService();

            ServiceHost host = new ServiceHost(message,uris);

            var binding = new NetTcpBinding(SecurityMode.None);

            host.AddServiceEndpoint(typeof(IBrailleService), binding, "");

            host.Opened += Host_Opened;
            host.Open();

            
            
            //stop console from closing
            Console.ReadLine();



        }

        private static void Host_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("message service started");
        }
    }
}
