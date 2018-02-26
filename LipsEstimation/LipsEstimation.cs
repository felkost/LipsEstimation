using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;


namespace LipsEstimation
{
    public static class LipsEstimation
    {
        [FunctionName("LipsEstimation")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            // Get request body (JSON)
            RootObjectIn dataIn = await req.Content.ReadAsAsync<RootObjectIn>();

            //Build data             
            RootObjectOut dataOut = GetData(dataIn);

            //Output data in JSON
            string jsonObject = JsonConvert.SerializeObject(dataOut);
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            return response;
        }

        private static RootObjectOut GetData(RootObjectIn dataIn)
        {
            RootObjectOut dataOut = new RootObjectOut();
            dataOut.faces = new List<LipsOut>();
            for (int i = 0; i < dataIn.faces.Count; i++)
            {
                Lips lips = new Lips(dataIn.faces[i].dots[60].x, dataIn.faces[i].dots[60].y,
                                    dataIn.faces[i].dots[61].x, dataIn.faces[i].dots[61].y,
                                    dataIn.faces[i].dots[62].x, dataIn.faces[i].dots[62].y,
                                    dataIn.faces[i].dots[63].x, dataIn.faces[i].dots[63].y,
                                    dataIn.faces[i].dots[64].x, dataIn.faces[i].dots[64].y,
                                    dataIn.faces[i].dots[65].x, dataIn.faces[i].dots[65].y,
                                    dataIn.faces[i].dots[66].x, dataIn.faces[i].dots[66].y,
                                    dataIn.faces[i].dots[67].x, dataIn.faces[i].dots[67].y);
                lips.BiuldModelLips();
                LipsOut faceOut = new LipsOut();
                faceOut.number = dataIn.faces[i].number;
                faceOut.a = lips.a;
                faceOut.b = lips.b;
                faceOut.eps = lips.eps;

                dataOut.faces.Add(faceOut);
            }
            return dataOut;
        }
    }
}
