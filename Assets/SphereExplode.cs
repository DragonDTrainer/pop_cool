using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereExplode : MonoBehaviour
{
    public ParticleSystem particle;
    private IEnumerator Start()
    {
        
        yield return new WaitForSeconds(1f);
        GetComponent<MeshRenderer>().enabled = false;
        particle.Play();
    }
}
