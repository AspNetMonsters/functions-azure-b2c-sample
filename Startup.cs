using System;
using AzureFunctions.OidcAuthentication;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

[assembly: FunctionsStartup(typeof(DaveCoApi.Startup))]
namespace DaveCoApi
{
    public class Startup : FunctionsStartup
    {
        public Startup()
        {
        }
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOidcApiAuthorization();
        }
    }
}