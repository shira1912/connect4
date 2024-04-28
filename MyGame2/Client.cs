using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace ConnectFour
{
    public partial class Client
    {
        int portNo = 5000;
        private string ipAddress = "127.0.0.1";
        TcpClient client;
        byte[] data;
        Form form;
        Player p;
        

        private delegate void delLogin(string str);
        private delegate void delInsert(string str1, string str2, string str3);
        private delegate void delSignUp(string str);
        private delegate void delEnabledButtons(string str);

        public Client(Form form)
        {
            this.form = form;
            this.client = new TcpClient(ipAddress, portNo);
            data = new byte[client.ReceiveBufferSize];
            client.GetStream().BeginRead(data,
                                         0,
                                         System.Convert.ToInt32(client.ReceiveBufferSize),
                                         ReceiveMessage,
                                         null);
        }

        public void SendMessage(string message)
        {
            try
            {
                // send message to the server
                NetworkStream ns = client.GetStream();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // send the text
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Asynchronously read data sent from the server in a seperate thread.
        /// Update the txtMessageHistory control using delegate.
        /// 
        /// Windows controls are not thread safed !
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                int bytesRead;

                // read the data from the server
                bytesRead = client.GetStream().EndRead(ar);

                if (bytesRead < 1)
                {
                    return;
                }
                else
                {
                    // invoke the delegate to display the recived data
                    string textFromServer = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                    string[] splitMessage = textFromServer.Split(',');
                    
                    switch (splitMessage[0])
                    {
                        case "SignUp":
                        {
                            this.form.Invoke(new delSignUp(SignUp), splitMessage[1]);
                            break;
                        }
                        case "Login":
                        {
                            this.form.Invoke(new delLogin(Login), splitMessage[1]);
                            break;
                        }
                        case "Insert":
                        {
                                this.form.Invoke(new delInsert(Insert), splitMessage[1], splitMessage[2], splitMessage[3]);
                                break;
                        }
                        case "FullCol":
                        {
                                MessageBox.Show("Column" + splitMessage[1] + " is already full. please choose another column");
                                break;
                        }
                        case "Win":
                        {
                                MessageBox.Show("Player " + splitMessage[1] + " win!");
                                this.form.Invoke(new delEnabledButtons(EnabledButtons), "false");
                                break;
                        }
                        
                    }

                }

                // continue reading
                client.GetStream().BeginRead(data,
                                         0,
                                         System.Convert.ToInt32(client.ReceiveBufferSize),
                                         ReceiveMessage,
                                         null);
            }
            catch (Exception ex)
            {
                // ignor the error... fired when the user loggs off
            }
        }

        void SignUp(string str)
        {
            if (str == "true")
            {
                MessageBox.Show("You have signed up");
            }
            else
            {
                MessageBox.Show("Username already exists, choose a different username");
            }
        }

        void Login(string str)
        {
            if (str == "true")
            {
                MessageBox.Show("You have logged in!");
                p = new Player(this);
                p.Show();
            } else
            {
                MessageBox.Show("password or username is incorrect");
            }
            
        }



        //void Insert(string str1, string str2, string str3, string str4)
        void Insert(string str1, string str2, string str3)
        {
            int row = int.Parse(str1);
            int col = int.Parse(str2);
            int currentPlayer = int.Parse(str3);
       
            p.UpdateCircle(row, col, currentPlayer);
        }

        void EnabledButtons(string str)
        {
            bool enabled = bool.Parse(str);
            p.EnabledButtons(enabled);
        }


        void Disconnect()
        {
            try
            {
                // disconnect form the server
                client.GetStream().Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}