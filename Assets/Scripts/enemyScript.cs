using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{
    public Animator anim;
    NavMeshAgent nav;
    Vector3 navPos;
    bool chasing = false;
    GameObject player;
    public GameObject schmeat;
    public float schmeatAmount;
    gameManager gm;
    characterScript cScript;
    public ParticleSystem blood;

    public float health = 10;
    public float dtd, attackThreshold, chaseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        //start changeposition once here because after that it calls itself
        changePosition();
        //find gamemanager and characterscripts so we can use the variables later
        gm = GameObject.Find("GOD").GetComponent<gameManager>();
        cScript = player.GetComponent<characterScript>();
    }

    private void Update()
    {
        dtd = Vector3.Distance(player.transform.position, transform.position);
        if (dtd > 20)
        {
            chasing = false;
        }
        if (dtd < attackThreshold)
        {
            anim.SetTrigger("attack");
        }
        if (chasing == true)
        {
            if (cScript.health > 0)
            {
                nav.speed = chaseSpeed;
                nav.SetDestination(player.transform.position);
            }
        }
        if (gm.fireAmount <= 0)
        {
            chasing = true;
        }
        if (health <= 0)
        {
            for (int i = 0; i < schmeatAmount; i++)
            {
                Instantiate(schmeat, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            blood.Play();
        }
}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (chasing == true)
        {
            if (cScript.health > 0)
            {
                nav.speed = chaseSpeed;
                nav.SetDestination(player.transform.position);
            }
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