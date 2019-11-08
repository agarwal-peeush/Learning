using Grpc.Core;
using Grpc.Net.Client;
using GrpcService.Demo;
using System;
using System.Threading.Tasks;

namespace GrpcService.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            //var response = await client.SayHelloAsync(new HelloRequest { Name = "World" });

            //Console.WriteLine(response.Message);

            var call = client.SayHelloStreaming(new HelloRequest { Name = "World Streaming" });

            await foreach(var message in call.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine(message.Message);
            }

            Console.ReadKey();
        }
    }
}
