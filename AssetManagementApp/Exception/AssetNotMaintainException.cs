using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Exception
{

    public class AssetNotMaintainException : IOException
    {
        public AssetNotMaintainException(string message) : base(message) { }
    }
}
