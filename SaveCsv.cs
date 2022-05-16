using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using System.IO;
using System.Text;

public class SaveCsv : MonoBehaviour
{
    StreamWriter sw;
    FileInfo fi;
    DateTime now = DateTime.Now;
    string fileName = "009_A_";
    Target target;
    Vector3 center_pos;
    string path = @"C:/Users/nr/Integration/Assets";
    string time;
    int index;
    _RandomMove RandomMove;
    // /sdcard/Android/data/com.DefaultCompany.Integration/files

    CountDown countdown;


    void Start()
    {
        fileName = fileName + now.Year.ToString() + "_" + now.Month.ToString() + "_" + now.Day.ToString() + "__" + now.Hour.ToString() + "_" + now.Minute.ToString() + "_" + now.Second.ToString();
        fi = new FileInfo(Application.persistentDataPath + "/Log/" + fileName + ".csv");
        sw = fi.AppendText();
        string[] s1 = { "Current Time", "index", "Target Number", "HitPoint:X", "HitPoint:Y", "HitPoint:Z", "TargetCenter:X", "TargetCenter:Y", "TargetCenter:Z"};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        target = GameObject.Find("Target").GetComponent<Target>();
        center_pos = target.center_pos;
        countdown = GameObject.Find("CountDown").GetComponent<CountDown>();
        RandomMove = GameObject.Find("Target").GetComponent<_RandomMove>();
    }

    public void SaveData(int target, Vector3 data, Vector3 center_pos)
    {
        sw.Write(time + ",");
        sw.Write(index + ",");
        List<float> List = new List<float>();
        List.Add(target);
        List.Add(data.x);
        List.Add(data.y);
        List.Add(data.z);
        List.Add(center_pos.x);
        List.Add(center_pos.y);
        List.Add(center_pos.z);
        for(int i = 0; i < 7; i++)
        {
            sw.Write(List[i] + ",");
            if(i == 6)
            {
                sw.WriteLine();
            }
        }
    }

    void Update()
    {
        index = RandomMove.index;
        DateTime n = DateTime.Now;
        time = n.Year.ToString() + "_" + n.Month.ToString() + "_" + n.Day.ToString() + "__" + n.Hour.ToString() + ":" + n.Minute.ToString() + ":" + n.Second.ToString();
        if (countdown.time < 0)
        {
            sw.Close();
        }

    }
}
