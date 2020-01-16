using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class OnlineGameController : MonoBehaviour
{
    public string PlayerName;
    public InputField inp;
    public CreateGrid CreateGrid;
    GameObject player1;
    GameObject player2;

    TcpClient socket = new TcpClient();
    public Player player1Script;
    public Player player2Script;
    GameObject[,] cells;
    public Text log;
    NetworkStream stream;
    public void Connect()
    {
        try
        {
            PlayerName = inp.text;
            socket.Connect("localhost", 4545);
            log.text += "Connect to server! \n";
            if (socket.Connected == true)
            {
                stream = socket.GetStream();
                stream.Write(GameFunc.CompilString(PlayerName), 0, GameFunc.CompilString(PlayerName).Length);
               
                
            }
        }
        catch (SocketException ex)
        {
            Debug.Log(ex.Message);
            socket.Dispose();
        }
    }

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player1Script = player1.GetComponent<Player>();
        player2Script = player2.GetComponent<Player>();
        cells = CreateGrid.DrawGrid();
        player1Script.MoveForward(cells);
    }

    void Update()
    {
        Debug.Log(socket.Connected);
        if (socket.Connected)
        {
            byte[] data = new byte[256];
            StringBuilder response = new StringBuilder();
            stream = socket.GetStream();

            do
            {
                int bytes = stream.Read(data, 0, data.Length);
                response.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable); // пока данные есть в потоке
            if (GameFunc.GetCommandFromRes(response.ToString()) == "Player2")
            {
                log.text += "Player 2 Name: " + GameFunc.GetValueFromRes(response.ToString()) + "\n";

            }
            // Закрываем потоки
           
        }
    }
        
}
  

