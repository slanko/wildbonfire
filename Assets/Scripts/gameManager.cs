using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameManager : MonoBehaviour
{
    public Light fireLight;
    public ParticleSystem fireParticles;
    public GameObject stayOutRadius;
    characterScript pScript;
    public Text winLoseText;
    public float fireAmount, fireDeplenishRate, nightLength, chanceValue;
    public int playTime;
    // Start is called before the first frame update
    void Start()
    {
        pScript = GameObject.Find("Player").GetComponent<characterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fireAmount > 0)
        {
            fireAmount = fireAmount - fireDeplenishRate * Time.deltaTime;
            fireLight.intensity = fireAmount;
            var emission = fireParticles.emission;
            emission.rateOverTime = fireAmount;
            stayOutRadius.transform.localScale = new Vector3(fireAmount * 2.5f, fireAmount * 2.5f, fireAmount * 2.5f);
        }
        if(fireAmount <= 0 && pScript.health > 0)
        {
            winLoseText.text = "you let the fire go out...";
            winLoseText.gameObject.SetActive(true);
        }
        if(fireAmount > 15)
        {
            fireAmount = 15;
        }
        if (pScript.health <= 0)
        {
            winLoseText.text = "you died...";
            winLoseText.gameObject.SetActive(true);
        }
        if(playTime >= nightLength)
        {
            winLoseText.text = "you survived the night!";
            winLoseText.gameObject.SetActive(true);
        }
        playTime = Mathf.RoundToInt(playTime + 1 * Time.deltaTime);

        chanceValue = 20 + playTime / 6.5f;
    }
}