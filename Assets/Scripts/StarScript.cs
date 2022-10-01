using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarScript : MonoBehaviour
{
    public string starName = "";
    public string category = "";
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
        descText.text = this.starName + "\n" + this.category;
    }
    public void UpdateBrightness(int day)
    {
        {
            // get the brightness value for the current day
            float brightness = this.brightness[day];
            // set the brightness of the star
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, brightness/100);
        }
    }
}