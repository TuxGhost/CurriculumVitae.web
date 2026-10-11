using Projects;

var builder = DistributedApplication.CreateBuilder(args);

//builder.AddProject<CurriculumVitae_SwashBuckle>("SwashBuckle");
builder.AddProject<CurriculumVitae_Web>("Website")
    .WithEnvironment("ASPNETCORE_ENVIRONMENT","Development");

builder.Build().Run();
