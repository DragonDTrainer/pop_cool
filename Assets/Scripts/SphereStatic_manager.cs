using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SphereStatic_manager : MonoBehaviour
{
    public int ID;
    MouseIsOverUIElement mouseOverElement;
    Animator animator;
    public bool onreplace;
    private void Awake()
    {
        mouseOverElement = GetComponent<MouseIsOverUIElement>();
        animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        if (mouseOverElement.isOver && ! onreplace)
        {
            if (Mod1_GameManager.Instance.currentSphere.ColorID == ID&& Mod1_GameManager.Instance.currentSphere.drag.dragging == true)
            {
                StartCoroutine(ReplaceAsync());
            }
        }
        Animation();

        
    }
    IEnumerator ReplaceAsync()
    {
        if (mouseOverElement.isOver)
        {
            onreplace = true;
            Register();
            bool lastMode = mouseOverElement.isOver;
            while (!Input.GetMouseButtonUp(0))
            {
                lastMode = mouseOverElement.isOver;
                yield return null;
            }
            if (lastMode)
            {
                Mod1_GameManager.Instance.ReplaceSphereWithNew();
            }
            else { onreplace = false; }
        }
    }
    private void Register()
    {
        Mod1_GameManager.Instance.onNextSphereMovedCompleted += OnEndMoveNextSphere;
    }
    private void Unregister()
    {
        Mod1_GameManager.Instance.onNextSphereMovedCompleted -= OnEndMoveNextSphere;
    }

    public void OnEndMoveNextSphere()
    {
        Unregister();
        onreplace = false;
    }
   
    public void Animation()
    {
        if (mouseOverElement.isOver)
        {
            animator.SetBool("Big", true);
        }
        else
        {
            animator.SetBool("Big", false);
        }
    }

}
