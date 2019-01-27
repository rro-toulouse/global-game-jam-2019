using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickParticle : MonoBehaviour
{
    public ParticleSystem particles;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 pos = r.GetPoint(16);
            ParticleSystem particleSystem = Instantiate(particles, pos, Quaternion.identity);
            Destroy(particleSystem, particleSystem.main.duration);
        }
    }
}
