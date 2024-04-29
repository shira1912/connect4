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
        string username;
        

        private delegate void delLogin(string str1, string str2);
        private delegate void delInsert(string str1, string str2, string str3);
        private delegate void delSignUp(string str);
        private delegate void delEnabledButtons(string str);
        private delegate void delTurn(string str);
        private delegate void delSwitchTurn(string str);
        private delegate void delDeleteWaiting();
        private delegate void delShowNewGameButton();


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
                            this.form.Invoke(new delLogin(Login), splitMessage[1], splitMessage[2]);
                            break;
                        }
                        case "Insert":
                        {
                                this.form.Invoke(new delInsert(Insert), splitMessage[1], splitMessage[2], splitMessage[3]);
                                this.form.Invoke(new delSwitchTurn(SwitchTurn), splitMessage[3]);
                                if (splitMessage[4].Split('\r')[0] == this.username)
                                {
                                    this.form.Invoke(new delEnabledButtons(EnabledButtons), "false");
                                }
                                else
                                {
                                    this.form.Invoke(new delEnabledButtons(EnabledButtons), "true");
                                }
                                break;
                        }
                        case "FullCol":
                        {
                                MessageBox.Show("Column" + splitMessage[1] + " is already full. please choose another column");
                                break;
                        }
                        case "Win":
                        {
                                MessageBox.Show(splitMessage[1] + " won! \n The game is over.");
                                this.form.Invoke(new delEnabledButtons(EnabledButtons), "false");
                                //this.form.Invoke(new delShowNewGameButton(ShowNewGameButton));
                                break;
                        }
                        case "Draw":
                            {
                                MessageBox.Show("It's a draw! \n The game is over.");
                                this.form.Invoke(new delEnabledButtons(EnabledButtons), "false");
                                break;
                            }
                        case "Ready":
                        {
                                this.form.Invoke(new delTurn(Turn), splitMessage[2]);
                                this.form.Invoke(new delDeleteWaiting(DeleteWaiting));

                                if (splitMessage[1] == this.username)
                                {
                                    this.form.Invoke(new delEnabledButtons(EnabledButtons), "true");
                                }
                                else
                                {
                                    this.form.Invoke(new delEnabledButtons(EnabledButtons), "false");
                                }
                                break;
                        }
                        case "Exit":
                            {
                                MessageBox.Show("The other player left. You win.");

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
                MessageBox.Show("You have signed up!");
            }
            else
            {
                MessageBox.Show("Username already exists, choose a different username");
            }
        }

        void Login(string str1, string str2)
        {
            if (str1 == "true")
            {
                p = new Player(this);
                p.Show();
                form.Hide();
                int currentPlayer = int.Parse(str2);
                p.SetPlayerColorPic(currentPlayer);

            } else
            {
                MessageBox.Show("Password or username is incorrect");
            }
            
        }



        
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

        void DeleteWaiting()
        {
            p.DeleteWaitingLabel();
        }

        void Turn(string str)
        {
            int currentPlayer = int.Parse(str);
            p.TurnPic(currentPlayer);
        }
        void SwitchTurn(string str)
        {
            int currentPlayer = int.Parse(str);
            p.SwitchTurnPic(currentPlayer);
        }

        public void SetUsername(string str)
        {
            this.username = str;
        }
        public string GetUsername()
        {
            return this.username;
        }

        void ShowNewGameButton()
        {
            p.ShowNewGameButton();
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