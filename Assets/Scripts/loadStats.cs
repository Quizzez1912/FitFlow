using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class loadStats : MonoBehaviour
{
    private PlayerData playerData;

    public GameObject levelExc1Obj;
    public GameObject levelExc2Obj;
    public GameObject levelExc3Obj;
    public GameObject levelExc4Obj;
    public GameObject levelExc5Obj;


    private TextMeshProUGUI levelExc1TXT;
    private TextMeshProUGUI levelExc2TXT;
    private TextMeshProUGUI levelExc3TXT;
    private TextMeshProUGUI levelExc4TXT;
    private TextMeshProUGUI levelExc5TXT;

    public int levelExc1 = 0;
    public int levelExc2 = 0;
    public int levelExc3 = 0;
    public int levelExc4 = 0;
    public int levelExc5 = 0;

    // Start is called before the first frame update
    void Start()
    {
        levelExc1TXT = levelExc1Obj.GetComponent<TextMeshProUGUI>();
        levelExc2TXT = levelExc2Obj.GetComponent<TextMeshProUGUI>();
        levelExc3TXT = levelExc3Obj.GetComponent<TextMeshProUGUI>();
        levelExc4TXT = levelExc4Obj.GetComponent<TextMeshProUGUI>();
        levelExc5TXT = levelExc5Obj.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reloadStats()
    {
        playerData = PlayerData.Instance;
        levelExc1 = playerData.levelExc1;
        levelExc2 = playerData.levelExc2;
        levelExc3 = playerData.levelExc3;
        levelExc4 = playerData.levelExc4;
        levelExc5 = playerData.levelExc5;


        levelExc1TXT.text = ("Level " + Convert.ToString(levelExc1));
        levelExc2TXT.text = ("Level " + Convert.ToString(levelExc2));
        levelExc3TXT.text = ("Level " + Convert.ToString(levelExc3));
        levelExc4TXT.text = ("Level " + Convert.ToString(levelExc4));
        levelExc5TXT.text = ("Level " + Convert.ToString(levelExc5));
    }
    
}
