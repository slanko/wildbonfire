using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogLow : MonoBehaviour
{
    public GameObject ThisTree;
    public GameObject TheLog;
    public GameObject FakeLog;
    public Rigidbody rbLeft;
    public Rigidbody rbRight;
    public float launchAmount;
    public ParticleSystem woodParticle;
    public float destroyDelay;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            TheLog.SetActive(false);
            FakeLog.SetActive(true);
            UnParentParticle();
            rbLeft.AddForce(transform.forward * launchAmount, ForceMode.Impulse);
            rbRight.AddForce(transform.forward * launchAmount, ForceMode.Impulse);
            Destroy(ThisTree, destroyDelay);

        }
    }
    private void UnParentParticle()
    {
        woodParticle.Play();
        woodParticle.transform.parent = ThisTree.transform;

        woodParticle.transform.parent = null;
    }
}
