using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePass : MonoBehaviour
{
    private LoadingManager _loadingManager;
    private void Start()
    {
        _loadingManager = LoadingManager.instance;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            _loadingManager.LoadGame();
        }
    }
}
