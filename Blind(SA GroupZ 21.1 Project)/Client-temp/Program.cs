using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client_temp
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

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("press any key to continue...");
            Console.ReadLine();

            string uri = "net.tcp://localhost:6565/BlindService";
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);

            var channel = new ChannelFactory<IBrailleService>(binding);
            var endpoint = new EndpointAddress(uri);
            var proxy = channel.CreateChannel(endpoint);

            
            //Get available texts
            var avilableText = proxy.GetAvailableText();

            
            Console.WriteLine("Welcome to Braillieee");
            Console.WriteLine("Input The chapter you want so that we can calculate how much ink is neaded to Print the text");
            Console.WriteLine("Down Below are the charactors that our software support");

            //Display the available text
            foreach (var message in avilableText)
            {
                Console.Write(message+", ");
            }

            //Take chapter input value from user.......
            Console.WriteLine("");
            Console.WriteLine("your chapter:-");
            string chapter = Console.ReadLine();
            Console.WriteLine("..............................");
            //..........

            //Send chapter to server
            proxy.SendChapter(chapter);

            //Get from server
            int dots = proxy.GetDots(chapter);
            Console.WriteLine("Required dot amount:-");
            Console.WriteLine(dots.ToString());
            Console.WriteLine("..............................");

            Console.WriteLine("Required ink in MicroLeters:-");
            double ink = proxy.GetInk(dots);
            Console.WriteLine(ink.ToString());
            Console.WriteLine("..............................");

            Console.ReadLine();
        }
    }
}
