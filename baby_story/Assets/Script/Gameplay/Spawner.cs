using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject sons;
    public float speed;
    private float lifetime = 1f;

    // Start is called before the first frame update
    void Start()
    {
  
    }

   public void spawn(GameObject son, float speed)
    {
        var normal = this.transform.forward;
        var length = this.transform.localScale.x;

        var x = this.transform.position.x;
        var y = son.transform.position.y;
        var z = this.transform.position.z;

        GameObject new_item = Instantiate(son);
        new_item.transform.position = new Vector3(x, y, z);
        new_item.transform.position += this.transform.forward * (this.transform.localScale.z/2 + son.transform.position.y);
        new_item.transform.position += this.transform.right * (Random.Range(this.transform.position.y, length- this.transform.position.y) - length / 2);
        var sonRb = new_item.GetComponent<Rigidbody>();
        var force = Quaternion.Euler(0, Random.Range(-70, 70), 0) * -normal * speed * sonRb.mass;
        sonRb.AddForce(force, ForceMode.Impulse);

        Debug.Log($"wall : " + this.transform.position +
                $" son : " + new_item.transform.position +
                $" force" + force);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
