using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public void StartButton()
    {
        //SceneManager.LoadScene(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BExit()
    {
            Debug.Log("Saliendo");
            Application.Quit();
    }
}
