using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VoiceColor : MonoBehaviour
{
    public List<Image> imgs;
    public Color startColor, endColor;
    public float dif;

    public void ChangeColor(float s)
    {
        foreach(var img in imgs)
        {
            if (s < 0.2)
            {
                img.color = startColor;
            }
            else
            {
                img.color = Color.Lerp(startColor, endColor, s + dif);
            }
            
        }
    }
}
