using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private float timer = 0.0F;
    public bool finished = false;
    public Text timerTxt;

    private void Start()
    {
        timer = Time.time;  //initilize the timer
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            return;
        }

        float t = Time.time - timer; //grab the difference
        string minutes = ((int)t / 60).ToString();  //get minutes 
        string seconds = (t % 60).ToString("f2"); //get seconds and remove milisecond

        timerTxt.text = "Timer: " + minutes + "." + seconds;  //display the timer
    }

    //to run this send a message Finish
    //GameObject.Find("xxx").SendMessage("Finish")
    public void Finish()  
    {
        finished = true;
        timerTxt.color = Color.green;
    }
}
