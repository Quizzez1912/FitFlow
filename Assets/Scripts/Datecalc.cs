using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using System;
using System.Xml.Linq;
using Unity.VisualScripting;

// Codebasis ist von https://www.youtube.com/watch?v=Z6pEAngpR9I&ab_channel=OXMONDTech

public class Datecalc : MonoBehaviour
{
    string date;

    DateTime currentDate;
    DateTime lastLoginDate;
    DateTime lastIncrementDate;


    int streak;
    PlayerData playerData;

    private void Awake()
    {
        LoadLastLogin();
    }


    // Start is called before the first frame update
    void Start()
    {
        date = System.DateTime.UtcNow.ToLocalTime().ToString("dd.MM.yyyy");
        currentDate = System.DateTime.Parse(date);

        //LoadLastLogin();


        Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ player streak attrb " + playerData.streak);

       

        // SaveLastLogin();  kommt gleicg weh

    }

    // Update is called once per frame
    void Update()
    {

    }


    public int getStreak()
    {
        playerData = PlayerData.Instance;
        streak = playerData.streak;
        checkLoginDay();
        Debug.Log("return getStreak " + streak);
        SaveLastLogin();
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
        Debug.Log("lastLoginDate ===========  " + lastLoginDate.ToString("dd.MM.yyyy"));


        TimeSpan ts = currentDate - lastLoginDate;

        Debug.Log("Zeitdifferenz ===========  " + ts.Days.ToString());


        // Wenn die Differenz 1 Tag beträgt zwischen currentDate und lastLogin, dann ist eine Streak aktiv.
        if (ts.Days == 1)
        {
            streak++;
            lastLoginDate = currentDate;

        }
        else if (ts.Days > 1) // Wenn die Differenz mehr als 1 Tag beträgt zwischen currentDate und LastLogin, dann ist KEINE Streak mehr aktiv.
        {
            lastLoginDate = currentDate;
            streak = 0;

        }
        else
        {
            Debug.Log("Streak bereits erhöht --------------------------- ");

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
        Debug.Log("loaded Lastlogin: " + json);
        lastLoginDate = System.DateTime.Parse(json);

    }

    public void SaveLastLogin()
    {
        Debug.Log("saved lastlogin  " + lastLoginDate.ToString("dd.MM.yyyy"));
        string json = lastLoginDate.ToString("dd.MM.yyyy");


        using (StreamWriter write = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveLastLogin.json"))
        {
            write.Write(json);
        }




    }


}

