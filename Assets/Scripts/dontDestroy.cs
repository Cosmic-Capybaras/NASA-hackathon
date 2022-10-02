using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dontDestroy : MonoBehaviour
{
    public AudioSource source;
    bool offon = true;
    public Sprite on;
    public Sprite off;
    public Image spriteRenderer;

        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }

    public void Change()
    {
        if(offon)
        {
            source.volume = 0;
            spriteRenderer.sprite = off;
        }
        else
        {
            source.volume = 0.5f;
            spriteRenderer.sprite = on;
        }

        offon = !offon;
    }
        
}
