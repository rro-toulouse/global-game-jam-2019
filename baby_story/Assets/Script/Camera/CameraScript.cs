using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject baby;
    float delay = 0.0f;
    float zoom;
    bool inZoom = false;
    void Start()
    {
        baby = GameObject.FindGameObjectWithTag("Baby");
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if(inZoom && delay<0)
        {
            this.onCameraMooz();
        }
        this.transform.position = new Vector3(baby.transform.position.x, this.transform.position.y, baby.transform.position.z);
    }

    public void onCameraZoom(float zoom,float time)
    {
        this.transform.position -= new Vector3(baby.transform.position.x, this.transform.position.y -zoom, baby.transform.position.z);
        this.zoom = zoom;
        this.delay = time;
        inZoom = true;
    }

    public void onCameraMooz()
    {
        this.transform.position -= new Vector3(baby.transform.position.x, this.transform.position.y + zoom, baby.transform.position.z);
        inZoom = false;
    }
}
