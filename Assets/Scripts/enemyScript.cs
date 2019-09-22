﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{
    Animator anim;
    NavMeshAgent nav;
    Vector3 navPos;
    bool chasing = false;
    GameObject player;
    gameManager gm;
    characterScript cScript;
    ParticleSystem blood;

    public float health = 10;
    public float dtd, attackThreshold, chaseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        blood = GameObject.Find(transform.name + "/Blood").GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        //start changeposition once here because after that it calls itself
        changePosition();
        //find gamemanager and characterscripts so we can use the variables later
        gm = GameObject.Find("GOD").GetComponent<gameManager>();
        cScript = player.GetComponent<characterScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dtd = Vector3.Distance(player.transform.position, transform.position);
        if(dtd < attackThreshold)
        {
            anim.SetTrigger("attack");
        }
        if (chasing == true)
        {
            if(cScript.health > 0)
            {
                nav.speed = chaseSpeed;
                nav.SetDestination(player.transform.position);
            }
        }
        if(gm.fireAmount <= 0)
        {
            chasing = true;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            chasing = true;
        }
        if(other.tag == "weapon")
        {
            health = health - 1;
            blood.Play();
        }
    }

    void changePosition()
    {
        Invoke("changePosition", Random.Range(1,3));
        navPos = Random.insideUnitSphere * Random.Range(5, 10) + transform.position;
        nav.SetDestination(navPos);
    }
}