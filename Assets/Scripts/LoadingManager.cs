using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager instance;
    public GameObject loadingScreen;
    public ProgressBar bar;
    public Sprite[] sprites;
    public Image backgroundImage;
    public int scene;
    float totalSceneProgress;
    [SerializeField] private int _parts;
    int prueba = 0;

    //public GameObject camera;


    private void Awake()
    {
        if(!instance)
            instance = this;
        //SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU, LoadSceneMode.Additive);
    }

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
   public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true);
        StartCoroutine("GetSceneLoadProgress");
        //LoadSceneMode.Additive));
        //SceneManager.SetActiveScene(Scene(scene));
        //scenesLoading.Add (SceneManager.UnloadSceneAsync(--scene));
        //scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.GAMESCENE2, LoadSceneMode.Additive));
        //scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.GAMESCENE3, LoadSceneMode.Additive));


    }

   public IEnumerator GetSceneLoadProgress()
    {
        for (int j = 0; j < _parts; j++)
        {
            bar.current = j;
            if (j==_parts/100*87)
                scenesLoading.Add(SceneManager.LoadSceneAsync(++scene));
            yield return new WaitForSeconds((0.01f));
        }
        /*
        while (!scenesLoading[0].isDone)
        {
            foreach (AsyncOperation operation in scenesLoading)
                totalSceneProgress += operation.progress;
            totalSceneProgress = (totalSceneProgress / scenesLoading.Count) * 100f;
            yield return new WaitForSeconds(0.1f);
            yield return null;
        }*/

        //camera.SetActive(false);
        loadingScreen.gameObject.SetActive(false);
    }
}
