using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.UI;


public class Eventsystem : MonoBehaviour
{


    #region Player Data 
    // ---------------------------  PlayerData -------------------------
    private PlayerData playerData;

    public GameObject playerLevelObj;
    public GameObject streakObj;
    public GameObject streakSymbolObj;
    public GameObject rankObj;
    public GameObject trainingTimeObj;
    public GameObject traingNameObj;
    public GameObject traingGoalObj;

    public Texture streak_on;
    public Texture streak_off;

    private TextMeshProUGUI playerLevelTxt;
    private TextMeshProUGUI streakTxt;
    private TextMeshProUGUI rankTxt;
    private TextMeshProUGUI trainingTimeTxt;
    private TextMeshProUGUI traingNameTxt;
    private TextMeshProUGUI traingGoalTxt;


    #endregion

    
    public int streak = 0;
    public string rank = "A";
    public int levelExc1 = 0;
    public int levelExc2 = 0;
    public int levelExc3 = 0;
    public int levelExc4 = 0;
    public int levelExc5 = 0;

    private RawImage streakImage;


    public int trainingTime = 0;
    public int traingName = 0;
    public int traingGoal = 0;


    // ------------------- Level Bar ---------------------------
    public int playerLevel = 0;
    public float xp = 0;
    public GameObject sliderObj;
    private Slider slider;
    private float targetValue;
    private float fillSpeed = 10;



    private void Awake()
    {
        slider = sliderObj.GetComponent<Slider>();

        playerLevelTxt = playerLevelObj.GetComponent<TextMeshProUGUI>();

        streakTxt = streakObj.GetComponent<TextMeshProUGUI>();
        rankTxt = rankObj.GetComponent<TextMeshProUGUI>();
        trainingTimeTxt = trainingTimeObj.GetComponent<TextMeshProUGUI>();
        traingNameTxt = traingNameObj.GetComponent<TextMeshProUGUI>();
        traingGoalTxt = traingGoalObj.GetComponent<TextMeshProUGUI>();


        streakImage = streakSymbolObj.GetComponent<RawImage>();

        
        


    }


    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        refreshDisplay();



        if (slider.value < targetValue)
        {
            slider.value += fillSpeed * Time.deltaTime;

        }




    }


    public void reloadStats()
    {
        playerData = PlayerData.Instance;

        playerLevel = playerData.playerLevel;
        xp = playerData.xp;
        streak = playerData.streak;
        rank = playerData.rank;
        levelExc1 = playerData.levelExc1;
        levelExc2 = playerData.levelExc2;
        levelExc3 = playerData.levelExc3;
        levelExc4 = playerData.levelExc4;
        levelExc5 = playerData.levelExc5;

    }

    public void refreshDisplay()
    {
        reloadStats();
        playerLevelTxt.text = playerLevel.ToString();
        setXP(xp);
        streakTxt.text = streak.ToString();
        rankTxt.text = rank;

        checkStreak();

    }






    //---------------- Level Bar Code ------------------

    public void addXP(float newXP)
    {
        targetValue = slider.value + newXP;
    }

    public void setXP(float newXP)
    {
        slider.value = newXP;
    }


    // --------------- Streak Code ----------------------


    private void checkStreak()
    {

        if (playerData.streak < 1)
        {
            streakImage.texture = (Texture)streak_off;
        }
        else
        {
            streakImage.texture = (Texture)streak_on;
        }
    }




}
