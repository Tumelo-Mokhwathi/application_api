using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application_api.Configurations
{
    public class CorsOptions
    {
        public string AllowedOrigins { get; set; }
        public string[] GetAllowedOriginsAsArray()
        {
            return AllowedOrigins.Split(',').Select(o => o.Trim()).ToArray();
        }
    }
}
