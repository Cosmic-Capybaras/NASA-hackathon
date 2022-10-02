using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeDescription : MonoBehaviour
{
    public TMP_Text name;
    public TMP_Text description;
    public Image image;

    public string name_this;
    [TextArea(15, 20)]
    public string description_this;
    public Sprite sprite;
    public bool first = false;

    public void Start()
    {
        if(first)
        {
            Change();
        }
    }

    public void Change()
    {
        image.sprite = sprite;
        name.text = name_this;
        description.text = description_this;
    }
    public void Return()
    {
        SceneManager.LoadScene("menu-mein");
    }

}
