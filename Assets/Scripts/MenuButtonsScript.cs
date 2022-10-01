using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MenuButtonsScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Sprite imagePress;
    public Sprite imageRelease;
    public AudioSource pressSound;
    public AudioSource releaseSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = imagePress;
        pressSound.Play();
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = imageRelease;
        releaseSound.Play();
    }
}
