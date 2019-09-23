using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterScript : MonoBehaviour
{

    Slider hungerBar;

    public KeyCode upKey, downKey, leftKey, rightKey, attackKey, useKey, sprintKey;

    public float health, hunger, moveSpeed, rotateSpeed, hungerDeplenishRate;

    public int stickAmount, meatAmount;

    GameObject animMan;

    public GameObject[] stickz, meatz;

    Animator anim;

    public Text healthText;

    fireDropScript fireScript;

    //get camera parent object so the camera can follow without taking the player's rotation as well
    public GameObject cCamera;

    // Start is called before the first frame update
    void Start()
    {
        fireScript = GameObject.Find("FireDropRadius").GetComponent<fireDropScript>();
        hungerBar = GameObject.Find("Canvas/Slider").GetComponent<Slider>();
        animMan = GameObject.Find(transform.name + "/everyman");
        anim = GameObject.Find(transform.name + "/everyman/maincharacter").GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hungerBar.value = hunger;

        hunger = hunger - hungerDeplenishRate * Time.deltaTime;

        health = health + hunger * 0.02f * Time.deltaTime;

        if(stickAmount > 3)
        {
            stickAmount = 3;
        }
        if(meatAmount > 3)
        {
            meatAmount = 3;
        }
        if(health > 100)
        {
            health = 100;
        }

        //display health
        healthText.text = health.ToString();

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        //camera follow script
        cCamera.transform.position = transform.position;

        if (Input.GetKeyDown(attackKey))
        {
            anim.SetTrigger("axeSwing");
        }

        //actual movement inputs (this is embarrasing code but it works)
        if(health > 0)
        {
            if (Input.GetKey(leftKey))
            {
                animMan.transform.rotation = Quaternion.Euler(0, 270, 0);
                transform.Translate(((Vector3.left) * moveSpeed) * Time.deltaTime);
            }
            if (Input.GetKey(rightKey))
            {
                animMan.transform.rotation = Quaternion.Euler(0, 90, 0);
                transform.Translate((Vector3.right * moveSpeed) * Time.deltaTime);
            }
            if (Input.GetKey(upKey))
            {
                animMan.transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.Translate((Vector3.forward * moveSpeed) * Time.deltaTime);
            }
            if (Input.GetKey(downKey))
            {
                animMan.transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.Translate(((Vector3.forward * -1) * moveSpeed) * Time.deltaTime);
            }
            if (Input.GetKey(leftKey) && Input.GetKey(upKey))
            {
                animMan.transform.rotation = Quaternion.Euler(0, 315, 0);
            }
            if (Input.GetKey(leftKey) && Input.GetKey(downKey))
            {
                animMan.transform.rotation = Quaternion.Euler(0, 230, 0);
            }
            if (Input.GetKey(rightKey) && Input.GetKey(upKey))
            {
                animMan.transform.rotation = Quaternion.Euler(0, 45, 0);
            }
            if (Input.GetKey(rightKey) && Input.GetKey(downKey))
            {
                animMan.transform.rotation = Quaternion.Euler(0, 135, 0);
            }

            if(Input.GetKey(upKey) || Input.GetKey(downKey) || Input.GetKey(leftKey) || Input.GetKey(rightKey))
            {
                anim.SetBool("movementkeypressed", true);
            }
            else
            {
                anim.SetBool("movementkeypressed", false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "smallEnemyWeapon")
        {
            health = health - Random.Range(8, 12);
        }
        if(other.tag == "mediumEnemyWeapon")
        {
            health = health - Random.Range(13, 17);
        }
        if(other.tag == "bigEnemyWeapon")
        {
            health = health - Random.Range(18, 22);
        }
    }

    public void dropItem()
    {
        if(stickAmount > 0)
        {
            stickz[stickAmount - 1].SetActive(false);
            stickAmount--;
        }
        if(meatAmount > 0)
        {
            meatz[meatAmount - 1].SetActive(false);
            meatAmount--;
        }
    }
}