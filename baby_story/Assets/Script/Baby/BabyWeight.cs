using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyWeight : MonoBehaviour
{
    public int currentWeight;
    public int startWeight = 0;
    public int maxWeight = 100;
    public float maxScale = 1.5f;

    Vector3 defaultScale;

    // Start is called before the first frame update
    void Start()
    {
        defaultScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddWeight(int amount)
    {
        currentWeight += amount;

        if (currentWeight >= maxWeight)
            currentWeight = maxWeight;

        float delta = ((float)currentWeight / (float)maxWeight) * (float)maxScale;

        this.transform.localScale = new Vector3(defaultScale.x + delta,
            defaultScale.y + delta,
            defaultScale.z + delta);
            
    
        Debug.Log("I added " + amount + " weight. Weight: " + currentWeight);
    }

    public void RemoveWeight(int amount)
    {
        currentWeight -= amount;

        if (currentWeight <= 0)
            currentWeight = 0;

        float delta = ((float)currentWeight / (float)maxWeight) * (float)maxScale;

        this.transform.localScale = new Vector3(defaultScale.x + delta,
        defaultScale.y + delta,
        defaultScale.z + delta);

        Debug.Log("I lost " + amount + " weight. Weight: " + currentWeight);
    }
}
