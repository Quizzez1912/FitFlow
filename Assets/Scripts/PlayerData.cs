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



    public int playerLevel = 0;
    public float xp = 0;
    public int streak = 0;
    public string rank = "Anfänger";
    public int levelExc1 = 0;
    public int levelExc2 = 0;
    public int levelExc3 = 0;
    public int levelExc4 = 0;
    public int levelExc5 = 0;





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
                _instance = new PlayerData(55,2.2f, 1, "RANK LOL", 1, 1, 1, 1, 1);
            }
            return _instance;
        }


    }


    public void SetPlayerData(int playerlevel,float xp, int streak, string rank, int levelExc1, int levelExc2, int levelExc3, int levelExc4, int levelExc5)
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

}
