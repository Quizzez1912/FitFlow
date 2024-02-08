using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;


public class PlayerData
{


    public static PlayerData _instance = null;



    public int playerLevel = 999;
    public float xp = 999;
    public int streak = 999;
    public string rank = "Anfänger";
    public int levelExc1 = 999;
    public int levelExc2 = 999;
    public int levelExc3 = 999;
    public int levelExc4 = 999;
    public int levelExc5 = 999;





    private PlayerData(int playerlevel, float xp, int streak, string rank, int levelExc1, int levelExc2, int levelExc3, int levelExc4, int levelExc5)
    {
        this.playerLevel = playerlevel;
        this.xp = xp;
        this.streak = streak;
        this.rank = rank;
        this.levelExc1 = levelExc1;
        this.levelExc2 = levelExc2;
        this.levelExc3 = levelExc3;
        this.levelExc4 = levelExc4;
        this.levelExc5 = levelExc5;

    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public static PlayerData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerData(55, 88.5f, 1, "Dummy", 1, 1, 1, 1, 1);
            }
            return _instance;
        }


    }


    public void SetPlayerData(int playerlevel, float xp, int streak, string rank, int levelExc1, int levelExc2, int levelExc3, int levelExc4, int levelExc5)
    {
        this.playerLevel = playerlevel;
        this.xp = xp;
        this.streak = streak;
        this.rank = rank;
        this.levelExc1 = levelExc1;
        this.levelExc2 = levelExc2;
        this.levelExc3 = levelExc3;
        this.levelExc4 = levelExc4;
        this.levelExc5 = levelExc5;
    }

    public void setStreak(int streak)
    {
        this.streak = streak;
    }



    public void setPlayerXP(float xp)
    {
        if (xp > 100)
        {

            this.xp = xp - 100;
            playerLevel++;
            Debug.Log(playerLevel + "Player LVL UP TO LVL");
            checkRank();

        }
        else
        {
            this.xp = xp;

        }

    }



    public void checkRank()
    {

        switch (playerLevel)
        {
            case int lvl when lvl <= 5:
                rank = "Anfänger";
                break;
            case int lvl when lvl >= 6 && lvl <= 15:
                rank = "Einsteiger";
                break;
            case int lvl when lvl >= 16 && lvl <= 20:
                rank = "Neuling";
                break;
            case int lvl when lvl >= 21 && lvl <= 25:
                rank = "Rookie";
                break;
            case int lvl when lvl >= 26 && lvl <= 30:
                rank = "Fortgeschrittener";
                break;

        }

        Debug.Log(rank + "check rank");

    }




    public void lvlupExcercise(int workoutNumber)
    {
        switch (workoutNumber)
        {
            case 1:
                levelExc1++;
                break;
            case 2:
                levelExc2++;
                break;
            case 3:
                levelExc3++;
                break;
            case 4:
                levelExc4++;
                break;
            case 5:
                levelExc5++;
                break;
        }
    }

}
