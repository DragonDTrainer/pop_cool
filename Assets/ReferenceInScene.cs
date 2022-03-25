using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReferenceInScene : MonoBehaviour
{
    public static ReferenceInScene Instance { get; set; }
   
    public Color freezeColor;
    public Color normalColor;
    public Image bonusImagePrefab;
    public Animator ContainerUi;
    public RectTransform timerCurrentSphere;
    private void Awake()
    {
        Instance = this;
    }
}
