using Grpc.Net.Client;
using GrpcOrganization.Protos;

using var channel = GrpcChannel.ForAddress("https://localhost:7292");
var client = new OrganizationSrv.OrganizationSrvClient(channel);

Console.WriteLine("data registration");
client.RegisterOrganization(new Organization { OrganizationCode = "000001", OrganizationName = "Accounting Department" });
client.RegisterOrganization(new Organization { OrganizationCode = "000002", OrganizationName = "System Department" });
Console.WriteLine("");

Console.WriteLine("get list");
Organizations organizations = client.GetOrganizations(new Empty());

foreach (var item in organizations.Items)
{
    Console.WriteLine(item.OrganizationCode + " " + item.OrganizationName);
}
Console.WriteLine("");

Console.ReadKey();
