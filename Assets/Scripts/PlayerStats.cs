using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance { get; set; }

    public float time;
    public float timeStop;
    public int points;

    private void Awake()
    {
        instance = this;
    }
    public void AddTime(float time_)
    {
        time = time+ time_;
    }

    public void FreezeTime(float time_)
    {
        timeStop += time_;
    }
}
