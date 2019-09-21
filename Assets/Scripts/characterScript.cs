using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterScript : MonoBehaviour
{

    public KeyCode upKey, downKey, leftKey, rightKey, attackKey, useKey, sprintKey;

    public float health, moveSpeed, rotateSpeed;

    GameObject animMan;

    Animator anim;

    public Text healthText;

    //get camera parent object so the camera can follow without taking the player's rotation as well
    public GameObject cCamera;

    // Start is called before the first frame update
    void Start()
    {
        animMan = GameObject.Find(transform.name + "/everyman");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
                animMan.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 270, 0), rotateSpeed);
                transform.Translate(((Vector3.left) * moveSpeed) * Time.deltaTime);
            }
            if (Input.GetKey(rightKey))
            {
                animMan.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), rotateSpeed);
                transform.Translate((Vector3.right * moveSpeed) * Time.deltaTime);
            }
            if (Input.GetKey(upKey))
            {
                animMan.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotateSpeed);
                transform.Translate((Vector3.forward * moveSpeed) * Time.deltaTime);
            }
            if (Input.GetKey(downKey))
            {
                animMan.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), rotateSpeed);
                transform.Translate(((Vector3.forward * -1) * moveSpeed) * Time.deltaTime);
            }
            if (Input.GetKey(leftKey) && Input.GetKey(upKey))
            {
                animMan.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 315, 0), rotateSpeed);
            }
            if (Input.GetKey(leftKey) && Input.GetKey(downKey))
            {
                animMan.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 230, 0), rotateSpeed);
            }
            if (Input.GetKey(rightKey) && Input.GetKey(upKey))
            {
                animMan.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 45, 0), rotateSpeed);
            }
            if (Input.GetKey(rightKey) && Input.GetKey(downKey))
            {
                animMan.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 135, 0), rotateSpeed);
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
}