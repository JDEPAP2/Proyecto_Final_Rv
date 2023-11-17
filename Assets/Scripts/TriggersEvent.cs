using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggersEvent : MonoBehaviour
{
    public UnityEvent<Collider> onTriggerExit, onTriggerStay, onTriggerEnter;
    public string nameTag;
    private void OnTriggerEnter(Collider other)
    {
        if (nameTag == null || nameTag.Length == 0 || other.tag == nameTag)
        {
            onTriggerEnter.Invoke(other);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (nameTag == null || nameTag.Length == 0 || other.tag == nameTag)
        {
            onTriggerStay.Invoke(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (nameTag == null || nameTag.Length == 0 || other.tag == nameTag)
        {
            onTriggerExit.Invoke(other);
        }
        
    }
}
