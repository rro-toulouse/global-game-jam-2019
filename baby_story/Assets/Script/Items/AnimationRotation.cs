using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRotation : MonoBehaviour
{
    public float speed = 400f;

    public AudioClip[] sampleList;
    AudioSource playerAudio;

    private void Start()
    {
        playerAudio = GameObject.FindGameObjectWithTag("Baby").GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Baby")
        {
            playerAudio.PlayOneShot(sampleList[Random.Range(0, sampleList.Length)]);
        }
    }

// Update is called once per frame
void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
