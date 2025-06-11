#pragma warning disable ASPIREHOSTINGPYTHON001 // Test for experimental feature

using System.Security.Principal;

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.aspire_python_ApiService>("apiservice");

// builder.AddProject(WellKnown);
builder.AddProject<Projects.aspire_python_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

#pragma warning disable ASPIREPROXYENDPOINTS001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
var valKey = builder.AddValkey
    (
        "aspire-python-django1-valkey"
    )
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume()
    .WithEndpointProxySupport(true);
#pragma warning restore ASPIREPROXYENDPOINTS001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
                                               // .WithHttpEndpoint(targetPort: 8000)
                                               // // Https requests CA Store
                                               // .WithEnvironment("REQUESTS_CA_BUNDLE", "/etc/ssl/certs/ca-certificates.crt")
                                               // // Open telemetry CA store
                                               // .WithEnvironment("OTEL_EXPORTER_OTLP_CERTIFICATE", "/etc/ssl/certs/ca-certificates.crt")
                                               // .WithEnvironment("OTEL_LOG_LEVEL", "INFO")
                                               // .WithEnvironment("DJANGO_SETTINGS_MODULE", "hello.settings");

builder.AddPythonApp
    (
        "aspire-python-app1", 
        "../aspire-python.app1", 
        "main.py"
    )
    .WithEnvironment("OTEL_EXPORTER_OTLP_CERTIFICATE", "/etc/ssl/certs/ca-certificates.crt")
    .WithEnvironment("OTEL_LOG_LEVEL", "INFO");
builder.AddPythonApp
    (
        "aspire-python-django1",
        "../aspire-python.django1/django1",
        "manage.py",
        ".venv",
        "runserver", "--noreload"
    )
    .WithReferenceRelationship(valKey)
    .WithHttpEndpoint(targetPort: 8000)
    // Https requests CA Store
    .WithEnvironment("REQUESTS_CA_BUNDLE", "/etc/ssl/certs/ca-certificates.crt")
    // Open telemetry CA store
    .WithEnvironment("OTEL_EXPORTER_OTLP_CERTIFICATE", "/etc/ssl/certs/ca-certificates.crt")
    .WithEnvironment("OTEL_LOG_LEVEL", "INFO")
    .WithEnvironment("DJANGO_SETTINGS_MODULE", "hello.settings");
    // .WithEnvironment("OTEL_PYTHON_EXPORTER_OTLP_INSECURE", "True");

builder.Build().Run();
