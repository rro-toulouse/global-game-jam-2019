using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsPages : MonoBehaviour
{
    public Sprite[] sprites;
    public float timer = 2f;

    float current;
    public Image imageDisplayed;
    int i = 0;

    private void Start()
    {
        imageDisplayed = this.gameObject.GetComponent<Image>();
        imageDisplayed.enabled = false;
        current = timer;
    }

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (imageDisplayed.enabled)
            current -= Time.deltaTime;
        if (current <= 0)
        {
            if (i < sprites.Length)
            {
                imageDisplayed.sprite = sprites[i++];
                current = timer;
            }
            else
                gameObject.SetActive(false);
        }
    }
}
