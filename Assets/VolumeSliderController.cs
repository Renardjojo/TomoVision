using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class VolumeSliderController : MonoBehaviour
{
    public Sprite[] sprites;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePictureVolume()
    {
        image.sprite = sprites[(int)(AudioListener.volume * sprites.Length)];
    }

    public void ChangeGeneralVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
        UpdatePictureVolume();
    }
}
