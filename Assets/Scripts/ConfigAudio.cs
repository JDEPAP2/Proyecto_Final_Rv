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
    void Start()
    {
        options = new();
        foreach (var micro in Microphone.devices)
        {
            Debug.Log(micro);
            options.Add(new TMP_Dropdown.OptionData(micro));
        }

        if(drp.options.Count == 0)
            drp.AddOptions(options);

        if (options.Count > 0)
            setMicro(0);
    }

    public void setMicro(int i)
    {
        activeMicro = options[i].text;
    }
}
