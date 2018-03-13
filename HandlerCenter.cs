using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace OpenServer
{
    /// <summary>
    /// 在lua和C#之间传递Object将会是灾难性的性能损失
    /// 建议通过List保存token，通过key来访问List中对应的token
    /// lua和C#之间传递key
    /// </summary>
    class HandlerCenter : AbsHandlerCenter
    {
	Script script;	

        public HandlerCenter()
        {
	    script = new Script();
	    script.Globals["sendMessage"] = (Action<int, string>)MessageSend;
        }

        public override void ClientClose(UserToken token, string error)
        {
            //user的连接关闭方法 一定要放在逻辑处理单元后面
            //其他逻辑单元需要通过user绑定数据来进行内存清理 
            //如果先清除了绑定关系 其他模块无法获取角色数据会导致无法清理
            Console.WriteLine("有客户端断开连接了,id:" + token.tokenID);
            TokenDict.RemoveToken(token.tokenID);
            int tokenId = token.tokenID;
            //TODO通知lua有客户端断开了
        }

        public override void ClientConnect(UserToken token)
        {
            Console.WriteLine("有客户端连接了,id:"+token.tokenID);
            TokenDict.SetToekn(token.tokenID, token);
            //TODO通知lua有客户端连接了
        }

        //消息模块分发
        public override void MessageReceive(UserToken token, object message)
        {
            Console.WriteLine("有消息送达");
            LuaModel model = message as LuaModel;
            int tokenId = token.tokenID;
            //TODO通知lua有消息送达
            //Console.WriteLine("id："+tokenId+"  message："+model.message);
	    script.Globals["tokenID"] = tokenId;
	    script.Globals["message"] = model.message;
	    script.DoFile("mainServer.lua");
        }

        //lua调用客户端推送消息给客户端
        //消息推送
        public void MessageSend(int tokenID, string message)
        {
            UserToken token = TokenDict.GetToken(tokenID);
            Console.WriteLine("推送消息给客户端,id:" + tokenID + " message:" + message);
            byte[] value = LuaModelEncoding.encode(new LuaModel(message));
            value = LengthEncoding.encode(value);
            token.write(value);
        }
    }
}
