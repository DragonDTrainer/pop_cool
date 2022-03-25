using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceSpawner : MonoBehaviour
{
    public static IceSpawner Instance { get; set; }

    public GameObject iceSnowflake;
    public Transform canvas;

    private void Awake()
    {
        Instance = this;
    }
  
    public void SpawnSnowflake(float time)
    {
        StartCoroutine(MakeItSnow(time));
    }
    IEnumerator MakeItSnow(float time)
    {
        float currenttime = 0;
        Rect parentRect = transform.parent.GetComponent<RectTransform>().rect;
        
        while (currenttime<time)
        {
            int maxSnowflake = Random.Range(0, 2);
            for (int i = 0; i < maxSnowflake; i++)
            {
                GameObject snowflake = Instantiate(iceSnowflake);
                snowflake.transform.SetParent(iceSnowflake.transform.parent);
                snowflake.SetActive(true);
                RectTransform rt = snowflake.GetComponent<RectTransform>();
                rt.localScale = Vector3.one;
                Vector3 startPos = new Vector2(0, 0);
                startPos.x = Random.Range(-parentRect.width / 2, parentRect.width / 2);
                startPos.y = parentRect.height / 2;//Random.Range(0, parentRect.height / 2);

                Vector3 endPos = new Vector2(0, 0);
                endPos.x = startPos.x;
                endPos.y = Random.Range(startPos.y,-50 );//-parentRect.height / 2);
                rt.anchoredPosition = startPos;
                Vector2 sizeImg = rt.sizeDelta;
                sizeImg.x = Random.Range(20,sizeImg.x);
                sizeImg.y = sizeImg.x;
                rt.sizeDelta = sizeImg;
                RawImage img = snowflake.GetComponent<RawImage>();
                Color color = img.color;
                color.a = Random.Range(0,img.color.a);
                img.color = color;
                SnowflakeManager snowflakeComp = snowflake.GetComponent<SnowflakeManager>();
                snowflakeComp.startPos = startPos;
                snowflakeComp.endPos = endPos;
                Destroy(snowflake, 1);
            }

            yield return new WaitForSeconds(Time.deltaTime);
            currenttime += Time.deltaTime;
        }
    }
}
