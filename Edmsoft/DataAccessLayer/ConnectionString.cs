using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmsoft.Controllers
{
    public class ConnectionString
    {
        private static string ConnName = "Server=*****************;Database=BaseNotas1;User ID=***********;Password=************;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static string ConnectionName
        {
            get => ConnName;
        }
    }
}
