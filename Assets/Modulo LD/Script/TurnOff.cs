using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    private float timer;
    [SerializeField] float trigerTimer = 5f;
    [SerializeField] GameObject mesh;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= trigerTimer)
        {
            timer = 0;
            mesh.SetActive(!mesh.activeSelf);
        }
    }
}
