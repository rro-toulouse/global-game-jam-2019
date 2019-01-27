using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    GameObject baby;
    BabyHealthBar babyHealth;
    BabyPooBar babyPoo;
    BabyWeight babyWeight;

    // Start is called before the first frame update
    void Start()
    {
        baby = GameObject.FindGameObjectWithTag("Baby");
        babyHealth = baby.GetComponent<BabyHealthBar>();
        babyPoo = baby.GetComponent<BabyPooBar>();
        babyWeight = baby.GetComponent<BabyWeight>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            babyHealth.RemoveHealth(10);
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            babyHealth.AddHealth(14);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            babyPoo.AddPoo(14);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            babyPoo.RemovePoo(17);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            babyWeight.AddWeight(17);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            babyWeight.RemoveWeight(17);
        }
    }
}
