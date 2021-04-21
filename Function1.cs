using System;
using fncConsumidorIoT.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace fncConsumidorIoT
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async System.Threading.Tasks.Task RunAsync(
            [ServiceBusTrigger("colaparcial2", Connection = "MyQueueConn")]string myQueueItem,
            [CosmosDB(databaseName: "dbParcial2", collectionName: "ModelParcial", ConnectionStringSetting = "CosmosConn")] IAsyncCollector<object> datos,
            ILogger log
            )
        {
            try
            {
                log.LogInformation($"Se proceso el siguiente mensaje: {myQueueItem}");
                var data = JsonConvert.DeserializeObject<ModelParcial>(myQueueItem);
                await datos.AddAsync(data);
            }
            catch (Exception ex)
            {
                log.LogError($"No se puede agregar datos: {ex.Message}");
            }
        }
    }
}
