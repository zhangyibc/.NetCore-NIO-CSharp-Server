using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenServer
{
    /// <summary>
    /// 处理已链接的token
    /// </summary>
    public static class TokenDict
    {
        public static Dictionary<int,UserToken> tokenDict = new Dictionary<int,UserToken>();

        /// <summary>
        /// 根据key取出Token
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static UserToken GetToken(int key)
        {
            if (tokenDict.ContainsKey(key))
            {
                return tokenDict[key];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 保存一个Token
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="token">token</param>
        public static void SetToekn(int key,UserToken token)
        {
            tokenDict.Add(key, token);
        }

        /// <summary>
        /// 移除一个token
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveToken(int key)
        {
            tokenDict.Remove(key);
        }

        /// <summary>
        /// 获取当前连接数
        /// </summary>
        /// <returns></returns>
        public static int GetTokenCount()
        {
            return tokenDict.Count;
        }
    }
}
