using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge_Controller : MonoBehaviour
{
    public GameObject gauge;
    private bool countstart = false;
    private float time = 0;
    private float count1;
    private float songlength = 97;
    // Start is called before the first frame update
    void Start()
    {
        countstart = true;
        count1 = gauge.GetComponent<RectTransform>().sizeDelta.x / songlength;
    }

    // Update is called once per frame
    void Update()
    {
        if (countstart)
        {
            time += Time.deltaTime;
            Vector2 nowsafes = gauge.GetComponent<RectTransform>().sizeDelta;
            nowsafes.x = count1 * time;
            gauge.GetComponent<RectTransform>().sizeDelta = nowsafes;
        }
    }
}