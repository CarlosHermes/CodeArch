using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Socket.Quobject.SocketIoClientDotNet.Client;
using UnityEngine;
using UnityEngine.Networking;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "New WWWClient", menuName = "ScriptableObjects/WWW/Client", order = 1)]
public class WWWClient : ScriptableObject
{
    [SerializeField] private string _url;
    private const string _loginDir = "api/login/";
    private const string _usersDir = "api/users/";
    private const string _rankingDir = "api/ranking/";
    private string _userLogged;
    private QSocket socket;
    [SerializeField] private ScriptableRanking _sRanking;
    public PlayerSaveData saveData;
    
    public string URL => _url;
    public string UserLogged => _userLogged;
    
    #region REST_METHODS
    
    public IEnumerator LogInOnServer(string userName, string password)
    {
        var jsonBody = JsonUtility.ToJson(new CredentialsData(userName, password));
        var webRequest = SetWebRequest(_url + _loginDir, "POST", jsonBody);

        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Debug.Log("Status Code: " + webRequest.responseCode);
            var response = JsonUtility.FromJson<ServerCode>(webRequest.downloadHandler.text);
            Debug.Log(response.message);
            if (response.code == 201)
            {
                _userLogged = userName;
                InitSocket();
            }
        }
    }
    
    public IEnumerator RegisterOnServer(string userName, string password)
    {
        var jsonBody = JsonUtility.ToJson(new CredentialsData(userName, password));
        var webRequest = SetWebRequest(_url + _usersDir + userName, "POST", jsonBody);

        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Debug.Log("Status Code: " + webRequest.responseCode);
            var response = JsonUtility.FromJson<ServerCode>(webRequest.downloadHandler.text);
            Debug.Log(response.message);
            if (response.code == 201)
            {
                
            }
        }
    }
    
    public IEnumerator GetUserFromServer()
    {
        var webRequest = SetWebRequest(_url + _usersDir + _userLogged, "GET");

        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Debug.Log("Status Code: " + webRequest.responseCode);
            var response = JsonUtility.FromJson<ServerCode>(webRequest.downloadHandler.text);
            Debug.Log(response.message);
            saveData.LoadPlayerData(response.User);
        }
    }
    
    public IEnumerator UpdateFieldOnServer(string field, string value)
    {
        var updateData = new UpdateData(_userLogged, field, value);
        var webRequest = SetWebRequest(_url + _usersDir + _userLogged, "PUT", JsonUtility.ToJson(updateData));

        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Debug.Log("Status Code: " + webRequest.responseCode);
            var response = JsonUtility.FromJson<ServerCode>(webRequest.downloadHandler.text);
            Debug.Log(response.message);
            if (response.code == 201)
            {
                
            }
        }
    }
    
    public IEnumerator DeleteUserOnServer(string userName, string password)
    {
        var jsonBody = JsonUtility.ToJson(new CredentialsData(userName, password));
        var webRequest = SetWebRequest(_url + _usersDir + userName, "DELETE", jsonBody);

        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Debug.Log("Status Code: " + webRequest.responseCode);
            var response = JsonUtility.FromJson<ServerCode>(webRequest.downloadHandler.text);
            Debug.Log(response.message);
            if (response.code == 201)
            {
                
            }
        }
    }
    
    public IEnumerator GetRankingFromServer()
    {
        var webRequest = SetWebRequest(_url + _rankingDir, "GET");

        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Debug.Log("Status Code: " + webRequest.responseCode);
            _sRanking.Value = JsonUtility.FromJson<RankingData>(webRequest.downloadHandler.text);
        }
    }
    
    public UnityWebRequest SetWebRequest(string url, string method, string jsonBody)
    {
        var webRequest = new UnityWebRequest
        {
            url = url,
            method = method,
            uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonBody)),
            downloadHandler = new DownloadHandlerBuffer()
        };
        webRequest.SetRequestHeader("Content-Type", "application/json");
        return webRequest;
    }
    
    public UnityWebRequest SetWebRequest(string url, string method)
    {
        var webRequest = new UnityWebRequest
        {
            url = url,
            method = method,
            downloadHandler = new DownloadHandlerBuffer()
        };
        webRequest.SetRequestHeader("Content-Type", "application/json");
        return webRequest;
    }
    #endregion
    
    #region SOCKET_METHODS

    public void InitSocket()
    {
        socket = IO.Socket(_url);

        socket.On(QSocket.EVENT_CONNECT, () => Debug.Log("Connected"));
        socket.On(QSocket.EVENT_DISCONNECT, () => Debug.Log("Disconnected"));
        socket.On(QSocket.EVENT_ERROR, Debug.Log);

        socket.On("updateRanking", (data) => _sRanking.Value = JsonUtility.FromJson<RankingData>(data.ToString()));
#if UNITY_EDITOR
        _socketList.Add(socket);
#endif
    }

    public void UpdateField(UpdateData updateData)
    {
        updateData.userName = _userLogged;
        socket.Emit("updateField", JsonUtility.ToJson(updateData));
    }
    
    public void UpdateField(string field, string value)
    {
        var updateData = new UpdateData(_userLogged, field, value);
        socket.Emit("updateField", JsonUtility.ToJson(updateData));
    }
    
    #endregion

    private void OnDestroy()
    {
        socket?.Disconnect();
    }

    #region SOCKET_EDITOR
#if UNITY_EDITOR
    private static List<QSocket> _socketList = new List<QSocket>();
    
    [InitializeOnEnterPlayMode]
    private static void OnEnterPlaymodeInEditor()
    {
        EditorApplication.playModeStateChanged += LogPlaymodeState;
    }

    private static void LogPlaymodeState(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
            foreach (var socket in _socketList)
                socket?.Disconnect();
        
    }
#endif
    #endregion
}