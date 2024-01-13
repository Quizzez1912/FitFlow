using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using System;

// Codebasis ist von https://www.youtube.com/watch?v=Z6pEAngpR9I&ab_channel=OXMONDTech

public class Date : MonoBehaviour
{
    string date;
    int calcStreak;
    string lastLogin;
    DateTime currentDate;
    DateTime lastLoginDate;
    TimeSpan ts;
    int streak;

    // Start is called before the first frame update
    void Start()
    {
        date = System.DateTime.UtcNow.ToLocalTime().ToString("dd.MM.yyyy");
       
        currentDate = System.DateTime.Parse(date);

        lastLogin = "12.01.2024"; // as json lesen und setzen am Anfang
        lastLoginDate = System.DateTime.Parse(lastLogin);


        Debug.Log(date.ToString());
        Debug.Log(lastLogin.ToString());

        ts = currentDate - lastLoginDate;

        Debug.Log("difference in days " + ts.Days);

        streak = int.Parse(ts.Days.ToString());



        Debug.Log("The Streak is  " + streak);


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int getStreak()
    {
        return streak;
    }

    
    public void printDate()
    {
        Debug.Log(date);
    }
    public string getDate()
    {
        Debug.Log(date);
        return date;
    }



    public void LoadSavedDate()
    {
        string json = string.Empty;

        using (StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            json = reader.ReadToEnd();
        }

        Debug.Log("loaded save: " + json);
        
        

    }

}
