using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeModels : MonoBehaviour
{
    public Object[] prefabModels;
    public GameObject[] instantiatedModels;
    private int i = 0;
    private float cooldown = 3f, nextItem = 3f;
    private Coroutine actualCor;
    private void Awake()
    {
        instantiatedModels = new GameObject[prefabModels.Length];
    }
    private void Update()
    {
        if(Time.time>=nextItem)
        {
            if (instantiatedModels[i] != null)
                instantiatedModels[i].SetActive(false);
            Previous();
            if (instantiatedModels[i] != null)
                instantiatedModels[i].SetActive(true);
            else
                instantiatedModels[i] = Instantiate(prefabModels[i], this.transform.position, this.transform.rotation) as GameObject;
            nextItem += cooldown;
        }
    }
    public void Next()
    {
        i = (i + 1) % prefabModels.Length;
    }
    public void Previous()
    {
        i = (i - 1) < 0 ? prefabModels.Length-1 : i - 1;
    }
    public void RotateLeft()
    {
        if(actualCor !=null)
            StopCoroutine(actualCor);
        actualCor = StartCoroutine(Rotate(10f, 0.2f, -1f));
    }
    public void RotateRight()
    {
        if (actualCor != null)
            StopCoroutine(actualCor);
        actualCor = StartCoroutine(Rotate(10f, 0.2f, 1f));
    }
    IEnumerator Rotate(float max, float intervals, float sign)
    {
        for (float j = 0; j < max; j = j + intervals)
        {
            instantiatedModels[i].transform.Rotate(0, sign, 0);
            Debug.Log("giro" + sign);
            yield return new WaitForSeconds(intervals);
        }
    }
}
