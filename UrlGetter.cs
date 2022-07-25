using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public sealed class UrlGetter
    {
        public const string Url  = "https://reqres.in/";

        public string GetUrl()
        {
            return Url;
        }
    }
}
