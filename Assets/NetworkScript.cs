using UnityEngine;
using System.Collections;

public class NetworkScript : MonoBehaviour
{
    public GameObject playerPrefab;
    void LaunchServer()
    {
        //Network.InitializeSecurity();
        Network.InitializeServer(32, 27015, !Network.HavePublicAddress());
    }
    void SpawnPlayer()
    {
        Network.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, 0);
    }

    void OnServerInitialized()
    {
        if (Network.isServer)
        {
            Debug.Log("OnServerInitialized(): SpawnPlayer() called");
            SpawnPlayer();
        }
    }
    void OnConnectedToServer()
    {
        Debug.Log("OnConnectedToServer(): Connected to server");
        SpawnPlayer();
    }
    //void OnPlayerConnected(NetworkPlayer player)
    //{
    //    Debug.Log("OnPlayerConnected(): " + player + " connected");
    //    SpawnPlayer();
    //}
    void OnPlayerDisconnected(NetworkPlayer player)
    {
        Debug.Log("OnPlayerDisconnected()" + player);
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
    }
}