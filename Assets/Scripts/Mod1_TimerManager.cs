using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Mod1_TimerManager : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    void Start()
    {
        StartCoroutine("Countdown", 100);
    }

    private IEnumerator Countdown(float time)
    {
        PlayerStats.instance.time = time;
        while (PlayerStats.instance.time > 0)
        {
            int num_integer = (int)PlayerStats.instance.time;
            float num_decimal = PlayerStats.instance.time - num_integer;


            if (num_decimal > 0.60f)
            {
                num_decimal = 0.60f;
            }
            PlayerStats.instance.time = num_integer + num_decimal;
            yield return new WaitForSeconds(Time.deltaTime);

            if (PlayerStats.instance.timeStop > 0)
            { 
                PlayerStats.instance.timeStop -= Time.deltaTime;
            }
            else
            {
                PlayerStats.instance.time -= Time.deltaTime;
            }

            if(PlayerStats.instance.timeStop < 0)
            {
                PlayerStats.instance.timeStop = 0;
            }

            textMesh.text = PlayerStats.instance.time.ToString("0.00");
        }
        Debug.Log("Countdown Complete!");
    }
}
