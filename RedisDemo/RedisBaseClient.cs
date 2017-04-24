using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class RedisBaseClient
    {
        //配置文件
        private Configuration configuration;
        //通信socket
        private Socket socket;
        //接收字节数组
        private byte[] ReceiveBuffer = new byte[100000];

        public RedisBaseClient(Configuration config)
        {
            configuration = config;
        }

        public RedisBaseClient()
            : this(new Configuration())
        {
        }

        public void Connect()
        {
            if (socket != null && socket.Connected)
                return;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = configuration.NoDelaySocket
            };
            socket.Connect(IPAddress.Parse(configuration.Host), configuration.Port);
            if (socket.Connected)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// 关闭client
        /// </summary>
        public void Close()
        {
            socket.Disconnect(false);
            socket.Close();
        }

        public string SendCommand(RedisCommand command, params string[] args)
        {
            //请求头部格式， *<number of arguments>\r\n
            const string headstr = "*{0}\r\n";
            //参数信息       $<number of bytes of argument N>\r\n<argument data>\r\n
            const string bulkstr = "${0}\r\n{1}\r\n";

            var sb = new StringBuilder();
            sb.AppendFormat(headstr, args.Length + 1);

            var cmd = command.ToString();
            sb.AppendFormat(bulkstr, cmd.Length, cmd);

            foreach (var arg in args)
            {
                sb.AppendFormat(bulkstr, arg.Length, arg);
            }
            byte[] c = Encoding.UTF8.GetBytes(sb.ToString());
            try
            {
                Connect();
                socket.Send(c);

                socket.Receive(ReceiveBuffer);
                Close();
                return ReadData();
            }
            catch (SocketException e)
            {
                Close();
            }
            return null;
        }
        private string ReadData()
        {
            var data = Encoding.UTF8.GetString(ReceiveBuffer);
            char c = data[0];
            //错误消息检查。
            if (c == '-') //异常处理。
                throw new Exception(data);
            //状态回复。
            if (c == '+')
                return data;
            return data;
        }
    }
}
