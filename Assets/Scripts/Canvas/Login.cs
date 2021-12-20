using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : Credentials
{
    public WWWClient webClient;
    public void LogIn()
    {
        if (userName.text == "" || password.text == "")
            errorMessage.text = "All the fields must be completed";
        else
        {
            Comprove();
            if (errorMessage.text == "")
            {
                StartCoroutine(webClient.LogInOnServer(userName.text, password.text));
                SceneManager.LoadScene(1);
            }
            else
            {
                errorMessage.enabled = true;
            }
        }
    }
}
