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

    float playerXP = 0;

    public GameObject LVLbarObj;

    public GameObject lvltxtObj;
    private TextMeshProUGUI lvltxt;

    PlayerData playerData;

    SaveJSON saveMenu;
    private void Awake()
    {
        slider = LVLbarObj.GetComponent<Slider>();
        lvltxt = lvltxtObj.GetComponent <TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        saveMenu = GetComponent<SaveJSON>();
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
            playerData.playerLevel++;
            Debug.Log(playerData.playerLevel + "Player LVL UP TO LVL");
            newLevel();

        }
    }

    public void addXP(float newXP)
    {
        playerData = PlayerData.Instance;
        targetValue = slider.value + newXP;
        refreshLvlText();
        playerData.setPlayerXP(targetValue);
        playerXP = targetValue;
        saveMenu.SaveData();
    }

    public void setXP(float newXP)
    {
        slider.value = newXP;
        playerXP = newXP;
        refreshLvlText();
    }


    public void newLevel() {
   
        slider.maxValue = playerData.playerLevel * 100;
       
    }

    public void refreshLvlText()
    {
        lvltxt.text = (Convert.ToString(Mathf.RoundToInt(playerXP)) + " / " + Convert.ToString(slider.maxValue));
    }
}
