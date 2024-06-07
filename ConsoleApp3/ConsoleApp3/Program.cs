using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using dotNetClassLibrary;
class Program
{
    static void Main(string[] args)
    {
        //the parameters are: specifies that communicates with ipv4, socket will use datagrams -- independent messages with udp  ,socket will use udp 
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        //recipient address and port
        IPAddress broadcast = IPAddress.Parse("127.0.0.1");
        IPEndPoint endpoint = new IPEndPoint(broadcast, 12000);

        //buffer array to send 
        byte[] sendBytes;
        
        uint num;
        char delim;
        string message;


        while (true)
        {
            try
            {
                Console.WriteLine("Enter in the number of your message (uint)");
                num = UInt32.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Enter in your delimeter of choice (char)");
                delim = Char.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Enter in your message (string)");
                message = Console.ReadLine();
               
                sendBytes = ProcessContent.convertToByteArray(num, delim, message);
                sock.SendTo(sendBytes, endpoint);
                Console.WriteLine("Message sent to the broadcast address");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

            
        }

    }
}