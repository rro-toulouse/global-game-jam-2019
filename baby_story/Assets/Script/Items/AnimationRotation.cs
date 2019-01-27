using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRotation : MonoBehaviour
{
    public float speed = 400f;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
