using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameKit;
using Lean.Touch;
using UnityEngine.EventSystems;
using System.Linq;
using TMPro;

public class Mod1_GameManager : MonoBehaviour
{
    public static Mod1_GameManager Instance { get; set; }
    public delegate void Event();
    public Event onNextSphereMovedCompleted;
 
    public Image SpherePrefab;
    public Colors colors;
    public GameObject containerSphere;
    int spawnNumber = 7;

    public SphereCreated_manager[] spheres;
    public SphereCreated_manager currentSphere;
    public RectTransform delimiter;
    public RectTransform startPoint;
    public RectTransform endPoint;
    public RectTransform currentSpherePoint;
    public Canvas canvas;
    //public LeanDragTranslate currentDrag;


    public List<bool> over;
    public int ongrabID;
    Vector2 size;
    public Mod1_SphereTimeManager timeManagerSphere;
    public TextMeshProUGUI textPointAmount;
    public TextMeshProUGUI textPointPrefab;
    private void Awake()
    {
        Instance = this;
        spheres = new SphereCreated_manager[spawnNumber];
    }

    // Update is called once per frame
    private void Start()
    {
        //int screenHeightCutted = Screen.height / 2;
        //float FirstContainerSize = screenHeightCutted - (screenHeightCutted * delimiter.anchorMax.y);
        //print(FirstContainerSize);
        //float minpos = FirstContainerSize - screenHeightCutted;
        //minpos = 0 - minpos;
        //print(minpos);
        size = new Vector2(100/canvas.transform.lossyScale.y, 100/canvas.transform.lossyScale.y);
        ReferenceInScene.Instance.timerCurrentSphere.sizeDelta =new Vector2( size.x+30,size.y+30);
        //float maxposition = Screen.height / 2;
        //positions = new Vector2[7];
        //float difference = startPoint.position.y - endPoint.position.y;
        //difference /= canvas.transform.lossyScale.y;
        //float dividerValue = difference / (spawnNumber);
        
        //print(startPoint.position);
        //print(endPoint.position);
        //print(dividerValue);
        //for (int i = 0; i < spawnNumber; i++)
        //{
        //    positions[i] = new Vector2(0, startPoint.anchoredPosition.y /*(maxposition - ((size.y*2) * i))-size.y*/);
        //    positions[i].y = positions[i].y - (dividerValue * i) - size.y;
        //}
        
        for (int i = 0; i < spheres.Length; i++)
        {
            Image instantiatedSphere = Instantiate(SpherePrefab);

            Draggable drag = instantiatedSphere.GetComponent<Draggable>();
            instantiatedSphere.name = i.ToString();
            instantiatedSphere.gameObject.SetActive(true);
            instantiatedSphere.transform.SetParent(containerSphere.transform);
            instantiatedSphere.transform.localScale = Vector3.one;
            RectTransform rectTrnsf = instantiatedSphere.GetComponent<RectTransform>();
            rectTrnsf.sizeDelta = size;
            //rectTrnsf.anchoredPosition = positions[i];
            //rectTrnsf.rect.Set(positions[i].x,100, rectTrnsf.rect.width, rectTrnsf.rect.height);

            ColorBlock.color_Piece col = colors.GetRandom();
            instantiatedSphere.color = col.color;
            SphereCreated_manager sphereCreated = instantiatedSphere.GetComponent<SphereCreated_manager>();
            sphereCreated.ColorID = col.ID;
            sphereCreated.drag = drag;
            spheres[i] = sphereCreated;
        }
        CreateSingleSphere();

        timeManagerSphere.textMesh.transform.SetAsLastSibling();
        //LeanTouch.OnFingerUp += ResetPosition;
        //LeanTouch.OnFingerDown += Grab;

    }

