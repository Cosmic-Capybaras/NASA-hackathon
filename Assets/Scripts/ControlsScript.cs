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
    public static string endDate = "2019-09-21";
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
        DateTime currentDate = new DateTime(currentTime);
        timeText.text = currentDate.ToString("dd.MM.yyyy");
    }
}
