using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarScript : MonoBehaviour
{
    public string starName = "";
    public string category = "";
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
}