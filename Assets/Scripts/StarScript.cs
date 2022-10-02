using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarScript : MonoBehaviour
{
    public string starName = "";
    public string category = "";
    public bool hideCategory = false;
    // brightness list
    public List<float> brightness = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => { OnClick(); });
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnClick()
    {
        // find child gameobject with name "Description"
        GameObject description = gameObject.transform.Find("Description").gameObject;
        // toggle visibility
        description.SetActive(!description.activeSelf);
        // if set to visible hide all other descriptions
        if (description.activeSelf)
        {
            foreach (GameObject star in GameObject.FindGameObjectsWithTag("Star"))
            {
                if (star != gameObject)
                {
                    star.transform.Find("Description").gameObject.SetActive(false);
                }
            }
        }
        // remove onject from parent
        gameObject.transform.SetParent(null, false);
        // move object on last place as children of canvas
        gameObject.transform.SetParent(GameObject.Find("Rot").transform, false);
    }
    public void SetName(string name)
    {
        this.starName = name;
        UpdateDescription();
    }
    public void SetCategory(string category)
    {
        this.category = category;
        UpdateDescription();
    }
    void UpdateDescription()
    {
        GameObject description = gameObject.transform.Find("Description").gameObject;
        TextMeshProUGUI descText = description.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        if (hideCategory)
        {
            descText.text = "Name: \n" + this.starName;
        }
        else
        {
            descText.text = "Name: \n" + this.starName + "\n\nCategory: \n" + this.category;
        }
    }
    public void UpdateBrightness(int day)
    {
        {
            // get the brightness value for the current day
            float min = Mathf.Infinity;
            float max = 0;
            for(int i = 0; i < this.brightness.Count; i++)
            {
                if (this.brightness[i] > max)
                {
                    max = this.brightness[i];
                }
                if (this.brightness[i] < min)
                {
                    min = this.brightness[i];
                }
            }
            //print(this.starName + "with " + "max: " + max + "min: " + min);
            float brightness = this.brightness[day];
            // set the brightness of the star
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.1f + ((brightness - min) / (max - min)) * 0.9f);
        }
    }
}