using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BabyHealthBar : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

    Animator anim;                                              // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
    bool healing;                                               // True when the player gets damaged.

    float deathCountDown = 5;
    GameObject gameUiTimer;

    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // Set the initial health of the player.
        currentHealth = startingHealth;

        healthSlider.value = currentHealth;
    }


    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;

        // If is dead, start Game Over menu after 5 sec. 
        if (isDead)
        {
           deathCountDown -= Time.deltaTime;

            if (deathCountDown <= 0.0f)
            {
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
        }
    }

    public void AddHealth(int amount)
    {

        // Set the damaged flag so the screen will flash.
        healing = true;

        // Reduce the current health by the damage amount.
        currentHealth += amount;

        if (currentHealth >= startingHealth)
            currentHealth = startingHealth;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        playerAudio.Play();

        Debug.Log("I earnt " + amount + " hp. HP: " + currentHealth);
    }

    public void RemoveHealth(int amount)
    {

        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }

        Debug.Log("I took " + amount + " damages. HP: " + currentHealth);
    }

    void Death()
    {
        GetComponent<BoxCollider>().enabled = false;

        //Stop the timer
        gameUiTimer = GameObject.FindGameObjectWithTag("Timer");
        var gameTimer = gameUiTimer.GetComponent<UiTimer>();
        gameTimer.StopTimer();

        //Time.timeScale = 0f;

        // Set the death flag so this function won't be called again.
        isDead = true;

       // anim.speed = 0;

        // Tell the animator that the player is dead.
        anim.SetTrigger("Kill");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        playerAudio.clip = deathClip;
        playerAudio.Play();

        this.GetComponent<Baby>().kill();
    
    }
}