    public void CreateNextBall()
    {
        Image instantiatedSphere = Instantiate(SpherePrefab);

        Draggable drag = instantiatedSphere.GetComponent<Draggable>();
        instantiatedSphere.name = "yupopy";
        instantiatedSphere.gameObject.SetActive(true);
        instantiatedSphere.transform.SetParent(containerSphere.transform);
        
        instantiatedSphere.transform.localScale = Vector3.one;
        RectTransform rectTrnsf = instantiatedSphere.GetComponent<RectTransform>();
        rectTrnsf.sizeDelta = size;
        //rectTrnsf.anchoredPosition = positions[i];
        //rectTrnsf.rect.Set(positions[i].x,100, rectTrnsf.rect.width, rectTrnsf.rect.height);

        ColorBlock.color_Piece col = colors.GetRandom();
        instantiatedSphere.color = col.color;
        SphereCreated_manager sphereCreated = instantiatedSphere.GetComponent<SphereCreated_manager>();
        sphereCreated.ColorID = col.ID;
        sphereCreated.drag = drag;

        spheres[0] = sphereCreated;
        onNextSphereMovedCompleted();
        instantiatedSphere.transform.SetAsFirstSibling();
        SpherePrefab.transform.SetAsFirstSibling();
    }
    public void CreateSingleSphere()
    {
        Image instantiatedSphere = Instantiate(SpherePrefab);
        EventSystem event_ = instantiatedSphere.GetComponent<EventSystem>();
        RectTransform rectTrnsf = instantiatedSphere.GetComponent<RectTransform>();
        Draggable drag = instantiatedSphere.GetComponent<Draggable>();
        SphereCreated_manager sphereCreated = instantiatedSphere.GetComponent<SphereCreated_manager>();
        instantiatedSphere.gameObject.SetActive(true);
        instantiatedSphere.transform.SetParent(canvas.transform);
        instantiatedSphere.transform.localScale = Vector3.one;
        rectTrnsf.sizeDelta = size;
        rectTrnsf.position = currentSpherePoint.position;
        //currentDrag = instantiatedSphere.GetComponent<LeanDragTranslate>();
        //currentDrag.enabled = true;
        //rectTrnsf.anchoredPosition = positions[i];
        //rectTrnsf.rect.Set(positions[i].x,100, rectTrnsf.rect.width, rectTrnsf.rect.height);
        drag.startPosition = rectTrnsf.anchoredPosition;
        drag.enabled = true;
        event_.enabled = true;
        ColorBlock.color_Piece col = colors.GetRandom();
        instantiatedSphere.color = col.color;
        sphereCreated.ColorID = col.ID;
        sphereCreated.drag = drag;
        currentSphere = sphereCreated;

    }
    public void MoveSphere(SphereCreated_manager nextSphere)
    {
        Draggable drag = nextSphere.GetComponent<Draggable>();
        EventSystem event_ = nextSphere.GetComponent<EventSystem>();
        Image img = nextSphere.GetComponent<Image>();
        SphereCreated_manager sphereCreated = nextSphere.GetComponent<SphereCreated_manager>();
        RectTransform rectTrnsf = nextSphere.GetComponent<RectTransform>();

        nextSphere.transform.SetParent(canvas.transform);
        nextSphere.transform.localScale = Vector3.one;
        rectTrnsf.position = currentSpherePoint.position;
        drag.startPosition = rectTrnsf.anchoredPosition;
        drag.enabled=true;
        event_.enabled = true;
        //currentSphere = sphereCreated;
    }
    public void ReplaceSphereWithNew()
    {
        print("Need replace");
        GameObject toDestroy = currentSphere.gameObject;
        //CalculateTime(currentSphere);

        currentSphere = spheres[spheres.Length-1];
        currentSphere.name = "ikk";
        print(spawnNumber);
        for (int i = spheres.Length - 1; i >= 1; i--)
        {
            spheres[i] = spheres[i - 1];
            print(spheres[i]);
        }
        MoveSphere(currentSphere);
        print("create");
        CreateNextBall();
        Destroy(toDestroy); 
        int points = CalculatePoints();
        print(points);
        PlayerStats.instance.points += points;
        SpawnPointFlag(points);
        ResetTimerSphere();
        timeManagerSphere.textMesh.transform.SetAsLastSibling();
    }

    public int CalculatePoints()
    {
        float perc = timeManagerSphere.time/ Constants.timeSphereFull;
        return PointsValues.PointCalculator(perc, Constants.pointFullSphere);
    }
    
    //public void CalculateTime(BonusManager bonus)
    //{
    //    bonus.bonus.AddBonus();
    //}

    public void SpawnPointFlag(int points)
    {
        TextMeshProUGUI textPoint = Instantiate(textPointPrefab);
        textPoint.transform.SetParent(textPointPrefab.transform.parent);
        textPoint.text = "+" + points.ToString();
        textPoint.gameObject.SetActive(true);
        RectTransform rt = textPoint.GetComponent<RectTransform>();
        rt.localScale = Vector3.one;
        print(textPoint.transform.position);
        Vector3 anch = rt.anchoredPosition3D;
        anch.z = 0 ;
        rt.anchoredPosition3D = anch;
        StartCoroutine(DestroyText());
        IEnumerator DestroyText()
        {
            yield return new WaitForSeconds(2f);
            DestroyImmediate(textPoint.gameObject);
        }
    }

    public void ResetTimerSphere()
    {
        timeManagerSphere.time = Constants.timeSphereFull;
    }

    private void Update()
    {
        textPointAmount.text = PlayerStats.instance.points.ToString();
    }
    //private void ResetPosition(LeanFinger fingers= null)
    //{
    //    currentDrag.transform.position = currentSpherePoint.position;
    //}
    //private void Grab(LeanFinger fingers= null)
    //{
    //    print(("Grab"));
    //}

    IEnumerator SpawnBonus()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10, 50));
        }
    }
    public void MakeUiEffectBump()
    {
        ReferenceInScene.Instance.ContainerUi.SetBool("Bomb", true);
         StartCoroutine(setoffBool());
        IEnumerator setoffBool()
        {
            yield return new WaitForSeconds(0.2f);
            ReferenceInScene.Instance.ContainerUi.SetBool("Bomb", false);
        }
    }


}
