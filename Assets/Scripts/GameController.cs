using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class GameController : MonoBehaviour
{
    public GameObject starObject;
    // Start is called before the first frame update
    void Start()
    {
        // load json data from file "data.json"
        string sciezka = "data";
        var jsonTextFile = Resources.Load<TextAsset>(sciezka);
        JArray json = JArray.Parse(jsonTextFile.ToString());
        // loop through all objects in the json array
        foreach (JObject obj in json)
        {
            // get the name of the star
            string name = (string)obj["name"];
            // get the description of the star
            string category = (string)obj["category"];
            // get the position of the star
            float x = (float)obj["position"][0]["x"];
            float y = (float)obj["position"][0]["y"];
            // create a new star as child of canvas
            GameObject star = Instantiate(starObject) as GameObject;
            star.transform.SetParent(GameObject.Find("Canvas").transform, false);
            // set the name and description of the star
            star.GetComponent<StarScript>().SetName(name);
            star.GetComponent<StarScript>().SetCategory(category);
            // set the position of the star
            star.transform.position = new Vector3(x*40, y*10, 0);
            // loop every brightness
            foreach (float brightness in obj["brightness"])
            {
                // add the brightness value to the star
                star.GetComponent<StarScript>().brightness.Add(brightness);
            }
            star.GetComponent<StarScript>().UpdateBrightness(0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
