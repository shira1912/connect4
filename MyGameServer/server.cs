using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ConnectFourServer
{
    /// <summary>
    /// The ChatClient class represents info about each client connecting to the server.
    /// </summary>
    class Server
    {
        // Store list of all clients connecting to the server
        // the list is static so all memebers of the chat will be able to obtain list
        // of current connected client
        public static Hashtable AllClients = new Hashtable();
        public static Hashtable ClientsNick = new Hashtable();

        // information about the client
        private TcpClient _client;
        private string _clientIP;
        private int _ClientNum;

        // used for sending and reciving data
        private byte[] data;

        // the nickname being sent
        private bool ReceiveNick = true;
        ConnectionToSql connection;
        GameBoard gameboard;
        string[] players = new string[3];

        /// <summary>
        /// When the client gets connected to the server the server will create an instance of the ChatClient and pass the TcpClient
        /// </summary>
        /// <param name="client"></param>

        public Server(TcpClient client)
        {
            _client = client;

            // get the ip address of the client to register him with our client list
            _clientIP = client.Client.RemoteEndPoint.ToString();

            // Add the new client to our clients collection
            AllClients.Add(_clientIP, this);

            // Read data from the client async
            data = new byte[_client.ReceiveBufferSize];

            connection = new ConnectionToSql();
            gameboard = new GameBoard();

            // BeginRead will begin async read from the NetworkStream
            // This allows the server to remain responsive and continue accepting new connections from other clients
            // When reading complete control will be transfered to the ReviveMessage() function.
            _client.GetStream().BeginRead(data,
                                          0,
                                          System.Convert.ToInt32(_client.ReceiveBufferSize),
                                          ReceiveMessage,
                                          null);
        }

        /// <summary>
        /// allow the server to send message to the client.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            try
            {
                System.Net.Sockets.NetworkStream ns;

                // use lock to prevent multiple threads from using the networkstream object
                // this is likely to occur when the server is connected to multiple clients all of 
                // them trying to access to the networkstream at the same time.
                lock (_client.GetStream())
                {
                    ns = _client.GetStream();
                }

                // Send data to the client
                byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message);
                ns.Write(bytesToSend, 0, bytesToSend.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// reciev and handel incomming streem 
        /// Asynchrom
        /// </summary>
        /// <param name="ar">IAsyncResult Interface</param>
        public void ReceiveMessage(IAsyncResult ar)
        {
            int bytesRead;
            try
            {
                lock (_client.GetStream())
                {
                    // call EndRead to handle the end of an async read.
                    bytesRead = _client.GetStream().EndRead(ar);
                }
                // if bytesread<1 -> the client disconnected
                if (bytesRead < 1)
                {
                    if (ClientsNick.Count == 2)
                    {
                        //// remove the client from out of the lists of clients
                        AllClients.Remove(_clientIP);
                        ClientsNick.Remove(_ClientNum);
                        //// tell everyone the client left the chat
                        Broadcast("Exit," + _ClientNum + " has left the chat.");
                    }
                    else
                    {
                        //// remove the client from out of the lists of clients
                        AllClients.Remove(_clientIP);
                        ClientsNick.Remove(_ClientNum);
                        //// tell everyone the client left the chat
                        Broadcast(_ClientNum + " has left the chat.");
                    }
                    return;
                }
                else // client still connected
                {
                    string messageReceived = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                    string [] splitMessage = messageReceived.Split(',');
                    switch (splitMessage[0])
                    {
                        case "SignUp":
                        {
                                if (!connection.IsExist(splitMessage[1]))
                                {
                                    connection.InsertNewUser(splitMessage[1], splitMessage[2], splitMessage[3], splitMessage[4], splitMessage[5],
                                        splitMessage[6], splitMessage[7]);
                                    SendMessage("SignUp,true");
                                }

                                else
                                {
                                    SendMessage("SignUp,false");
                                }
                                break;
                        }
                        case "Login":
                        {
                            bool isLogin = connection.IsMatchingPass(splitMessage[1], splitMessage[2]);
                            if (isLogin)
                            {
                                players[AllClients.Count] = splitMessage[1];
                                ClientsNick.Add(ClientsNick.Count + 1, splitMessage[1]);
                                _ClientNum = ClientsNick.Count;
                                SendMessage("Login,true," + _ClientNum);
                                if (ClientsNick.Count == 2)
                                    {
                                        Broadcast("Ready," + ClientsNick[1]+"," + 1);
                                    }

                            } else
                            {
                                SendMessage("Login,false");
                            }
                            break;
                        }
                        case "Insert":
                            {
                                int selectedCol = int.Parse(splitMessage[1]);
                                int row = gameboard.insertDisc(selectedCol, _ClientNum);
                                if (row >= 0)
                                {
                                    Broadcast("Insert," + row + "," + selectedCol + "," + _ClientNum + "," + ClientsNick[_ClientNum]);
                                }
                                else
                                {
                                    SendMessage("FullCol," + selectedCol);
                                }
                                if (gameboard.checkWin(_ClientNum))
                                {
                                    Broadcast("Win," + ClientsNick[_ClientNum]);
                                    ClientsNick = new Hashtable();
                                    gameboard.restartGame();
                                }
                                if (gameboard.isBoardFull())
                                {
                                    Broadcast("Draw,");
                                }
                                break;
                            }
                    }
                }
                lock (_client.GetStream())
                {
                    // continue reading form the client
                    _client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(_client.ReceiveBufferSize), ReceiveMessage, null);
                }
            }
            catch (Exception ex)
            {
                if (ClientsNick.Count == 2)
                {
                    AllClients.Remove(_clientIP);
                    ClientsNick.Remove(_ClientNum);
                    Broadcast("Exit," + _ClientNum + " has left the chat.");
                }
                else
                {
                    AllClients.Remove(_clientIP);
                    ClientsNick.Remove(_ClientNum);
                    Broadcast(_ClientNum + " has left the chat.");
                }
            }
        }

        //public void ClientDisconnect()
        //{

        //}

        /// <summary>
        /// send message to all the clients that are stored in the allclients hashtable
        /// </summary>
        /// <param name="message"></param>
        public void Broadcast(string message)
        {
            Console.WriteLine(message);
            foreach (DictionaryEntry c in AllClients)
            {
                ((Server)(c.Value)).SendMessage(message + Environment.NewLine);
            }
        }
    }
}

