using GameKit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour
{
    public static BonusManager Instance { get; set; }

    public BonusBlock bonuses;
    public List<BonusObject> bonusCreated;
    public List<BonusContainer> bonus;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //SpawnObjectRandom();
        StartCoroutine(ContinueSpawn());
    }

    public void SpawnObjectRandom()
    {
        foreach (BonusContainer bonus_ in bonus)
        {
            GameObject go  = Instantiate(ReferenceInScene.Instance.bonusImagePrefab.gameObject);
            go.SetActive(true);
            go.transform.SetParent(ReferenceInScene.Instance.bonusImagePrefab.gameObject.transform.parent);
            BonusObject bonusInstantiated = go.GetComponent<BonusObject>();
            bonusInstantiated.classes = bonus_;
            RectTransform rt = bonusInstantiated.GetComponent<RectTransform>();
            rt.localScale = Vector3.one;
        }
    }
    IEnumerator ContinueSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5,10));
            GameObject go = Instantiate(ReferenceInScene.Instance.bonusImagePrefab.gameObject);
            go.SetActive(true);
            go.transform.SetParent(ReferenceInScene.Instance.bonusImagePrefab.gameObject.transform.parent);
            BonusObject bonusInstantiated = go.GetComponent<BonusObject>();
            BonusContainer bonus_ = bonus[Random.Range(0, bonus.Count)];

            List<Sprite> imgs = BonusClassesImageSet.GetImageFromBonus(bonus_,bonuses);
            Image img = go.GetComponent<Image>();
            img.sprite = imgs.First();
            bonusInstantiated.classes = bonus_;
            RectTransform rt = bonusInstantiated.GetComponent<RectTransform>();
            rt.localScale = Vector3.one;
            Destroy(go,3);
        }
    }

}
