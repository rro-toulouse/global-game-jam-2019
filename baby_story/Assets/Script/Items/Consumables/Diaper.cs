using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diaper : MonoBehaviour
{
    public float velX;
    public float velZ;

    public float lifetime;
    public int maxRebounds;
    public int healPoop;

    private bool evanescent;
    private bool homing = false;
    private GameObject baby;
    private BabyHealthBar babyHealth;
    private BabyPooBar babyPoo;
    // Start is called before the first frame update
    void Start()
    {
        baby = GameObject.FindGameObjectWithTag("Baby");
        babyHealth = baby.GetComponent<BabyHealthBar>();
        babyPoo = baby.GetComponent<BabyPooBar>();

        evanescent = lifetime > 0;
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(velX, 0, velZ) * rb.mass, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Wall")
        {
            if (maxRebounds > 0 && --maxRebounds == 0) Destroy(gameObject);

            var normal = collision.GetContact(0).normal;

            var baby = GameObject.FindGameObjectWithTag("Baby");
            var toBaby = (baby.transform.position - transform.position).normalized;

            var angle = Mathf.Acos(Vector3.Dot(toBaby, -normal)) / Mathf.PI;
            if (angle <= .5 || angle >= 1.5)
            {
                Destroy(gameObject);
            }
            else
            {
                var rb = GetComponent<Rigidbody>();
                rb.velocity = toBaby * rb.velocity.magnitude;
                homing = true;
            }
        }
        else if (collision.collider.gameObject.tag == "Baby")
        {
            Debug.Log("baby new diaper");
            babyPoo.CleanPoo(healPoop);
            Destroy(gameObject);
        }

    }

    void OnMouseDown()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Quaternion.Euler(0, 180, 0) * rb.velocity;
        homing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (evanescent)
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0.0f) Destroy(gameObject);
        }
        if (homing)
        {
            var baby = GameObject.FindGameObjectWithTag("Baby");
            var toBaby = (baby.transform.position - transform.position).normalized;
            var rb = GetComponent<Rigidbody>();
            rb.velocity = toBaby * rb.velocity.magnitude;
        }
    }
}
