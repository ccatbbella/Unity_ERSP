using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    System.DateTime myTime;

    // Start is called before the first frame update
    void Start()
    {
        myTime = new System.DateTime(1980, 12, 5);
        
       

    }
    // Update is called once per frame
    
    void Update()
    {
        string month, day;
        myTime = myTime.AddDays(Time.deltaTime);
        month = myTime.Month.ToString();
        day = myTime.Day.ToString();
        if (myTime.Month < 10)
        {
            month = "0" + myTime.Month.ToString();
        }
        if (myTime.Day < 10)
        {
            day = "0" + myTime.Day.ToString();
        }
        timerText.text = "year month day " + "\n" + myTime.Year.ToString() + " " + month + " " + day;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(231 + 500 * Time.time, 1701, 296);
        }
    }
    
}
