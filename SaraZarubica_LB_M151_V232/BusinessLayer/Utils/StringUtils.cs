using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utils
{
    public static class StringUtils
    {

        public static byte[] GetByteArray(string val)
        {
            return Encoding.UTF8.GetBytes(val);
        }
    }
}
