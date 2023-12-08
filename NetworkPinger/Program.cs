using NetworkPinger;
using System.Net.NetworkInformation;
using System.Text;

// Pinging Google DNS Server 4.2.2.2

// this is used to create an instance of the ping function and configure the ping options
Ping pingSender = new Ping();
PingOptions options = new PingOptions();

// sometimes when a certain amount is sent, it may cause an error. this is to prevent that
options.DontFragment = true;

// this is the data what will be sent
string data = "Learn to code";

// this is so the data is actually recieved, must be a byte array, consists of any number below 255
byte[] buffer = Encoding.ASCII.GetBytes(data);

int timeout = 120;
string address = "4.2.2.2";
// this performs the ping then returns the data into an object
PingReply reply = pingSender.Send(address, timeout, buffer, options);

// this checks whether the ping was successful by comparing it the status response used for success
if (reply.Status == IPStatus.Success)
{
    Console.WriteLine($"Response: {reply.Status.ToString()}");
    Console.WriteLine($"RoundTrip: {reply.RoundtripTime}");
    Console.WriteLine($"Time to live: {reply.Options.Ttl}");
    Console.WriteLine($"Buffer size: {reply.Buffer.Length}");




}

// using the PingService Object

PingService pingService = new PingService();

var response = pingService.SendPing();

Console.WriteLine(response);