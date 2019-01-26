using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public float timer = 5f;
    public GameObject cupCake;
    public GameObject tennisBall;
    public GameObject bouncyBall;
    public GameObject rugbyBall;
    public GameObject homing;
    public GameObject sissors;
    GameObject[] wall;
    List<Spawner> spawners = new List<Spawner>();
    Random random = new Random();
    GameObject[] sons;

    // Start is called before the first frame update
    void Start()
    {
        
        wall = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject item in wall)
        {
            var spawnerTemp = item.GetComponent<Spawner>();
            if (spawnerTemp != null)
            {
                spawners.Add(spawnerTemp);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            sons = new GameObject[] { cupCake, tennisBall, bouncyBall, rugbyBall, homing, sissors };
            Spawner selectedSpawn = spawners[Random.Range(0, spawners.Count)];
            GameObject selectedObject = sons[Random.Range(0, sons.Length)];
            float objectSpeed = Random.Range(1, 10);
            selectedSpawn.spawn(selectedObject, objectSpeed);
            timer = 5f;
        }
    }
}
