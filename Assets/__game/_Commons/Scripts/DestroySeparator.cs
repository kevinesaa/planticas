using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySeparator : MonoBehaviour
{
    private void Awake()
    {
        gameObject.transform.DetachChildren();
        Destroy(gameObject);
    }
}
