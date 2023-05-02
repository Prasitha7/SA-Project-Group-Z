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

        [OperationContract]
        string[] GetAvailableShapes();
        [OperationContract]
        int GetCircleDots(double r);
        [OperationContract]
        int GetRectangleDots(double w, double h);
        [OperationContract]
        int GetTriangleDots(double a1, double a2, double a3);
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

            string loopQuit ="-1";
            while (loopQuit != "x" && loopQuit != "X")
            {
                Console.WriteLine("Input The chapter you want so that we can calculate how much ink is neaded to Print the text");
                Console.WriteLine("Down Below are the charactors that our software support");

                //Display the available text
                foreach (var message in avilableText)
                {
                    Console.Write(message + ", ");
                }

                //Take chapter input value from user.......
                Console.WriteLine("");
                Console.WriteLine("your chapter:");
                string chapter = Console.ReadLine();
                Console.WriteLine("..............................");
                //..........

                //Send chapter to server
                proxy.SendChapter(chapter);

                //Get from server
                int dots = 0;
                dots =dots+proxy.GetDots(chapter);
                Console.WriteLine("Required dot amount:-");
                Console.WriteLine(dots.ToString());
                Console.WriteLine("..............................");

                Console.WriteLine("Required ink in MicroLeters:-");
                double ink = proxy.GetInk(dots);
                Console.WriteLine(ink.ToString());
                Console.WriteLine("..............................");

                Console.WriteLine("Input The Shape type you want so that we can calculate how much ink is neaded to Print the shape");
                Console.WriteLine("Down Below are the Shapes that our software support");

                var avilableShapes = proxy.GetAvailableShapes();

                //Display the available text
                int i = 0;
                foreach (var shape in avilableShapes)
                {
                    i++;
                    Console.Write("[" + i + "]" + shape + ", ");
                }

                Console.WriteLine("Which shape do you want to impliment(Choose by number)");
                string shapeNo = Console.ReadLine();

                if (shapeNo == "1")
                {
                    Console.WriteLine("Input Parameters for the circle");

                    //Taking Parameter Input
                    //..............................
                    Console.Write("Radius:-");
                    String Radius = Console.ReadLine();

                    double r;
                    if (Double.TryParse(Radius, out r))
                    {

                        Console.WriteLine("The input is a valid double: ");
                    }
                    else
                    {
                        Console.WriteLine("The input is not valid");
                    }
                    dots = dots + proxy.GetCircleDots(r);
                    //...............................

                }
                else if (shapeNo == "2")
                {
                    Console.WriteLine("Input Parameters for the rectangle");

                    //Taking Parameter Input
                    //..............................
                    Console.Write("Width:-");
                    String width = Console.ReadLine();

                    double w;
                    if (Double.TryParse(width, out w))
                    {
                        Console.WriteLine("The input is a valid double: ");
                    }
                    else
                    {
                        Console.WriteLine("The input is not valid");
                    }
                    //...............................
                    //Taking Parameter Input
                    //..............................
                    Console.Write("height:-");
                    String height = Console.ReadLine();

                    double h;
                    if (Double.TryParse(height, out h))
                    {
                        Console.WriteLine("The input is a valid double: ");
                    }
                    else
                    {
                        Console.WriteLine("The input is not valid");
                    }
                    //...............................
                    dots = dots + proxy.GetRectangleDots(w, h);



                }
                else if (shapeNo == "3")
                {
                    Console.WriteLine("Input Parameters for the triangle");

                    //Taking Parameter Input
                    //..............................
                    Console.Write("Arm 1:-");
                    String arm1 = Console.ReadLine();

                    double a1;
                    if (Double.TryParse(arm1, out a1))
                    {
                        Console.WriteLine("The input is a valid double: ");
                    }
                    else
                    {
                        Console.WriteLine("The input is not valid");
                    }
                    //...............................
                    //Taking Parameter Input
                    //..............................
                    Console.Write("Arm 2");
                    String arm2 = Console.ReadLine();

                    double a2;
                    if (Double.TryParse(arm2, out a2))
                    {
                        Console.WriteLine("The input is a valid double: ");
                    }
                    else
                    {
                        Console.WriteLine("The input is not valid");
                    }
                    //...............................

                    //Taking Parameter Input
                    //..............................
                    Console.Write("Arm 2");
                    String arm3 = Console.ReadLine();

                    double a3;
                    if (Double.TryParse(arm3, out a3))
                    {
                        Console.WriteLine("The input is a valid double: ");
                    }
                    else
                    {
                        Console.WriteLine("The input is not valid");
                    }
                    //...............................


                    int sDots = proxy.GetTriangleDots(a1, a2, a3);

                }
                else
                {
                    Console.WriteLine("Invalid shape Number");
                }

                Console.WriteLine("Required dot amount:-");
                Console.WriteLine(dots.ToString());
                Console.WriteLine("..............................");

                Console.WriteLine("Required ink in MicroLeters:-");
                ink = proxy.GetInk(dots);
                Console.WriteLine(ink.ToString());

                Console.WriteLine("................................");
                Console.WriteLine("Press enter to input more prases or shapes");
                Console.WriteLine("Press x then enter to quit program");
                Console.WriteLine("................................");

                loopQuit = Console.ReadLine();
            }


            Console.ReadLine();
        }
    }
}
