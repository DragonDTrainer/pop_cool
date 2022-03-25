using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBonusManager : MonoBehaviour
{
    RectTransform rectTransform;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        //yield return new WaitForSeconds(2f);
        StartCoroutine(moveObject());
        //StartCoroutine(Dissolve());
    }
    IEnumerator moveObject()
    {
        
        Vector2 positionStart = Vector2.zero;
        Rect sizeParentRect = Mod1_GameManager.Instance.canvas.GetComponent<RectTransform>().rect;
        positionStart.x = Random.Range(-sizeParentRect.width / 2, sizeParentRect.width / 2);
        positionStart.y = Random.Range(-sizeParentRect.height / 2, sizeParentRect.height / 2);
        Vector2 positionEnd = Vector2.zero;
        positionEnd.x = Random.Range(positionStart.x, sizeParentRect.width / 2);
        positionEnd.y = Random.Range(-sizeParentRect.height / 2, sizeParentRect.height / 2);

        float e=0;
        while (e < 1)
        {
            Vector3 position= Vector3.Lerp(positionStart, positionEnd, e);
            e += 0.002f;
            rectTransform.anchoredPosition = position;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return null;
    }
    //IEnumerator Dissolve()
    //{
    //    Vector2 startSize = rectTransform.sizeDelta;
    //    float timeElapsed=0;
    //    float lerpDuration = 3;
    //    float startValue = 0;
    //    float endValue =startSize.x;
    //    float valueToLerp;
    //    while (timeElapsed < lerpDuration)
    //    {
    //        valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
    //        timeElapsed += Time.deltaTime;
    //        float value = endValue - valueToLerp;
    //        if (value < 50)
    //        {
    //            value = 50;
    //        }
    //        rectTransform.sizeDelta = new Vector3(value,value);
    //        yield return new WaitForSeconds(Time.deltaTime);
    //        print(timeElapsed+"  "+valueToLerp);
    //    }
    //}
}
