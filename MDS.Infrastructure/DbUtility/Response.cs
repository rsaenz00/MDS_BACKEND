using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Infrastructure.DbUtility
{
    public class Response
    {
        public int codeResult { get; set; }
        public string message { get; set; }
        public string messagePublic { get; set; }
        public string datetime { get; set; }
        public object results { get; set; }

        public Response(int codeResult, string message, string messagePublic, string datetime, object results)
        {
            this.codeResult = codeResult;
            this.message = message;
            this.messagePublic = messagePublic;
            this.datetime = datetime;
            this.results = results;
        }
    }
}
