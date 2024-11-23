using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Exception
{

    public class AssetNotFoundException : System.Exception
    {
        public AssetNotFoundException()
        {

        }
        public AssetNotFoundException(string message) : base(message) { }

        public AssetNotFoundException(string message, IOException innerException) : base(message, innerException) { }

    }
}

