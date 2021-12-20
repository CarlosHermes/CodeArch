using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneWarp : MonoBehaviour
{
    
    [SerializeField] private int[] scenenumber;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("choque");
        if (collision.transform.tag == "Player")
            SceneManager.LoadScene(scenenumber[4]);
    }
}
