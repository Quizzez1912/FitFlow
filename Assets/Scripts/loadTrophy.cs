using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class loadTrophy : MonoBehaviour
{
    // Start is called before the first frame update

    public int[] streakCount = new int[] { 1, 3, 7, 10, 20, 50 };
    public int[] trainingCount = new int[] { 10, 30, 50, 100}; //berrechnet mit allen Trainingsleveln
    public int[] xpEarned = new int[] { 100, 500, 1000 }; // pro level 100 also LVL 2 - LVL 6 - LVL 11  Level-1 *100


    private string streakGoal = "Aufstieg bei Streak > ";
    private string trainingGoal = "Aufstieg nach ";
    private string trainingGoal2 = " absolvierten Trainings";

    private string xpGoal = "Aufstieg nach ";
    private string xpGoal2 = " verdienten XP  ";


    public Texture medal1;
    public Texture medal2;
    public Texture medal3;
    public Texture noMedal;


    public RawImage streakImage;
    public RawImage trainingImage;
    public RawImage XPImage;

    private PlayerData playerData;


    public GameObject streakGoalOBJ;
    public GameObject trainingCountOBJ;
    public GameObject XpGoalOBJ;


    private TextMeshProUGUI streakGoalTXT;
    private TextMeshProUGUI trainingCountTXT;
    private TextMeshProUGUI XPGoalTXT;

    void Start()
    {
        streakGoalTXT = streakGoalOBJ.GetComponent<TextMeshProUGUI>();
        trainingCountTXT = trainingCountOBJ.GetComponent<TextMeshProUGUI>();
        XPGoalTXT = XpGoalOBJ.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }



    // Berechne die Medallien für alle Errungenschaften
    public void refreshMedals()
    {
      
        playerData = PlayerData.Instance;
        checkStreak();
        checkTrain();
        checkXP();

    }


    private void checkStreak() {
    
        int streak = playerData.streak;
      
        
        if (streak < 1)
        {
            streakImage.texture = (Texture)noMedal; // Texture streak 0
            streakGoalTXT.text = streakGoal + Convert.ToString(1);
        }
        
        else if (streak >= 1 && streak < 3)
        {
            streakImage.texture = (Texture)medal3; // Texture streak 1
            streakGoalTXT.text = streakGoal + Convert.ToString(3);
        }
        else if (streak >= 3 && streak < 7)
        {
            streakImage.texture = (Texture)medal2; // Texture streak 3
            streakGoalTXT.text = streakGoal + Convert.ToString(7);
        }
        else if (streak >= 7)
        {
            streakImage.texture = (Texture)medal1; // Texture streak 7
            streakGoalTXT.text = streakGoal + Convert.ToString(10);
        }

    }



    private void checkTrain() {


        int sessions = (playerData.levelExc1 + playerData.levelExc2 + playerData.levelExc3 + playerData.levelExc4 + playerData.levelExc5); 
        Debug.Log(sessions + "sessions");
        sessions = sessions - 5; // Abzug von 5, da Anfangslevel 1 für alle ist
        Debug.Log(sessions + "sessions abzug");
        

        if (sessions < 10)
        {
            streakImage.texture = (Texture)noMedal; // Texture sessions 0
            trainingCountTXT.text = trainingGoal + Convert.ToString(10)+ trainingGoal2;
        }

        else if (sessions <= 30)
        {
            trainingImage.texture = (Texture)medal3; // Texture sessions 10
            Debug.Log("session 10-30");
            trainingCountTXT.text = trainingGoal + Convert.ToString(30) + trainingGoal2;
        }
        else if (sessions <= 50)
        {
            trainingImage.texture = (Texture)medal2; // Texture sessions  30 -50
            trainingCountTXT.text = trainingGoal + Convert.ToString(50) + trainingGoal2;
        }
        else if (sessions > 50)
        {
            trainingImage.texture = (Texture)medal1; // Texture sessions  < 50
            trainingCountTXT.text = trainingGoal + Convert.ToString(100)+ trainingGoal2;
            Debug.Log("session 50+ " + sessions );
        }

    }


    private void checkXP()
    {
        float XP = ((playerData.playerLevel-1)  * 100) + playerData.xp;

        if (XP < 100)
        {
            XPImage.texture = (Texture)noMedal; // Texture XP < 100
            XPGoalTXT.text = xpGoal + Convert.ToString(100) + xpGoal2;
        }

        else if (XP >= 100 && XP <500)
        {
            XPImage.texture = (Texture)medal3; // Texture XP >= 100 && XP <500
            XPGoalTXT.text = xpGoal + Convert.ToString(500) + xpGoal2;
        }
        else if (XP >= 500 && XP < 1000)
        {
            XPImage.texture = (Texture)medal2; // Texture XP  >= 500 && < 1000
            Debug.Log("XPIMAGE CHANGE");
            XPGoalTXT.text = xpGoal + Convert.ToString(1000) + xpGoal2;
        }
        else if (XP > 1000)
        {
            XPImage.texture = (Texture)medal1; // Texture XP  < 1000
            XPGoalTXT.text = xpGoal + Convert.ToString(2000) + xpGoal2;
        }

    }

}








