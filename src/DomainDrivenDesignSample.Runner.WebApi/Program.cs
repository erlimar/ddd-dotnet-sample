// Copyright (c) Time DomainDrivenDesignSample. Todos os direitos reservados.
// Este arquivo é parte do projeto DomainDrivenDesignSample.

using Microsoft.AspNetCore.Routing;

using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
        options.SerializerSettings.DateParseHandling = Newtonsoft.Json.DateParseHandling.DateTimeOffset;
        options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
    options.AppendTrailingSlash = true;
});
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "DomainDrivenDesignSample Web API",
        Description = "Uma API de exemplo para projeto .NET usando Domain Driven Design. <a href=\"../\">Acesse a documentação completa aqui</a>.",
        TermsOfService = new Uri("https://github.com/erlimar/ddd-dotnet-sample"),
        Contact = new OpenApiContact
        {
            Name = "Contato",
            Url = new Uri("https://github.com/erlimar/ddd-dotnet-sample/issues")
        },
        License = new OpenApiLicense
        {
            Name = "Licença",
            Url = new Uri("https://github.com/erlimar/ddd-dotnet-sample/raw/master/README.md")
        },
    });
    options.DescribeAllParametersInCamelCase();

    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);

    options.IncludeXmlComments(xmlFilePath);
});
builder.Services.AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDefaultFiles();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseStaticFiles();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();