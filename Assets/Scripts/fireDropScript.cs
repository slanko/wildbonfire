using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireDropScript : MonoBehaviour
{
    public GameObject E;
    characterScript cScript;
    gameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        E.SetActive(false);
        cScript = GameObject.Find("Player").GetComponent<characterScript>();
        gm = GameObject.Find("GOD").GetComponent<gameManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (cScript.stickAmount > 0)
            {
                E.SetActive(true);
                if (Input.GetKeyDown(cScript.useKey))
                {
                    cScript.dropItem();
                    gm.fireAmount = gm.fireAmount + 2;
                }
            }
            else
            {
                E.SetActive(false);
            }
            if (cScript.meatAmount > 0)
            {
                E.SetActive(true);
                if (Input.GetKeyDown(cScript.useKey))
                {
                    cScript.dropItem();
                    cScript.hunger = cScript.hunger + 10;
                }
            }
            else
            {
                E.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player" && E.activeSelf == true)
        {
            E.SetActive(false);
        }
    }
}