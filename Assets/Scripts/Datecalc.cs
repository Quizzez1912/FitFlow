using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using System;

// Codebasis ist von https://www.youtube.com/watch?v=Z6pEAngpR9I&ab_channel=OXMONDTech

public class Datecalc : MonoBehaviour
{
    string date;
    string lastloginString;
    int calcStreak;


    DateTime currentDate;
    DateTime lastLoginDate;
    TimeSpan ts;
    int streak;
    PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        date = System.DateTime.UtcNow.ToLocalTime().ToString("dd.MM.yyyy");

        currentDate = System.DateTime.Parse(date);
        LoadLastLogin();

        checkLoginDay();
    


        // lastLogin = "12.01.2024"; // as json lesen und setzen am Anfang
        // lastLoginDate = System.DateTime.Parse(lastLogin);

        ts = currentDate - lastLoginDate;

        Debug.Log("difference in days " + ts.Days);

        streak = int.Parse(ts.Days.ToString());



        Debug.Log("The Streak is  " + streak);

       // SaveLastLogin();  kommt gleicg weh
     
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

    public void checkLoginDay()
    {
        Debug.Log("currentDate===========  " + currentDate.ToString("dd.MM.yyyy"));
        Debug.Log("LastLoginDate ===========  " + lastLoginDate.ToString("dd.MM.yyyy"));


        TimeSpan tsLogin = currentDate - lastLoginDate;

        Debug.Log("Calculated TimeSPan Login ===========  " + tsLogin.Days.ToString());


        if (int.Parse(tsLogin.Days.ToString()) > 1) {
            Debug.Log("Streak endet, da Spieler gestern nicht eingeloggt war");
            lastLoginDate = currentDate;
            SaveLastLogin() ;
            LoadLastLogin();
        }

    }
    
    // TODO Json speichern lastlogin und 1stlogin und dann streak checken

    public void LoadLastLogin()
    {
        string json = string.Empty;

        using (StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveLastLogin.json"))
        {
            json = reader.ReadToEnd();
        }
        lastloginString = date;
        lastLoginDate = System.DateTime.Parse(lastloginString);

        Debug.Log("loaded Lastlogin: " + date);



    }

    public void SaveLastLogin()
    {
        Debug.Log("saved lastlogin  " + lastLoginDate.ToString());

        using (StreamWriter write = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveLastLogin.json"))
        {

            write.Write(lastloginString);
        }



    }

}