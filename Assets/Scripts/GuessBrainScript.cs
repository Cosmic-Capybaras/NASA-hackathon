using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Linq;

public class GuessBrainScript : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public GameObject starObject;
    public Button category1btn;
    public Button category2btn;
    public Button category3btn;
    public Button category4btn;
    public Button category5btn;
    public Button category6btn;
    public Button category7btn;
    public Button category8btn;
    private int startTime;
    public Vector2 scale;
    // Start is called before the first frame update
    void Start()
    {
        startTime = (int)Time.time*1000;
        GenerateStars(5);
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
    private void GenerateStars(int amount)
    {
        // generate random starts
        string sciezka = "data";
        var jsonTextFile = Resources.Load<TextAsset>(sciezka);
        JArray json = JArray.Parse(jsonTextFile.ToString());
        int lenght = json.Count;
        // list of generated stars ids
        List<int> starsUsed = new List<int>();
        for (int i = 0; i < amount; i++)
        {
            int random = Random.Range(0, lenght);
            // check if the star was already generated
            while (starsUsed.Contains(random))
            {
                random = Random.Range(0, lenght);
            }
            starsUsed.Add(random);
            JObject obj = (JObject)json[random];
            // get the name of the star
            string name = (string)obj["name"];
            // get the description of the star
            string category = (string)obj["category"];
            // get the position of the star
            float x = (float)obj["position"][0]["x"];
            float y = (float)obj["position"][0]["y"];
            // create a new star as child of canvas
            GameObject star = Instantiate(starObject) as GameObject;
            star.transform.SetParent(GameObject.Find("Rot").transform, false);
            // set the name and description of the star
            star.GetComponent<StarScript>().hideCategory = true;
            star.GetComponent<StarScript>().SetName(name);
            star.GetComponent<StarScript>().SetCategory(category);
            // set the position of the star
            star.transform.localPosition = new Vector3(x * scale.x, y * scale.y, 0);
            // loop every brightness
            foreach (float brightness in obj["brightness"])
            {
                // add the brightness value to the star
                star.GetComponent<StarScript>().brightness.Add(brightness);
            }
            star.GetComponent<StarScript>().UpdateBrightness(0);
        }        
    }
}
