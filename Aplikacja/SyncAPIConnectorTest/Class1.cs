using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pl.xtb.api.message.command;
using System.Net.Sockets;



namespace SyncAPIConnectorTest
{
    class Class1
    {
        //samgggggdd
        //hyghggh
        //opaaa
        string MakeRequest(string josnString, System.Net.Sockets.TcpClient m_socClient)
    {
        System.String outputSting = null;
        try
        {
            String szData = josnString;
            byte[] byteData = System.Text.Encoding.ASCII.GetBytes(szData);
            m_socClient.Send(byteData);

            byte[] buffer = new byte[8192];
            int iRx = m_socClient.Receive(buffer);
            string buf = System.Text.Encoding.ASCII.GetString(buffer);
            char[] chars = new char[iRx];

            System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
            int charLen = d.GetChars(buffer, 0, iRx, chars, 0);
            outputSting = new System.String(chars);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
            //if ((ex.Message.Contains("An established connection was aborted by the software in your host machine")) || (ex.Message.Contains("An existing connection was forcibly closed by the remote host")))
            //{
            //    lblMsg.Text = "Server error... please try after some time";
            //    lblMsg.ForeColor = System.Drawing.Color.Red;
            //}
            //else
            //{
            //    lblMsg.Text = ex.Message;
            //    lblMsg.ForeColor = System.Drawing.Color.Red;
            //}
        }

        return outputSting.ToString();
    }
        public static void Main(string[] args){

            
            private System.Net.Sockets.TcpClient m_socClient = new System.Net.Sockets.TcpClient("195.182.34.175", 23460);
            LoginCommand login = new LoginCommand(jsonObject, true);
            string response = MakeRequest(login.toJSONString(), m_socClient);


        }




    }


}
