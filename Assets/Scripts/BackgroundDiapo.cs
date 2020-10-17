using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class BackgroundDiapo : MonoBehaviour
{
    public Sprite[] sprites;
    protected Image image;

    public float FadeRate = 1f;
    public float WaitDuration = 3f;

    int index = 1;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = sprites[0];
        StartCoroutine(RunNextDiapo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeOut(Image image)
    {
        float targetAlpha = 0.0f;

        Color curColor = image.color;

        while(Mathf.Abs(curColor.a - targetAlpha) > 0.01f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }

        index++;
        if (index >= sprites.Length)
            index = 0;
            
        image.sprite = sprites[index];
        image.color = new Color(255, 255, 255, 0);
        StartCoroutine(FadeIn(image));
    }

    IEnumerator FadeIn(Image image)
    {
        float targetAlpha = 1.0f;

        Color curColor = image.color;

        while(Mathf.Abs(curColor.a - targetAlpha) > 0.01f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }

        StartCoroutine(RunNextDiapo());
    }

    IEnumerator RunNextDiapo()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(WaitDuration);

        StartCoroutine(FadeOut(image));
    }
}
