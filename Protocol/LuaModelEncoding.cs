using OpenServer.Auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenServer
{
    class LuaModelEncoding
    {
        /// <summary>
        /// 消息体序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] encode(object value)
        {
            LuaModel model = value as LuaModel;
            ByteArray ba = new ByteArray();

            ba.write(model.message);

            byte[] result = ba.getBuff();
            ba.Close();
            return result;
        }

        public static object decode(byte[] value)
        {
            ByteArray ba = new ByteArray(value);
            LuaModel model = new LuaModel();

            string message;

            ba.read(out message);

            model.message = message;

            ba.Close();
            return model;
        }
    }
}
