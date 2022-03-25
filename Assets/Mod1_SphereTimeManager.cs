using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mod1_SphereTimeManager : MonoBehaviour
{

    public static Mod1_SphereTimeManager Instance { get; set; }

    public TextMeshProUGUI textMesh;
    public float time;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        time = Constants.timeSphereFull;
    }

    void Update()
    {
        if (PlayerStats.instance.time > 0)
        {
            int num_integer = (int)time;
            float num_decimal = time - num_integer;


            if (num_decimal > 0.60f)
            {
                num_decimal = 0.60f;
            }
            time = num_integer + num_decimal;
            time -= Time.deltaTime;
        }
        if (time < 0)
        {
            time = 0;
        }
        textMesh.text = time.ToString("0.00");
    }
}
