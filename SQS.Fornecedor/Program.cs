using Amazon.SQS;
using Amazon;
using Amazon.SQS.Model;
using SQS.Fornecedor.models;
using DotNetEnv;
using System.Text.Json.Serialization;
using System.Text.Json;


class Program
{
    static async Task Main(string[] args)
    {

        var bodyMessageJSON = new BodyMessageJSON()
        {
            Body = "",
            Status = "200"
        };

        DotNetEnv.Env.Load();

        var messageConvert = JsonSerializer.Serialize(bodyMessageJSON);
        var userEndpointAWS = Environment.GetEnvironmentVariable("USER_ENDPOINT_AWS");

        var client = new AmazonSQSClient(RegionEndpoint.USWest2);

        var request = new SendMessageRequest
        {
            QueueUrl = userEndpointAWS,
            MessageBody = messageConvert
        };

        await client.SendMessageAsync(request);


    }
}









