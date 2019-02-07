using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private float timer = 0.0F;
    public bool logging = false;
    public Text txt;

    // Update is called once per frame
    void Update()
    {

        timer = Time.timeSinceLevelLoad;
        txt.text = "Timer: " + timer.ToString();

        if (logging)
        {
            Debug.Log(txt.text);
        }
    }
}
