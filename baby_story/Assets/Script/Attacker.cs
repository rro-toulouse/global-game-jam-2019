using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    GameObject baby;
    BabyHealthBar babyHealth;
    BabyPooBar babyPoo;

    // Start is called before the first frame update
    void Start()
    {
        baby = GameObject.FindGameObjectWithTag("Baby");
        babyHealth = baby.GetComponent<BabyHealthBar>();
        babyPoo = baby.GetComponent<BabyPooBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            babyHealth.TakeDamage(10);
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            babyHealth.EarnHealth(14);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            babyPoo.EarnPoo(14);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            babyPoo.CleanPoo(17);
        }
    }
}
