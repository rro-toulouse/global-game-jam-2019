using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject baby;
    void Start()
    {
        baby = GameObject.FindGameObjectWithTag("Baby");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(baby.transform.position.x, this.transform.position.y, baby.transform.position.z);

    }

    void onCameraZoom()
    {
        this.transform.position -= new Vector3(baby.transform.position.x, this.transform.position.y -2.0f, baby.transform.position.z);
    }
}
