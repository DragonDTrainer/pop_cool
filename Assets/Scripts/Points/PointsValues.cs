using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsValues 
{

    public static int PointCalculator(float perc, int points)
    {
        return (int)((float)points * perc);
    }
}
public class Constants
{
    public const int pointFullSphere = 100;
    public const int timeSphereFull = 4;
}