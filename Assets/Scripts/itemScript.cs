using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemScript : MonoBehaviour
{

    Rigidbody rb;
    Light objectLight;
    characterScript cScript;
    public bool Stick, Meat, cookedMeat;
    // Start is called before the first frame update
    void Awake()
    {
        transform.parent = null;
        cScript = GameObject.Find("Player").GetComponent<characterScript>();
        objectLight = GetComponent<Light>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(-1, 1), 10, Random.Range(-1, 1)), ForceMode.Impulse);
        rb.AddTorque(new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), Random.Range(-90, 90)), ForceMode.Impulse);
        objectLight.intensity = 0;
        if(Stick == true && Meat == true)
        {
            print("Removed " + transform.name + " because it had too many types. Set either Meat or Stick, not both you dingus.");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
        {
            objectLight.intensity = 1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cScript = other.GetComponent<characterScript>();
            if (Input.GetButtonDown("useKey1"))
            {
                shamoozle();
            }
        }
        if(other.gameObject.tag == "Player2")
        {
            cScript = other.GetComponent<characterScript>();
            if (Input.GetButtonDown("useKey2"))
            {
                shamoozle();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
        {
            objectLight.intensity = 0;
        }
    }

    public void shamoozle()
    {
        if (Stick == true)
        {
            if (cScript.meatAmount == 0)
            {
                if (cScript.stickAmount <= 3)
                {
                    cScript.stickAmount++;
                    cScript.stickz[cScript.stickAmount - 1].SetActive(true);
                    Destroy(gameObject);
                }
            }
        }
        if (Meat == true)
        {
            if (cScript.stickAmount == 0)
            {
                if (cScript.meatAmount <= 3)
                {
                    cScript.meatAmount++;
                    cScript.meatz[cScript.meatAmount - 1].SetActive(true);
                    Destroy(gameObject);
                }
            }
        }

        if (cookedMeat == true)
        {
            cScript.hunger = cScript.hunger + 10;
            Destroy(gameObject);
        }
    }
}