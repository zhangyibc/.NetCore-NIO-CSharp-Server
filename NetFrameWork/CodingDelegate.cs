using System;
using System.Collections.Generic;
using System.Text;

namespace OpenServer
{
    public delegate byte[] LengthEncode(byte[] value);
    public delegate byte[] LengthDecode(ref List<byte> value);

    public delegate byte[] encode(object value);
    public delegate object decode(byte[] value);
}
