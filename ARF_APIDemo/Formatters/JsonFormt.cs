using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;

namespace ARF_APIDemo.Formatters
{
    public class JsonFormt : IContentNegotiator
    {
        private readonly JsonMediaTypeFormatter JsonFrm;

        public JsonFormt(JsonMediaTypeFormatter formatter)
        {
            JsonFrm = formatter;
        }

        public ContentNegotiationResult Negotiate(
                Type type,
                HttpRequestMessage request,
                IEnumerable<MediaTypeFormatter> formatters)
        {
            return new ContentNegotiationResult(
                JsonFrm,
                new MediaTypeHeaderValue("application/json"));
        }
    }
}