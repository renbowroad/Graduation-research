using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;    
using System.IO; 

public class Beam : MonoBehaviour
{
    
    public GameObject centerCamera;

    LineRenderer lineRenderer;
    Vector3 hitPos;
    Vector3 tmpPos;
    Vector3 hit_point;
    int targetCnt;
    private StreamWriter sw;
    GameObject saveCsv;
    SaveCsv SaveCsv;
    GameObject GameObject;
    RandomRange RandomRan;
    GameObject Target;
    Target target;
    _RandomMove RandomMove;
    List<float> List;

    public Text targetText;
    private int score = 0;

    float lazerDistance = 50.0f;
    float lazerStartPointDistance = 0.15f;
    float lineWidth = 0.05f;

    [SerializeField]
    GameObject leftController;
    [SerializeField]
    LineRenderer rayObject;
    [SerializeField]
    private GameObject LogObj;
    private Log Log;
    DateTime now = DateTime.Now;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.startWidth = lineWidth;
        saveCsv = GameObject.Find("SaveCsv");
        SaveCsv = saveCsv.GetComponent<SaveCsv>();
        GameObject = GameObject.Find("RandomRange");
        Target = GameObject.Find("Target");
        RandomRan = GameObject.GetComponent<RandomRange>();
        target = Target.GetComponent<Target>();
        RandomMove = Target.GetComponent<_RandomMove>();

        // Log = LogObj.GetComponent<Log>();
        // // ログの記録
        // StartCoroutine(nameof(AddCoordinateHistory));

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) )//OVRInput.Get(OVRInput.RawButton.RIndexTrigger) Input.GetKey(KeyCode.Space)
        {
            lineRenderer.enabled = true;
            OnRay();
        }
        else
        {
            lineRenderer.enabled = false;
        }

       SetCounterValues();

    }

    void OnRay()
    {      
        Vector3 direction = centerCamera.transform.forward * lazerDistance;
        Vector3 rayStartPosition = centerCamera.transform.forward * lazerStartPointDistance;
        Vector3 y_axis = new Vector3(0, 0.5f, 0);
        Vector3 pos = centerCamera.transform.position + y_axis;
        Ray ray = new Ray(pos+rayStartPosition, centerCamera.transform.forward);//発生地点，進む方向

        lineRenderer.SetPosition(0, pos + rayStartPosition);//開始点
        lineRenderer.SetPosition(1, pos + direction);

        // if (Physics.Raycast(ray, out hit, lazerDistance))//どのrayに関して，衝突したオブジェクトの情報，rayの長さ
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        foreach(var hit in hits)
        {
            if(hit.collider.tag == "Target")
            {
                // Debug.Log (hit.point);
                hit_point = hit.point;  
                lineRenderer.SetPosition(1, hit_point);
                SaveCsv.SaveData(score + 1 ,hit_point, target.center_pos);
                if(target.HP_value <= 0.005)
                {
                    targetCnt++;
                    RandomRan.RandomRan();
                    target.RecoveryHP();
                    target.HP_value = 1.0f;
                    target.center_pos = RandomRan.new_pos;
                    RandomMove.index = UnityEngine.Random.Range(1, 4);
                }
                else
                {
                    target.SetHP();
                }
            }
            // else
            // {      
            //     lineRenderer.SetPosition(1, pos + direction);
            // }
        }

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 0.1f);

    }

    public int GetTargetCount()
    {
        return targetCnt;
    }

    void SetCounterValues()
    {
        score = GetTargetCount();
        targetText.text = score.ToString();
    }
}




