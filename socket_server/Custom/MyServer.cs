using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace socket_server.Custom
{
    /// <summary>
    /// 自定义服务器类MyServer，继承AppServer，并传入自定义连接类MySession
    /// </summary>
    public class MyServer : AppServer<MySession>
    {
        protected override void OnStarted()
        {
            base.OnStarted();
            Console.WriteLine("服务器已启动");
        }

        /// <summary>
        /// 输出新连接信息
        /// </summary>
        /// <param name="session"></param>
        protected override void OnNewSessionConnected(MySession session)
        {
            base.OnNewSessionConnected(session);
            //输出客户端IP地址
            Console.Write("\r\n" + session.LocalEndPoint.Address.ToString() + ":连接");
        }

        /// <summary>
        /// 输出断开连接信息
        /// </summary>
        /// <param name="session"></param>
        /// <param name="reason"></param>
        protected override void OnSessionClosed(MySession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            //输出客户端IP地址
            Console.Write("\r\n" + session.LocalEndPoint.Address.ToString() + ":断开连接");
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            Console.WriteLine("服务器已停止");
        }
    }
}
