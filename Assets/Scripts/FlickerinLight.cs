using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerinLight : MonoBehaviour
{
    public Light light;
    private float minIntensity = 0.4f;
    private float maxIntensity = 0.7f;
    private float currentTime;
    private float flickTime = 0.1f;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = flickTime;
        light = GetComponent<Light>();    
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        { 
            light.intensity = Random.Range(minIntensity, maxIntensity);
            timer = flickTime;
        }
    }

 
}
