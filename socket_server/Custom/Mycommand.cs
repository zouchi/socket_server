
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace socket_server.Custom
{
    /// <summary>
    /// 自定义命令类HELLO，继承CommandBase，并传入自定义连接类MySession
    /// </summary>
    public class Mycommand : CommandBase<MySession, StringRequestInfo>
    {
        /// <summary>
        /// 自定义执行命令方法，注意传入的变量session类型为MySession
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            session.CustomID = new Random().Next(10000, 99999);
            session.CustomName = "hello word";
            Console.WriteLine(session.CustomID);
            Console.WriteLine(session.CustomName);

            var key = requestInfo.Key;
            var param = requestInfo.Parameters;
            var body = requestInfo.Body;
            Console.WriteLine(key);
            Console.WriteLine(param);
            Console.WriteLine(body);

            session.Send(session.CustomID.ToString());
        }

    }
}
