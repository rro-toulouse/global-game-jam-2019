using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    float timeTillChangement;
    float currentRoomSize;
    float xNextDoor;
    float yNextDoor;
    int moveInRoom;





   /* private void OnCollisionEnter(Collider other)

    
    
    {
        /*float newRotate = 0.0f;
        float currentRotate=this.transform.localRotation.y;

        newRotate=currentRotate <= 180 ?  currentRotate + 180 :  currentRotate - 180;
        this.transform.Rotate(new Vector3(0, newRotate, 0));
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity=(transform.forward );
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        Vector3 triScale =other.transform.localScale;
        currentRoomSize= triScale.x + triScale.z;
        moveInRoom = 0;
        Debug.Log(currentRoomSize);
    }

    void Update()
    {
        timeTillChangement -= Time.deltaTime;
        if(timeTillChangement <= 0)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            this.transform.Rotate(new Vector3(0, Random.Range(0.0f, 360.0f), 0));
            rb.velocity=(transform.forward );
            timeTillChangement = Random.Range(7.0f, currentRoomSize);
            
        }
    }
}
