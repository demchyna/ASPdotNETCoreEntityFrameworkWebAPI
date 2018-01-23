using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETCoreEntityFrameworkWebAPI.Security
{
    public class AuthenticationOptions
    {
        public const string SIGNING_KEY = "This is my custom Secret key for authnetication";
        public const int LIFETIME = 1;
    }
}
