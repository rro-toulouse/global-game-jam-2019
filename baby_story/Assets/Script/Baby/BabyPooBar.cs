using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabyPooBar : MonoBehaviour
{
    public int maxPoo = 100;
    public int startingPoo = 0;                            // The amount of health the player starts the game with.
    public int currentPoo;                                   // The current health the player has.
    public Slider pooSlider;                                 // Reference to the UI's health bar.
    public Image pooImage;                                   // Reference to an image to flash on the screen on being hurt.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.


    Animator anim;                                              // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.

    bool pooing;

    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // Set the initial health of the player.
        currentPoo = startingPoo;

        pooSlider.value = currentPoo;
    }


    void Update()
    {
        // If the player has just been damaged...
        if (pooing)
        {
            // ... set the colour of the damageImage to the flash colour.
            pooImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            pooImage.color = Color.Lerp(pooImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        pooing = false;
    }

    public void AddPoo(int amount)
    {

        // Set the damaged flag so the screen will flash.
        pooing = true;

        // Reduce the current health by the damage amount.
        currentPoo += amount;

        if (currentPoo >= maxPoo)
            currentPoo = maxPoo;

        // Set the health bar's value to the current health.
        pooSlider.value = currentPoo;

        // Play the hurt sound effect.
        playerAudio.Play();

        Debug.Log("I earnt " + amount + " poo. Poo: " + currentPoo);
    }

    public void RemovePoo(int amount)
    {

        // Reduce the current health by the damage amount.
        currentPoo -= amount;

        if (currentPoo <= 0)
        {
            currentPoo = 0;
        }

        // Set the health bar's value to the current health.
        pooSlider.value = currentPoo;

        // Play the hurt sound effect.
        playerAudio.Play();

        Debug.Log("I cleaned " + amount + " poo. Poo: " + currentPoo);
    }
}
