using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace BloggingSystem.Services.Controllers
{
    public static class ApiControllerHelper
    {
        public static string GetHeaderValue(HttpRequestHeaders headers, string key)
        {
            IEnumerable<string> values;

            if (headers.TryGetValues(key, out values))
            {
                return values.FirstOrDefault();
            }

            return null;
        }
    }
}