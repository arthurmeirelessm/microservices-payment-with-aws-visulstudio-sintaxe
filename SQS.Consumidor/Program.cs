using Amazon.SQS;
using Amazon;
using Amazon.SQS.Model;
using DotNetEnv;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static async Task Main(string[] args)
    {
        DotNetEnv.Env.Load();
        var client = new AmazonSQSClient(RegionEndpoint.USWest2);
        var userEndpointAWS = Environment.GetEnvironmentVariable("USER_ENDPOINT_AWS");


        var request = new ReceiveMessageRequest
        {
            QueueUrl = userEndpointAWS
        };


        var capturedMessageResponse = await client.ReceiveMessageAsync(request);
        foreach (var message in capturedMessageResponse.Messages)
        {
            await Console.Out.WriteLineAsync(message.Body);
            await client.DeleteMessageAsync(userEndpointAWS, message.ReceiptHandle);
        }
    }
}









