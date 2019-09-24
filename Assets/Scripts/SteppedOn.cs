using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteppedOn : MonoBehaviour
{
    private ParticleSystem Bones;
    // Start is called before the first frame update
    void Start()
    {
        Bones = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Bones.Play();
    }
}
