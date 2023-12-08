using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkPinger
// when seeing the word "service" consider this as an abstraction, an attempt to clean up the code being used
// a class is the creation of an object, this is a reference type
// used to collect variables
{
    // classes have properties and fields
    public class PingService
    {
        // these are properties of the class
        // this design pattern is simple but not optimal
        // the properties below are in state, methods are used to manipulate these properties
        public string Data { get; set; }
        public byte[] Buffer { get; set; }

        public int Timeout { get; set; }

        public string Address { get; set; }

        public Ping pingSender { get; set; }

        public PingOptions pingOptions { get; set; }

        // the properties above are in state, the method below is used to manipulate these properties
        // this is the constructor
        // these values are assigned when the object is instansiated
        public PingService()
        {
            Timeout = 120;
            Address = "4.2.2.2";
            Buffer = Encoding.ASCII.GetBytes("Learn to code");
            pingSender = new Ping();
            pingOptions = new PingOptions();
            pingOptions.DontFragment = true;
        }

        public bool SendPing()
        {
            PingReply reply = pingSender.Send(Address, Timeout, Buffer, pingOptions);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine($"Response: {reply.Status.ToString()}");
                Console.WriteLine($"RoundTrip: {reply.RoundtripTime}");
                Console.WriteLine($"Time to live: {reply.Options.Ttl}");
                Console.WriteLine($"Buffer size: {reply.Buffer.Length}");
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
