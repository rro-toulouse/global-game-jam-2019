using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBall : MonoBehaviour
{

    public float velX;
    public float velZ;
    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(velX, 0, velZ), ForceMode.Impulse);
    }

    void OnMouseDown()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Quaternion.Euler(0, 180, 0) * rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
