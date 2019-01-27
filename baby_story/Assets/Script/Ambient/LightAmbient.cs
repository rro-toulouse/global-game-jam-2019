using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAmbient : MonoBehaviour
{
    public float duration = 1f;
    [Range(3f, 10f)]
    public float lightRange = 8f;

    Light pointLight;
    float lightDefault;
    float timer;
    float current;
    float end;
    float velocity = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        timer = duration;
        pointLight = GetComponent<Light>();
        lightDefault = pointLight.intensity;
        end = Random.Range(lightDefault - lightRange / 2, lightDefault + lightRange / 2);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = duration;
            current = pointLight.intensity;
            end = Random.Range(lightDefault - lightRange / 2, lightDefault + lightRange / 2);
        }
        else
        {
            pointLight.intensity = Mathf.SmoothDamp(pointLight.intensity, end, ref velocity, duration);
        }
    }
}
