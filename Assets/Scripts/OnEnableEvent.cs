using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnEnableEvent : MonoBehaviour
{
    public UnityEvent onEnableM;

    private void OnEnable()
    {
        onEnableM.Invoke();
    }
}
