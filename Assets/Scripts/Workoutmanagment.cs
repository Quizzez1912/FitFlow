using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

// Codebasis ist von https://www.youtube.com/watch?v=b1ONIoDfUes&ab_channel=Prism
public class Workoutmanagment : MonoBehaviour
{

    public int choosenWorkout;
   
    public GameObject workoutnameObj;
    public GameObject goalObj;
    public GameObject timeObj;

     TextMeshProUGUI workoutnameTxt;
     TextMeshProUGUI goalTxt;
     TextMeshProUGUI timeTxt;


    private float currentTime;

    private bool isPaused;

    private void Awake()
    {
        workoutnameTxt = workoutnameObj.GetComponent<TextMeshProUGUI>();
        goalTxt = goalObj.GetComponent<TextMeshProUGUI>();
        timeTxt = timeObj.GetComponent<TextMeshProUGUI>();

        isPaused = true;
        currentTime = 0f;
    }

    private void Update()
    {
        if (!isPaused)
        {
            currentTime += Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timeTxt.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
    }



    // ------------------- Timer -----------------------
    public void StartTimer()
    {
        Debug.Log("start Watch");
        isPaused = false;
    }

    public void Pause()
    {
        Debug.Log("Pause Watch");
        isPaused = true;
    }

    public void ResetTimer()
    {
        Debug.Log("reset Watch");
        isPaused = true;
        currentTime = 0f;
    }



    // ------------------- Workout Selection -----------------------

    public void setWorkout(int choose)
    {
        choosenWorkout = choose;
    }

    public int getWorkout()
    {
        return choosenWorkout;
    }

}