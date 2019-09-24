using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerScript : MonoBehaviour
{
    gameManager gm;
    public GameObject[] enemies;
    bool tierOne = false, tierTwo = false, tierThree = false;
    public float dtd, chance;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GOD").GetComponent<gameManager>();
        dtd = Vector3.Distance(new Vector3(0, 0, 0), transform.position);

        if(dtd < 20)
        {
            tierOne = true;
            tierTwo = false;
            tierThree = false;
        }
        if(dtd > 20 && dtd < 40)
        {
            tierOne = false;
            tierTwo = true;
            tierThree = false;
        }
        if(dtd > 40)
        {
            tierOne = false;
            tierTwo = false;
            tierThree = true;
        }
        Invoke("spawnEnemy", 3);
    }


    void spawnEnemy()
    {
        Invoke("spawnEnemy", Random.Range(5, 10));
        print("ding");
        chance = Random.Range(0, 100);
        if (chance < gm.chanceValue)
        {
            if (tierOne == true)
            {
                Instantiate(enemies[0], transform.position, transform.rotation);
            }
            if (tierTwo == true)
            {
                Instantiate(enemies[Random.Range(0, 1)], transform.position, transform.rotation);
            }
            if (tierThree == true)
            {
                Instantiate(enemies[Random.Range(0, 3)], transform.position, transform.rotation);
            }
        }
    }
}
