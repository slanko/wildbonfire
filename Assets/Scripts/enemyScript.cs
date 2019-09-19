using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{
    NavMeshAgent nav;
    Vector3 navPos;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        changePosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changePosition()
    {
        Invoke("changePosition", 3);
        navPos = Random.insideUnitSphere * Random.Range(5, 10) + transform.position;
        nav.SetDestination(navPos);
    }

}
