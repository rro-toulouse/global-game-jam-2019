using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{

    public float velX;
    public float velZ;
    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(velX, 0, velZ), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
