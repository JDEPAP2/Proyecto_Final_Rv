using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfigAudio : MonoBehaviour
{
    public TMP_Dropdown drp;
    public string activeMicro;
    private List<TMP_Dropdown.OptionData> options;
    // Start is called before the first frame update
    void Awake()
    {
        options = new();
        foreach (var micro in Microphone.devices)
        {
            options.Add(new TMP_Dropdown.OptionData(micro));
        }

        drp.AddOptions(options);
    }

    public void setMicro(int i)
    {
        activeMicro = options[i].text;
    }
}
