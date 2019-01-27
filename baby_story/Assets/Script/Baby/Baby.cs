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
    Vector3 destination = new Vector3();
    public float movingSpeed = 2.0f;
    bool inRotation=false;
    float backDelay=1;
    bool alive=true;


    // Transforms to act as start and end markers for the journey.
     Quaternion startAngle;
     Quaternion endAngle;

    // Movement speed in units/sec.
    public float rotateSpeed = 1000.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyAngle;





    private void OnCollisionEnter(Collision other)

    {
        Debug.Log("Collision");
        float newRotate = 0.0f;
        Vector3 rotateVector = this.transform.localRotation.eulerAngles;
        float currentRotate = rotateVector.z;
        if (other.collider.tag == "Wall")
        {

            setBackRotation();
        }

        if(other.collider.tag=="Ball")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = (this.transform.up * movingSpeed);
        }
        
    }


    public void kill()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);
        alive = false;
        var camera = GameObject.FindGameObjectWithTag("Camera");
        CameraScript cs = camera.GetComponent<CameraScript>();
        cs.onCameraZoom(5,10);
    }




    void setRotation()
    {
        
        Vector3 turn = new Vector3(90, Random.Range(0.0f, 360.0f), 0);
        Quaternion qChange = Quaternion.Euler(turn);
        startAngle = this.transform.localRotation;
        endAngle = qChange;
        journeyAngle = Mathf.Abs(startAngle.eulerAngles.y - endAngle.eulerAngles.y);
        startTime = Time.time;
        inRotation = true;
       
    }

    void setBackRotation()
    {
        if (backDelay < 0)
        {
            backDelay = 0.5f;
            Vector3 currentRotate = transform.localRotation.eulerAngles;
            Vector3 turn = currentRotate + new Vector3(0, Random.Range(90.0f, 270.0f), 0);
            Quaternion qChange = Quaternion.Euler(turn);
            startAngle = this.transform.localRotation;
            endAngle = qChange;
            journeyAngle = Mathf.Abs(startAngle.eulerAngles.y - endAngle.eulerAngles.y);
            startTime = Time.time;
            inRotation = true; 
        }

    }

    private void OnMouseDown()
    {
        setBackRotation();
        BabyHealthBar healthBar = GetComponent<BabyHealthBar>();
        healthBar.RemoveHealth(10);
        this.kill();
    }





    void Update()
    {
        if (alive)
        {
            timeTillChangement -= Time.deltaTime;
            backDelay -= Time.deltaTime;
            Rigidbody rb = GetComponent<Rigidbody>();


            if (inRotation)
            {
                rb.velocity = new Vector3(0, 0, 0);
                float distCovered = (Time.time - startTime) * rotateSpeed;
                float fracJourney = distCovered / journeyAngle;


                transform.localRotation = Quaternion.Lerp(startAngle, endAngle, fracJourney);
                if (fracJourney >= 1)
                {

                    inRotation = false;
                    timeTillChangement = Random.Range(4, 8);




                    rb.velocity = (this.transform.up * movingSpeed);

                }
            }
            if (timeTillChangement <= 0 && !inRotation)
            {
                setBackRotation();
            }
        }
        

    }
    void Start()
    {
        
    }
}