using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugbyBall : MonoBehaviour
{
    public float velX;
    public float velZ;
    public float cone;

    public float lifetime;
    public int maxHits;
    public int maxRebounds;
    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(velX, 0, velZ) * rb.mass, ForceMode.Impulse);
    }

    void OnMouseDown()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Quaternion.Euler(0, 180 + Mathf.Rad2Deg * Mathf.PI * Random.Range(1 - cone, 1 + cone), 0) * rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Wall")
        {
            if (maxRebounds > 0 && --maxRebounds == 0) Destroy(gameObject);
            else
            {
                var normal = collision.GetContact(0).normal;
                var rb = GetComponent<Rigidbody>();
                var angle = Mathf.Acos(Vector3.Dot(rb.velocity.normalized, -normal)) / Mathf.PI;

                rb.velocity = Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.PI * Random.Range(1 - cone, 1 + cone), 0) * -normal * rb.velocity.magnitude;
                //if (0.5 < angle && angle <= .75) //4
                //{
                //    Debug.Log("4");
                //    rb.velocity = Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.PI * Random.Range(.75f,1.25f), 0) * -normal * rb.velocity.magnitude;
                //}
                //else if (.75 < angle && angle <= 1) //3
                //{
                //    Debug.Log("3");
                //    rb.velocity = Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.PI * Random.Range(.75f, 1.25f), 0) * -normal * rb.velocity.magnitude;
                //}
                //else if (1 < angle && angle <= 1.25) //2
                //{
                //    Debug.Log("2");
                //    rb.velocity = Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.PI * Random.Range(.75f, 1.25f), 0) * -normal * rb.velocity.magnitude;
                //}
                //else if (1.25 < angle && angle <= 1.5) //1
                //{
                //    Debug.Log("1");
                //    rb.velocity = Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.PI * Random.Range(.75f, 1.25f), 0) *- normal * rb.velocity.magnitude;
                //}
                //else
                //{
                //    Debug.Log("WTF!!!");
                //}
            }
        }
        else if (collision.collider.gameObject.tag == "Wall" && maxHits > 0)
        {
            if (maxHits > 0 && --maxHits == 0) Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (lifetime <= 0) Destroy(gameObject);
    }
}
