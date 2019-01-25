using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupcake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        var baby = GameObject.FindGameObjectWithTag("Baby");
        rb.AddForce((baby.transform.position - transform.position).normalized * 10, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Baby")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), other);
            Destroy(gameObject);
        }
    }
}
