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

        [OperationContract]
        string[] GetAvailableShapes();
        [OperationContract]
        int GetCircleDots(double r);
        [OperationContract]
        int GetRectangleDots(double w, double h);
        [OperationContract]
        int GetTriangleDots(double a1, double a2, double a3);
    }

        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]

        public class BlindService : IBrailleService
        {
            //send to client
            //................................ 
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

            public string[] GetAvailableShapes()
            {
                ShapesService shapes = new ShapesService();

                // Call the GetSupported method to retrieve a list of supported shapes
                return shapes.GetSupported();

            }

            public int GetCircleDots(double r)
            {
                double rad = r;

                Circle circle = new Circle();

                // Call the GetSupported method to retrieve a list of supported characters
                return circle.ComputePerimeter(rad);
            }

            public int GetRectangleDots(double w, double h)
            {
                double wid = w;
                double heig = h;

                Rectangle rect = new Rectangle();

                return rect.ComputePerimeter(wid, heig);
            }

            public int GetTriangleDots(double a1, double a2, double a3)
            {
                double arm1 = a1;
                double arm2 = a2;
                double arm3 = a3;

                Triangle triangle = new Triangle(); 

                return triangle.ComputePerimeter(arm1, arm2, arm3);
            }
            //...........................


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
