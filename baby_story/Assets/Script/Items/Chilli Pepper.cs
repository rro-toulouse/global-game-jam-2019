using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChilliPepper : MonoBehaviour
{
    public float velX;
    public float velZ;

    public float lifetime;
    public int maxRebounds;

    private bool evanescent;
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
            if (maxRebounds > 0 && --maxRebounds == 0)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.collider.gameObject.tag == "Baby")
        {
            Debug.Log("baby cuts itself");
            var camera = GameObject.FindGameObjectWithTag("Camera");
            CameraScript cs = camera.GetComponent<CameraScript>();
            cs.onCameraZoom(2, 4);
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        var rb = GetComponent<Rigidbody>();
        var baby = GameObject.FindGameObjectWithTag("Baby");
        rb.velocity = (transform.position - baby.transform.position).normalized * rb.velocity.magnitude;
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
