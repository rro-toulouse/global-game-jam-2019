using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Baby : MonoBehaviour
{
    float timeTillChangement;
    float timeInMovement;
    float currentRoomSize;
    float xNextDoor;
    float yNextDoor;
    int moveInRoom;
    float currentOrientation;
    public NavMeshAgent agent;
    Vector3 destination = new Vector3();
    public float lowZ;
    public float highZ;
    public float lowX;
    public float highX;





    private void OnCollisionEnter(Collision other)

    {
       /* Debug.Log("Collision1");
        float newRotate = 0.0f;
        float currentRotate=this.transform.localRotation.y;
        if (other.collider.tag == "Wall")
        {
            newRotate = currentRotate <= 180 ? currentRotate + 90 : currentRotate - 90;
            this.transform.Rotate(new Vector3(0, newRotate, 0));
            Rigidbody rb = GetComponent<Rigidbody>();

            rb.velocity = (transform.forward*2);
            Debug.Log("Collision2");
        }*/
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        
        if (other.tag == "Wall")
        {
            Debug.Log("trig2");
            Vector3 triScale = other.transform.localScale;
            currentRoomSize = triScale.x + triScale.z;
            moveInRoom = 0;
            Debug.Log(currentRoomSize);
        }
    }

    void Update()
    {
        currentOrientation = this.transform.rotation.y;
        timeInMovement+= Time.deltaTime;
        timeTillChangement -= Time.deltaTime;
        Rigidbody rb = GetComponent<Rigidbody>();
        Debug.Log(agent.velocity);
        if(timeTillChangement <= 0 || (agent.velocity== new Vector3(0,0,0) && timeInMovement>1))
        {


            destination = new Vector3(Random.Range(lowX, highX), 0, Random.Range(lowZ, highZ));

            agent.SetDestination(destination);
            /*
            this.transform.Rotate(new Vector3(0, Random.Range(0.0f, 360.0f), 0));
            rb.velocity=(transform.forward * 2);*/
            timeTillChangement = Random.Range(7.0f, 15.0f);
            timeInMovement = 0;
            
        }
    }
}
