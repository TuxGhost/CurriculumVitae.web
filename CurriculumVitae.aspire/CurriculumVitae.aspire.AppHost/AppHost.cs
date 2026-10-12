using Projects;

var builder = DistributedApplication.CreateBuilder(args);

//builder.AddProject<CurriculumVitae_SwashBuckle>("SwashBuckle");
builder.AddProject<CurriculumVitae_Web>("Website")
    .WithEnvironment("ASPNETCORE_ENVIRONMENT","Development");

var ui5 = builder.AddJavaScriptApp("ui5", $"..//../CurriculumVitae.UI5", "start")
    .WithNpm(install: true)
    .WithRunScript("start")
    .WithHttpEndpoint(targetPort: 8080);
builder.Build().Run();
