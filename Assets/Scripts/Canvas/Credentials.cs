using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Credentials : MonoBehaviour
{
    public Text errorMessage;
    public TMP_InputField userName, password;
    public void Awake()
    {
        errorMessage.text = "";
    }
    
    public virtual void Comprove()
    {
        errorMessage.text = userName.text.Length > 12 ? "Username: Max length surpassed\n" : "";
        errorMessage.text = userName.text.Length < 5 ? "Username: Min length not reached\n" : "";
        errorMessage.text = password.text.Length < 2 ? errorMessage.text + "Password: Too weak\n" : errorMessage.text;
    }
}
