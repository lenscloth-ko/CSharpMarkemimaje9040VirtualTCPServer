using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using WinTCPVirtualServer.Class;

namespace WinTCPVirtualServer
{
    /// <summary>
    /// 최초 참조 소스 링크
    /// http://it-jerryfamily.tistory.com/entry/Program-C-%EC%84%9C%EB%B2%84%ED%81%B4%EB%9D%BC%EC%9D%B4%EC%96%B8%ED%8A%B8-11-%ED%86%B5%EC%8B%A0
    /// 단순히 그냥 Local에서 테스트하기 위한 가상 TCP서버역활 프로젝트
    /// </summary>
    public partial class Markemimaje9040 : Form
    {
        TcpListener serverSocket = null;
        TcpClient clientSocket = null;

        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 2101;

        public Markemimaje9040()
        {
            InitializeComponent();

            // socket start
            new Thread(delegate ()
            {
                InitSocket();
            }).Start();
        }

        private void InitSocket()
        {
            try
            {
                serverSocket = new TcpListener(ipAddress, port);
                clientSocket = default(TcpClient);
                serverSocket.Start();
                DisplayText(" >> Server Started");

                clientSocket = serverSocket.AcceptTcpClient();
                DisplayText(" >> Accept connection from client");

                Thread threadHandler = new Thread(new ParameterizedThreadStart(OnAccepted));
                threadHandler.IsBackground = true;
                threadHandler.Start(clientSocket);
            }
            catch (SocketException se)
            {
                DisplayText(string.Format("InitSocket : SocketException : {0}", se.Message));
            }
            catch (Exception ex)
            {
                DisplayText(string.Format("InitSocket : Exception : {0}", ex.Message));
            }
        }

        /// <summary>
        /// delegate OnAccepted
        /// </summary>
        /// <param name="sender"></param>
        private void OnAccepted(object sender)
        {
            TcpClient clientSocket = sender as TcpClient;

            while (true)
            {
                try
                {
                    
                    NetworkStream stream = clientSocket.GetStream();
                    byte[] buffer = new byte[1024];

                    stream.Read(buffer, 0, buffer.Length);

                    //무작정 받으면 답이 없으니.....CheckSum 확인해서 멈추자
                    //여기서는 CheckSum을 확인해야한다
                    string _prevValue = string.Empty;

                    //for (int i = 0; i < buffer.Length; i++)
                    for (int i = 0; i < 30; i++)
                    {
                        //DisplayText(
                        //    buffer[i] + " => " +
                        //    buffer[i].ToString().PadLeft(8, '0') +
                        //    "/" +
                        //    string.Format("{0:x}", int.Parse(buffer[i].ToString())) +
                        //    "/" +
                        //    Convert.ToString(int.Parse(buffer[i].ToString()), 2).PadLeft(8, '0')

                        //    );
                        if (!string.IsNullOrEmpty(_prevValue))
                        {
                            //DisplayText("CheckSum : " + _prevValue + " XOR " + Convert.ToString(int.Parse(buffer[i].ToString()), 2).PadLeft(8, '0') );
                            CalCheckSumHex ccs = new CalCheckSumHex(_prevValue, Convert.ToString(int.Parse(buffer[i].ToString()), 2).PadLeft(8, '0'));
                            DisplayText(" >> CheckSum : " + ccs.GetCheckSumHexValue);
                        }

                        _prevValue = Convert.ToString(int.Parse(buffer[i].ToString()), 2).PadLeft(8, '0');
                    }

                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();
                }
                catch (SocketException se)
                {
                    DisplayText(string.Format("OnAccepted : SocketException : {0}", se.Message));
                    break;
                }
                catch (Exception ex)
                {
                    DisplayText(string.Format("OnAccepted : Exception : {0}", ex.Message));
                    break;
                }
            }

            clientSocket.Close();
        }

        /// <summary>
        /// 메세지 출력 invoke
        /// </summary>
        /// <param name="text"></param>
        private void DisplayText(string text)
        {
            if (richTextBoxMsg.InvokeRequired)
            {
                richTextBoxMsg.BeginInvoke(new MethodInvoker(delegate
                {
                    richTextBoxMsg.AppendText(text + Environment.NewLine);
                }));
            }
            else
            {
                richTextBoxMsg.AppendText(text + Environment.NewLine);
            }
        }

        /// <summary>
        /// dispose
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Markemimaje9040_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clientSocket != null)
            {
                clientSocket.Close();
                clientSocket = null;
            }

            if (serverSocket != null)
            {
                serverSocket.Stop();
                serverSocket = null;
            }
        }
    }
}
