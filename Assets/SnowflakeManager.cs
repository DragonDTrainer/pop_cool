using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeManager : MonoBehaviour
{
    RectTransform rectTransform;
    public Vector2 startPos;
    public Vector2 endPos;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Start()
    {
        StartCoroutine(moveObject());
    }
    IEnumerator moveObject()
    {
        float e = 0;
        while (e < 1)
        {
            Vector3 position = Vector3.Lerp(startPos, endPos, e);
            rectTransform.anchoredPosition = position;
            yield return new WaitForSeconds(Time.deltaTime);
            e += Time.deltaTime;
        }
        yield return null;
        Destroy(gameObject);
    }
}
