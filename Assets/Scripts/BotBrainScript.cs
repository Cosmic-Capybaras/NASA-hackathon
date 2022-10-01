using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Linq;

public class BotBrainScript : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public GameObject starObject;
    public Button categoryByDraconis;
    public Button categoryCataclysmic;
    public Button categoryCepheid;
    public Button categoryBinary;
    public Button categoryChemically;
    private int startTime;
    public Vector2 scale;
    public bool countTime = true;
    public Image opponentStar1;
    public Image opponentStar2;
    public Image opponentStar3;
    public Image opponentStar4;
    public Image opponentStar5;
    // opponent stars list
    List<Image> opponentStars = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        startTime = (int)Time.time * 1000;
        GenerateStars(5);
        categoryByDraconis.GetComponent<Button>().onClick.AddListener(() => { GuessStar("BY Draconis"); });
        categoryCataclysmic.GetComponent<Button>().onClick.AddListener(() => { GuessStar("Cataclysmic"); });
        categoryCepheid.GetComponent<Button>().onClick.AddListener(() => { GuessStar("Cepheid"); });
        categoryBinary.GetComponent<Button>().onClick.AddListener(() => { GuessStar("Binary"); });
        categoryChemically.GetComponent<Button>().onClick.AddListener(() => { GuessStar("Chemically Peculiar"); });
        opponentStars.Add(opponentStar1);
        opponentStars.Add(opponentStar2);
        opponentStars.Add(opponentStar3);
        opponentStars.Add(opponentStar4);
        opponentStars.Add(opponentStar5);
        StartCoroutine(OpponentBrain());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (!countTime) return;
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
    public void GuessStar(string category)
    {
        // get star with visible description
        GameObject selectedStar = null;
        foreach (GameObject star in GameObject.FindGameObjectsWithTag("Star"))
        {
            if (star.transform.Find("Description").gameObject.activeSelf)
            {
                selectedStar = star;
                break;
            }
        }
        // check if the star was selected
        if (selectedStar == null) return;
        // check if star color is white
        if (selectedStar.GetComponent<Image>().color.r != 1 || selectedStar.GetComponent<Image>().color.g != 1 || selectedStar.GetComponent<Image>().color.b != 1)
        {
            return;
        }
        // check if selected category is correst
        if (selectedStar.GetComponent<StarScript>().category == category)
        {
            // set star color to green
            selectedStar.GetComponent<Image>().color = new Color(0, 1, 0);
        }
        else
        {
            // set star color to red
            selectedStar.GetComponent<Image>().color = new Color(1, 0, 0);
        }
        // check if there is any white star
        foreach (GameObject star in GameObject.FindGameObjectsWithTag("Star"))
        {
            if (star.GetComponent<Image>().color.r != 1 || star.GetComponent<Image>().color.g != 1 || star.GetComponent<Image>().color.b != 1)
            {
                continue;
            }
            else
            {
                return;
            }
        }
        countTime = false;
    }
    IEnumerator OpponentBrain()
    {
        // wait between 3 and 10 seconds
        yield return new WaitForSeconds(Random.Range(3, 11));
        // list of stars guessed
        List<int> starsGuessed = new List<int>();
        // loop five times
        for (int i = 0; i < 5; i++)
        {
            // select random not guessed star
            int rand = Random.Range(0, 5);
            while (starsGuessed.Contains(rand))
            {
                rand = Random.Range(0, 5);
            }
            starsGuessed.Add(rand);
            // select randomly if it will be guessed
            int guessed = Random.Range(0, 3);
            if(guessed == 0)
            {
                opponentStars[rand].GetComponent<Image>().color = new Color(1, 0, 0);
            }
            else
            {
                opponentStars[rand].GetComponent<Image>().color = new Color(0, 1, 0);
            }
            // wait between 2 and 4 seconds
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }
}