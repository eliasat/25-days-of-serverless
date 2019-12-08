using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Challenge_1
{
    public static class Dreidel
    {
        [FunctionName("Dreidel")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var rnd = new Random();
            var value = rnd.NextDouble();
            string resp;
            if (value < 0.33)
            {
                resp = "נ";
            }
            else if (value < 0.66)
            {
                resp = "ג";
            }
            else
            {
                resp = "ה";
            }
            return new OkObjectResult(resp);
        }
    }
}
