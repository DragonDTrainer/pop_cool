using GameKit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static BonusContainer;

namespace GameKit
{
    [CreateAssetMenu(fileName = "Bonuses", menuName = "ScriptableObjects/Bonus", order = 2)]

    public class BonusBlock : ScriptableObject
    {
        public Sprite freezeImage;
        public Sprite plusTimeImage;
        public Sprite plusPointImage;

    }
}

[System.Serializable]
public class BonusContainer
{
    public float freezeTimeBonus;
    public float addTimeBonus;
    public int addPointsBonus;
    public List<ClassesBonus> classbon;

    public void GetBonus()
    {
        foreach (ClassesBonus cla_ in classbon)
        {
            switch (cla_)
            {
                case ClassesBonus.Freeze:
                    {
                        Freeze.FreezeTimeBonus(freezeTimeBonus);
                        break;
                    }
                case ClassesBonus.PlusTime:
                    {
                        PlusTime.PlusTimeBonus(addTimeBonus);
                        break;
                    }
                case ClassesBonus.PlusPoint:
                    {
                        PlusPoints.PlusPointsBonus(addPointsBonus);
                        break;
                    }
            }
        }
    }

    [System.Serializable]
    public enum ClassesBonus
    {
        Freeze,
        PlusPoint,
        PlusTime,
    }
}

[System.Serializable]
public class Freeze
{
    public static void FreezeTimeBonus(float howMuchFreeze)
    {
        PlayerStats.instance.FreezeTime(howMuchFreeze);
        IceSpawner.Instance.SpawnSnowflake(howMuchFreeze);
        Mod1_GameManager.Instance.MakeUiEffectBump();
    }
}

[System.Serializable]
public class PlusTime
{
    public static void PlusTimeBonus(float howMuchTime)
    {
        PlayerStats.instance.AddTime(howMuchTime);
        Mod1_GameManager.Instance.MakeUiEffectBump();
    }
}

[System.Serializable]
public class PlusPoints : MonoBehaviour
{
    public static void PlusPointsBonus(int howMuchPoints)
    {
        PlayerStats.instance.points += howMuchPoints;
        Mod1_GameManager.Instance.MakeUiEffectBump();
        //ReferenceInScene
    }
 
}
public class BonusClassesImageSet
{
    public static List<Sprite> GetImageFromBonus(BonusContainer bon,BonusBlock block)
    {
        List<Sprite> images = new List<Sprite>();
        foreach (ClassesBonus cla_ in bon.classbon)
        {
            switch (cla_)
            {
                case ClassesBonus.Freeze:
                    {
                        images.Add(block.freezeImage);
                        break;
                    }
                case ClassesBonus.PlusTime:
                    {
                        images.Add(block.plusTimeImage);
                        break;
                    }
                case ClassesBonus.PlusPoint:
                    {
                        images.Add(block.plusPointImage);
                        break;
                    }
            }
            
        }
        return images;
    }
}