using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlsScript : MonoBehaviour
{
    public Slider timeSlider;
    public TextMeshProUGUI timeText;
    public static string startDate = "2019-09-10";
    public static string endDate = "2019-10-09";
    // convert date to seconds
    DateTime dateTimeStart = DateTime.Parse(startDate);
    DateTime dateTimeEnd = DateTime.Parse(endDate);
    // Start is called before the first frame update
    void Start()
    {
        // call SliderUpdate when the slider value changes
        timeSlider.onValueChanged.AddListener(delegate { SliderUpdate(); });
        timeText.text = dateTimeStart.ToString("dd.MM.yyyy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SliderUpdate()
    {
        // read start time in seconds
        long start = dateTimeStart.Ticks;
        long end = dateTimeEnd.Ticks;
        long delta = end - start;
        long deltaChange = (long)(delta * timeSlider.value);
        long currentTime = start + deltaChange;
        TimeSpan timeSpan = new TimeSpan(currentTime);
        DateTime currentDate = new DateTime(currentTime);
        timeText.text = currentDate.ToString("dd.MM.yyyy");
        // convert deltaChange to days
        int day = (int)(deltaChange / 864000000000);
        // find all gameobjects with tag "Star"
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");
        // loop through all stars
        foreach (GameObject star in stars)
        {
            // update the brightness of the star
            star.GetComponent<StarScript>().UpdateBrightness(day);
        }
    }
}
