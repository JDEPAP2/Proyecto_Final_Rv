using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EffectText : MonoBehaviour
{
    public string frase;
    public TextMeshProUGUI texto;
    public int Repeat;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        for (int i = 0; i < Repeat; i++)
        {
            foreach (char caracter in frase)
            {
                texto.text = texto.text + caracter;
                yield return new WaitForSeconds(0.2f);
            }
            texto.text = null;
        }
    }
}
