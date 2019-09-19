using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour
{

    public KeyCode upKey, downKey, leftKey, rightKey, attackKey, useKey, sprintKey;

    public float moveSpeed, rotateSpeed;

    GameObject animMan;

    //get camera parent object so the camera can follow without taking the player's rotation as well
    public GameObject cCamera;

    // Start is called before the first frame update
    void Start()
    {
        animMan = GameObject.Find(transform.name + "/everyman");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //camera follow script
        cCamera.transform.position = transform.position;

        //make the model rotate based on the direction it is travelling

        //actual movement inputs
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