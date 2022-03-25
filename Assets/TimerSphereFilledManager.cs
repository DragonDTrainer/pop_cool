using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSphereFilledManager : MonoBehaviour
{
    public Image filled;

    private void LateUpdate()
    {
        filled.fillAmount = Mod1_SphereTimeManager.Instance.time / Constants.timeSphereFull;
    }
}
