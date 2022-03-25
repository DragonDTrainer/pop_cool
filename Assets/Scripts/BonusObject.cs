using GameKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObject : MonoBehaviour
{
    public BonusContainer classes;

    public void AddBonus()
    {
        classes.GetBonus();
        Destroy(gameObject);
    }

}
