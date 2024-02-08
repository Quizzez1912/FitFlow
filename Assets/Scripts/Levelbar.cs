using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Levelbar : MonoBehaviour
{
    private Slider slider;
    private float targetValue;
    private float fillSpeed = 10;
    

    public GameObject LVLbarObj;

    public GameObject lvltxtObj;
    private TextMeshProUGUI lvltxt;

    PlayerData playerData;

    private void Awake()
    {
        slider = LVLbarObj.GetComponent<Slider>();
        lvltxt = lvltxtObj.GetComponent <TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        addXP(20);
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value < targetValue)
        {
            slider.value += fillSpeed * Time.deltaTime;

        }   

        if(slider.value == slider.maxValue)
        {
            playerData.lvlUp();
            newLevel();

        }
    }

    public void addXP(float newXP)
    {
        targetValue = slider.value + newXP;
        refreshLvlText();
    }

    public void setXP(float newXP)
    {
        slider.value = newXP;   
    }


    public void newLevel() {
   
        slider.maxValue = playerData.playerLevel * 50;
    }

    public void refreshLvlText()
    {
        lvltxt.text = (Convert.ToString(targetValue) + " / " + Convert.ToString(slider.maxValue));
    }
}
