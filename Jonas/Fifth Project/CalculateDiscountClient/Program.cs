// See https://aka.ms/new-console-template for more information
using CalculateDiscountService;
using Grpc.Net.Client;

var handler = new HttpClientHandler();

handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

var channel = GrpcChannel.ForAddress("https://localhost:7005", new GrpcChannelOptions { HttpHandler = handler });

string customerType = "DIAMOND";

var client = new CalculateDiscountAmount.CalculateDiscountAmountClient(channel);

var request = new CalculateRequest { Customertype = customerType };

var reply = client.AmountCalculate(request);

Console.WriteLine($"Discount for customer type {customerType} is {reply.Customerdiscount}");
Console.WriteLine("\n\nPress any key to exit...");
Console.ReadKey();
