using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScript : MonoBehaviour
{
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
}