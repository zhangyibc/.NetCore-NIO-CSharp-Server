using System;

namespace OpenServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ServerStart openServer = new ServerStart(9000);
            openServer.center = new HandlerCenter();

            openServer.decode = LuaModelEncoding.decode;
            openServer.encode = LuaModelEncoding.encode;

            openServer.Start(23333);
            Console.WriteLine("服务器启动成功");
            while (Console.ReadLine() != "exit") { }
        }
    }
}
