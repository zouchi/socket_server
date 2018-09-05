using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using SuperSocket.SocketBase.Protocol;
using socket_server.Custom;
namespace socket_server
{
    class Program
    {
        static void Main(string[] args)
        {
            var appServer = new MyServer();

            //服务器端口
            int port = 8080;

            //设置服务监听端口
            if (!appServer.Setup(port))
            {
                Console.WriteLine("端口设置失败!");
                Console.ReadKey();
                return;
            }

            //启动服务
            if (!appServer.Start())
            {
                Console.WriteLine("启动服务失败!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("启动服务成功，输入exit退出!");

            while (true)
            {
                var str = Console.ReadLine();
                if (str.ToLower().Equals("exit"))
                {
                    break;
                }
            }

            Console.WriteLine();

            //停止服务
            appServer.Stop();

            Console.WriteLine("服务已停止，按任意键退出!");
            Console.ReadKey();


        }
    }
}