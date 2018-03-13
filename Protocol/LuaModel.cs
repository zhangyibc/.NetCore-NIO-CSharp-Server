using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenServer
{
    class LuaModel
    {
        public string message { get; set; }

        public LuaModel()
        {

        }

        public LuaModel(string mess)
        {
            this.message = mess;
        }

        public byte[] GetMessage()
        {
            return Encoding.ASCII.GetBytes(message);
        }
    }
}
