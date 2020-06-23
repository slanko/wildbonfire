using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireDropScript : MonoBehaviour
{
    public GameObject E;
    characterScript cScript;
    gameManager gm;
    public GameObject[] cookingMeatz;
    public int meatCount;
    public GameObject cookedMeat;
    // Start is called before the first frame update
    void Start()
    {
        E.SetActive(false);
        gm = GameObject.Find("GOD").GetComponent<gameManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cScript = other.GetComponent<characterScript>();
            if (cScript.stickAmount > 0)
            {
                E.SetActive(true);
                if (Input.GetButtonDown("useKey1") || Input.GetButtonDown("useKey2"))
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
                if (Input.GetButtonDown("useKey1") || Input.GetButtonDown("useKey2"))
                {
                    cScript.dropItem();
                    Invoke("makeMeat", 5);
                    meatCount++;
                    cookingMeatz[meatCount - 1].SetActive(true);
                }
            }
            else
            {
                E.SetActive(false);
            }
        }
    }

    void makeMeat()
    {
        Instantiate(cookedMeat, new Vector3(0, 0.5f, 0), Quaternion.identity);
        cookingMeatz[meatCount - 1].SetActive(false);
        meatCount--;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player" && E.activeSelf == true)
        {
            E.SetActive(false);
        }
    }
}