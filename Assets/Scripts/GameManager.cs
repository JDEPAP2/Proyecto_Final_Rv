using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public float transitionTime;
    public UnityEvent onWin, onFailed, onPort;
    public GameObject mainCanvas;
    public List<GameObject> resultsCanvas;

    public void win()
    {
        onWin.Invoke();
        StartCoroutine(transition(0));
    }

    public void failed()
    {
        onFailed.Invoke();
        StartCoroutine(transition(1));
    }

    public void port()
    {
        onPort.Invoke();
        StartCoroutine(transition(2));
    }

    public IEnumerator transition(int i)
    {
        yield return new WaitForSeconds(transitionTime);
        mainCanvas.SetActive(true);
        resultsCanvas[i].SetActive(true);
    }
}
