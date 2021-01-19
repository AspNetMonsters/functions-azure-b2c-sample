using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunctions.OidcAuthentication;

namespace DaveCoApi
{
    public class Secret
    {
         private readonly IApiAuthentication apiAuthentication;

        public Secret(IApiAuthentication apiAuthentication)
        {
            this.apiAuthentication = apiAuthentication;
        }

        [FunctionName("Secret")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Authenticate the user
            var authResult = await this.apiAuthentication.AuthenticateAsync(req.Headers);

            // Check the authentication result
            if (authResult.Failed)
            {
                return new ForbidResult(authenticationScheme: "Bearer");
            }

            string responseMessage = $"Welcome to Dave Co. Est {DateTime.Now.Year}";
            return new OkObjectResult(new [] {
                new {Message = responseMessage},
                new {Message = "That's it. We don't have many secrets around here"}
            });
        }
    }
}
