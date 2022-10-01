using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GuessBrainScript : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private int startTime;
    // Start is called before the first frame update
    void Start()
    {
        // set start time to current time with miliseconds
        startTime = (int)(Time.time * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        // calculate time since start
        int time = (int)(Time.time * 1000) - startTime;
        // convert time to minutes and seconds
        int minutes = time / 60000;
        int seconds = (time % 60000) / 1000;
        // update time text
        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + "." + (time % 1000).ToString("000");
    }
}
