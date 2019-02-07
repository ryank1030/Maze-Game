using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Text").SendMessage("Finish");
    }
}
