using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private FloatVariable _hp;
    private void OnEnable()
    {
        Pause();
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void LoadMenu()
    {
        _hp.Value = 1000f;
        SceneManager.LoadScene(1);
    }
    public void RestartScene()
    {
        _hp.Value = 1000f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
    public void QuitGame()
    {
        Application.Quit();
    }
}
