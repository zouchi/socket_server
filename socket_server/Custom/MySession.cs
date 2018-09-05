using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket;
using SuperSocket.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace socket_server.Custom
{

        /// <summary>
        /// 自定义连接类MySession，继承AppSession，并传入到AppSession
        /// </summary>
        public class MySession : AppSession<MySession>
        {
            public int CustomID { get; set; }
            public string CustomName { get; set; }
        /// <summary>
        /// 新连接
        /// </summary>
        protected override void OnSessionStarted()
        {
            //输出客户端IP地址
            Console.WriteLine(this.LocalEndPoint.Address.ToString());
            this.Send("\n\rHello User");
            base.OnSessionStarted();

        }

        /// <summary>
        /// 未知的Command
        /// </summary>
        /// <param name="requestInfo"></param>
        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            this.Send("\n\r UnknownRequest");
        }

        /// <summary>
        /// 捕捉异常并输出
        /// </summary>
        /// <param name="e"></param>
        protected override void HandleException(Exception e)
        {
            this.Send("\n\r HandleException : {0}", e.Message);
        }

        /// <summary>
        /// 连接关闭
        /// </summary>
        /// <param name="reason"></param>
        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
        }
    }
}
