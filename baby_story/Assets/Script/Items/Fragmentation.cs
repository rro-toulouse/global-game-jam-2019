using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragmentation : MonoBehaviour
{
    public float velX;
    public float velZ;

    public GameObject sons;
    public int sonCount;
    public float lifetime;
    public int maxHits;

    private bool evanescent;
    // Start is called before the first frame update
    void Start()
    {
        evanescent = lifetime > 0;
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(velX, 0, velZ) * rb.mass, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var rb = GetComponent<Rigidbody>();
        if (collision.collider.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            var normal = collision.GetContact(0).normal;

            GameObject son;
            float angle = (sonCount == 1) ? 1 : .6f;
            var angleStep = (sonCount == 1) ? 1: (.8f / (sonCount-1));
            for (int i=0; i< sonCount; i++)
            {
                son = Instantiate(sons);
                son.transform.position = this.transform.position;
                var sonRb = son.GetComponent<Rigidbody>();
                sonRb.AddForce(Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.PI * angle, 0) * -normal * rb.velocity.magnitude * sonRb.mass, ForceMode.Impulse);
                angle += angleStep;
            }
        }
        else if (collision.collider.gameObject.tag == "Wall" && maxHits > 0)
        {
            if (maxHits > 0 && --maxHits == 0) Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Quaternion.Euler(0, 180, 0) * rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (evanescent)
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0.0f) Destroy(gameObject);
        }
    }
}
