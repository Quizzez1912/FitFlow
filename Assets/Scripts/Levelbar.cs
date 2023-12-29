using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levelbar : MonoBehaviour
{
    private Slider slider;
    private float targetValue;
    private float fillSpeed = 10;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        addXP(20);
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value < targetValue)
        {
            slider.value += fillSpeed * Time.deltaTime;

        }   
    }

    public void addXP(float newXP)
    {
        targetValue = slider.value + newXP;
    }

    public void setXP(float newXP)
    {
        slider.value = newXP;   
    }

}
