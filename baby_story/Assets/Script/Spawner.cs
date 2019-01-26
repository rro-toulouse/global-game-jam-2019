using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject scissors;
    private List<GameObject> poped = new List<GameObject>();
    private float speed;
    private int delta_y = 10;
    public int nb_scissors = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < nb_scissors ; ++i)
        {
            GameObject new_item = Instantiate(scissors);
            new_item.transform.position = this.transform.position;
            new_item.transform.position = new Vector3(new_item.transform.position.x,
                                                        new_item.transform.position.y + delta_y * i,
                                                        new_item.transform.position.z);
            poped.Add(new_item);
        }
        foreach (var item in poped)
        {
            Destroy(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
