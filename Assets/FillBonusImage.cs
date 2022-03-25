using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBonusImage : MonoBehaviour
{
    public float time;

    IEnumerator fillBonus()
    {

        Vector2 positionStart = Vector2.zero;
        positionStart.x = Random.Range(-Screen.width / 2, Screen.width / 2);
        positionStart.y = Random.Range(-Screen.height / 2, Screen.height / 2);
        Vector2 positionEnd = Vector2.zero;
        positionEnd.x = Random.Range(positionStart.x, Screen.width / 2);
        positionEnd.y = Random.Range(-Screen.height / 2, Screen.height / 2);

        float e = 0;
        while (e < 1)
        {
            Vector3 position = Vector3.Lerp(positionStart, positionEnd, e);
            e += 0.002f;
            //rectTransform.anchoredPosition = position;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return null;
        Destroy(gameObject);
    }
}
