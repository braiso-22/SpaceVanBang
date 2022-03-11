using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;

    // instance
    private static Timer instance;

    // instance geter 
    public static Timer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Timer>();
            }

            return instance;
        }
    }
    void Update()
    {
        currentTime += Time.deltaTime;
    }

    public int getTime()
    {
        return (int)currentTime;
    }
    public string GetCurrentTime()
    {
        if (currentTime < 10)
        {
            return "0" + currentTime.ToString("0");
        }
        else
        {
            return currentTime.ToString("0");
        }
    }
    public string ToMinutes()
    {
        if (currentTime < 60) { return "00:" + GetCurrentTime(); }

        float min = currentTime / 60, seg = currentTime % 60;
        string minStr = "", segStr = "";
        if (min < 10) { minStr = "0" + min.ToString("0"); } else { minStr = min.ToString("0"); }
        if (seg < 10) { segStr = "0" + seg.ToString("0"); } else { segStr = seg.ToString("0"); }
        return minStr + ":" + segStr;
    }
    public void ResetTimer()
    {
        currentTime = 0f;
    }
}
