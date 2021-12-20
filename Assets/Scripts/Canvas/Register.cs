using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Register : Credentials
{
    public TMP_InputField password2;
    public WWWClient webClient;
    public void RegIster()
    {
        if (userName.text == "" || password.text == "" || password2.text == "")
            errorMessage.text = "All the fields must be completed";
        else
        {
            Comprove();
            errorMessage.text = string.Compare(password.text, password2.text, false) == 1 || password.text.Length != password2.text.Length? errorMessage.text + "Password: Passwords don't coincide" : errorMessage.text;
        }
        if (errorMessage.text == "")
        {
            Debug.Log(password.text.GetHashCode());
            Debug.Log("Register succeeded");
            StartCoroutine(webClient.RegisterOnServer(userName.text, password.text));
        }
        else
        {
            errorMessage.enabled = true;        }
    }
}
