var builder = DistributedApplication.CreateBuilder(args);

var tobaccoDmAuthorizationDbConnectionString = builder.AddConnectionString("TobaccoDMAuthorizationDB");

builder.AddProject<Projects.TobaccoDMAuthorization_Host>("TobaccoDMAuthorizationHost")
    .WithReference(tobaccoDmAuthorizationDbConnectionString);

builder.Build().Run();