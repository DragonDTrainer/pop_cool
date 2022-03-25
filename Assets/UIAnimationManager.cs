using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimationManager : MonoBehaviour
{
    public static UIAnimationManager Instance { get; set; }
    public List<Image> FreezeImages;

    private void Awake()
    {
        Instance = this;
    }
    private void LateUpdate()
    {
        AnimateFreeze();
    }
    public void AnimateFreeze()
    {
        if (PlayerStats.instance.timeStop > 0)
        {
            foreach(Image img in FreezeImages)
            {
                img.color = ReferenceInScene.Instance.freezeColor;
            }
        }
        else
        {
            foreach (Image img in FreezeImages)
            {
                img.color = ReferenceInScene.Instance.normalColor;
            }
        }
    }
}

