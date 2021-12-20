using System.Collections;
using System.Collections.Generic;
using Socket.Quobject.SocketIoClientDotNet.Client;
using UnityEngine;

[CreateAssetMenu(fileName = "New Socket", menuName = "ScriptableObjects/WWW/Socket", order = 1)]
public class ScriptableSocket : ScriptableObject
{
    private QSocket _socket;
}
