﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameManager : MonoBehaviour
{
    public Light fireLight;
    public GameObject stayOutRadius;
    public Text winLoseText;
    public float fireAmount, fireDeplenishRate, nightLength;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(fireAmount > 0)
        {
            fireAmount = fireAmount - fireDeplenishRate * Time.deltaTime;
            fireLight.intensity = fireAmount;
            stayOutRadius.transform.localScale = new Vector3(fireAmount * 2.5f, fireAmount * 2.5f, fireAmount * 2.5f);
        }
        if(fireAmount <= 0)
        {
            winLoseText.text = "you let the fire go out...";
            winLoseText.gameObject.SetActive(true);
        }

    }
}