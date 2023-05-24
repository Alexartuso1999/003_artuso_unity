using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour
{
    public GameObject targetObject;

    public float repeatTime = 1f;
    public float delay = 0f;

    private void Start()
    {
        InvokeRepeating("ChangeState", 1f, repeatTime + delay);

    }

    void ChangeState()
    {
        targetObject.SetActive(!targetObject.activeInHierarchy);
    }
}
