using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

// Codebasis ist von https://www.youtube.com/watch?v=b1ONIoDfUes&ab_channel=Prism
public class Workoutmanagment : MonoBehaviour
{

    public int choosenWorkout;
   
    public GameObject workoutnameObj;
    public GameObject goalObj;
    public GameObject timeObj;

    public int[] trainingGoals = new int[] { 0, 5, 5, 7, 7, 10, 10, 12, 12, 15, 15, 17, 17, 17 }; // reps index 0 gibt es nicht, da Level bei 1 beginnt

    TextMeshProUGUI workoutnameTxt;
    TextMeshProUGUI goalTxt;
    TextMeshProUGUI timeTxt;


    private float currentTime;

    private bool isPaused;


    public GameObject startObj;
    public GameObject stopObj;
    public GameObject finishWorkout;



    private PlayerData playerData;

    private Levelbar lvlBar;

    SaveJSON saveMenu;

    private void Awake()
    {
        workoutnameTxt = workoutnameObj.GetComponent<TextMeshProUGUI>();
        goalTxt = goalObj.GetComponent<TextMeshProUGUI>();
        timeTxt = timeObj.GetComponent<TextMeshProUGUI>();

        isPaused = true;
        currentTime = 0f;

        lvlBar = GetComponent<Levelbar>();
        playerData = PlayerData.Instance;
        saveMenu = GetComponent<SaveJSON>();
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
        startObj.SetActive(false);
        stopObj.SetActive(true);
    }

    public void Pause()
    {
        Debug.Log("Pause Watch");
        isPaused = true;
        startObj.SetActive(false);
        stopObj.SetActive(false);
        finishWorkout.SetActive(true);
    }

    public void ResetTimer()
    {
        Debug.Log("reset Watch");
        isPaused = true;
        currentTime = 0f;
        startObj.SetActive(true);
        stopObj.SetActive(false);
        finishWorkout.SetActive(false);
        playerData = PlayerData.Instance;

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

   

    // ----------------- Workout Level ----------------------------------

    public int getGoal(int playerWorkoutLevel) {

        Debug.Log(playerWorkoutLevel + "return will be " + trainingGoals[playerWorkoutLevel]);
  
        return trainingGoals[playerWorkoutLevel];

    }


    // Berechnet die XP nach dem Training 
    public void finishTraining() {

        int streak = playerData.streak;
        float multiplier = 1.25f; // gewünschten Multiplikator 
        float calcXP = 10 * (float)Math.Pow(multiplier, streak);
        Debug.Log(calcXP + "XP ADDED");
        lvlBar.addXP(calcXP);
        playerData.lvlupExcercise(getWorkout());
        saveMenu.SaveData();






    }

}