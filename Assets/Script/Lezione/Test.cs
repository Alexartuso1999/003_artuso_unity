
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [Header("Mouvment")]
    [SerializeField]int day = 18;
    [SerializeField]float myFloat = 4.5f;
    [SerializeField]bool myBool = true;
    [SerializeField]string myString = "aaaaa";

    [Header("Combat")]

    public LayerMask mask;
    
    // Start is called before the first frame update
    void Start()
    {
        myString = Logday();

        float sumResult = Sum(day, myFloat);
    }

    // Update is called once per frame
    void Update()
    {

    }

    string Logday()
    {
        string messageOfTheDay = $"oggi è {day} febbraio";
        Debug.Log(messageOfTheDay);

        return messageOfTheDay;
    }

    float Sum(float a, float b)
    {
        return a + b;
    }
}
