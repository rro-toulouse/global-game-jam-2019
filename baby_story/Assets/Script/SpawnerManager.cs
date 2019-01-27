using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    //balls
    public GameObject bouncyBall;
    public GameObject bowlingBall;
    public GameObject rugbyBall;
    public GameObject soccerBall;
    public GameObject tennisBall;

    //consumables
    public GameObject alcohol;
    public GameObject biberon;
    public GameObject cupCake;
    public GameObject diaper;
    public GameObject pill;
    public GameObject soap;

    //malus
    public GameObject batterie;
    public GameObject bigBatterie;
    public GameObject gun;
    public GameObject javel;
    public GameObject jerrycan;
    public GameObject knife;
    public GameObject pan;
    public GameObject scissors;
    public GameObject tidePod;
    public GameObject vase;

    GameObject[] wall;
    List<Spawner> spawners = new List<Spawner>();
    GameObject[] neutral;
    GameObject[] consumables;
    GameObject[] malus;
    GameObject[][] items;

    // Start is called before the first frame update
    void Start()
    {
        wall = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject item in wall)
        {
            var spawnerTemp = item.GetComponent<Spawner>();
            if (spawnerTemp != null)
            {
                for (int i=0; i< item.transform.localScale.x; ++i)
                {
                    spawners.Add(spawnerTemp);
                }
            }
        }

        neutral = new GameObject[] { tennisBall, rugbyBall, soccerBall, bouncyBall, bowlingBall };
        consumables = new GameObject[] { biberon, diaper, cupCake, soap, alcohol, pill };
        malus = new GameObject[] { scissors, batterie, knife, pan, vase, javel, bigBatterie, jerrycan, tidePod, gun };
        items = new GameObject[][] { neutral, consumables, malus };

    }

    public int cycle = 0;
    public float timerCycle = 30f;
    public float timer = 1f;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerCycle -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Spawner selectedSpawn = spawners[Random.Range(0, spawners.Count)];
            GameObject selectedObject;
            var type = getItem(cycle, new Type[] { Type.Neutral, Type.Conso, Type.Malus }, getTypeProbas(cycle));
            switch (type)
            {
                case Type.Neutral:
                    selectedObject = getItem(cycle, neutral, getNeutralProbas(cycle));
                    break;
                case Type.Conso:
                    selectedObject = getItem(cycle, consumables, getConsoProbas(cycle));
                    break;
                default:
                    selectedObject = getItem(cycle, malus, getMalusProbas(cycle));
                    break;
            }
            
            selectedSpawn.spawn(selectedObject, getSpeed(cycle));
            timer = getFrequence(cycle);
        }

        if (timerCycle <= 0f)
        {
            cycle++;
            timerCycle = 30f;
        }
    }


    private float cycleTime = 20f;
    float getFrequence(int cycle)
    {
        switch (cycle)
        {
            case 0:
                return 5f;
            case 1:
                return 4f;
            case 2:
                return 3f;
            case 3:
                return 2f;
            case 4:
                return 1f;
            default:
                return .5f;
        }
    }

    int getSpeed(int cycle)
    {
        switch (cycle)
        {
            case 0:
                return Random.Range(3, 8);
            case 1:
                return Random.Range(4, 10);
            case 2:
                return Random.Range(5, 12);
            case 3:
                return Random.Range(7, 14);
            case 4:
                return Random.Range(10, 17);
            default:
                return Random.Range(12, 20);
        }
    }

    enum Type { Neutral, Conso, Malus}
    float[] getTypeProbas(int cycle)
    {
        switch (cycle)
        {
            case 0:
                return new float[] { 1, 1, 0 };
            case 1:
                return new float[] { 1, 2, 1 };
            case 2:
                return new float[] { 1, 3, 2 };
            case 3:
                return new float[] { 1, 3, 3 };
            case 4:
                return new float[] { 1, 2, 3 };
            default:
                return new float[] { 1, 1, 2 };
        }
    }

    //neutral = new GameObject[] { tennisBall, rugbyBall, soccerBall, bouncyBall, bowlingBall};
    float[] getNeutralProbas(int cycle)
    {
        switch (cycle)
        {
            case 0:
                return new float[] { 1, 0, 0, 0, 0 };
            case 1:
                return new float[] { 1, 1, 0, 0, 0 };
            case 2:
                return new float[] { 2, 1, 1, 0, 0 };
            case 3:
                return new float[] { 2, 2, 1, 1, 0 };
            case 4:
                return new float[] { 0, 2, 2, 1, 1 };
            default:
                return new float[] { 0, 0, 2, 2, 3 };
        }
    }

    //consumables = new GameObject[] { biberon, diaper, cupCake, soap, alcohol, pill };
    float[] getConsoProbas(int cycle)
    {
        switch (cycle)
        {
            case 0:
                return new float[] { 1, 1, 0, 0, 0, 0 };
            case 1:
                return new float[] { 1, 0, 1, 0, 0, 0 };
            case 2:
                return new float[] { 1, 1, 1, 1, 0, 0 };
            case 3:
                return new float[] { 2, 1, 2, 1, 0, 0 };
            case 4:
                return new float[] { 1, 1, 3, 1, 1, 1 };
            default:
                return new float[] { 1, 1, 1, 2, 3, 3 };
        }
    }

    //malus = new GameObject[] { scissors, batterie, knife, pan, vase, javel, bigBatterie, jerrycan, tidePod, gun};
    float[] getMalusProbas(int cycle)
    {
        switch (cycle)
        {
            case 0:
                return new float[] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
            case 1:
                return new float[] { 2, 2, 1, 1, 0, 0, 0, 0, 0, 0 };
            case 2:
                return new float[] { 1, 1, 2, 2, 1, 1, 0, 0, 0, 0 };
            case 3:
                return new float[] { 1, 1, 2, 2, 3, 3, 1, 1, 0, 0 };
            case 4:
                return new float[] { 0, 0, 1, 1, 2, 2, 3, 3, 1, 1 };
            default:
                return new float[] { 0, 0, 0, 0, 1, 1, 1, 2, 2, 3 };
        }
    }

    T getItem<T>(int cycle, T[] array, float[] probas)
    {
        var sum = 0f;
        foreach(float f in probas) { sum += f; }
        var rand = Random.Range(0f, sum);
        //Debug.Log("random : " + rand + " in " + System.String.Join(", ", probas));

        var lowThreshold = 0f;
        var upThreshold = 0f;
        var res = array[array.Length-1];
        for (int i=0; i< array.Length; i++)
        {
            upThreshold += probas[i];
            if (lowThreshold <= rand && rand <= upThreshold)
            {
                res = array[i];
                break;
            }
            lowThreshold += probas[i];

        }
        //Debug.Log("selected : " + res);
        return res;
    }
}
