using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleScale : MonoBehaviour
{
    [Range(0, 10)]
    public float scale;
    public void setScale(float n)
    {
        n = n * scale;
        transform.localScale = new Vector3(n, n, n);
    }
}
