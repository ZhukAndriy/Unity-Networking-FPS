using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour
{
    string ip = "127.0.0.1";
    void OnGUI()
    {
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            if (GUILayout.Button("New Listen Server"))
            {
                //Network.InitializeSecurity();
                Network.InitializeServer(32, 27015, !Network.HavePublicAddress());
            }
            if (GUILayout.Button("Connect to IP"))
            {
                Network.Connect(ip, 27015);
            }
            ip = GUILayout.TextField(ip);
        }
        else
        {
            if (GUILayout.Button("Disconnect"))
            {
                if (Network.connections.Length == 1)
                {
                    Debug.Log("Disconnecting: " + Network.connections[0].ipAddress + ":" + Network.connections[0].port);
                    Network.CloseConnection(Network.connections[0], true);
                }
                Debug.Log("Disconnecting all:" + Network.connections[0].ipAddress + ":" + Network.connections[0].port);
                Network.Disconnect(1000);
            }
        }
    }
}