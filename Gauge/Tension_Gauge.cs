using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tension_Gauge : MonoBehaviour
{
    //テンションをとってくる
    public GameObject tapoperation;
    private Tap_operation script;
    private int taptension;

    //ゲージ操作
    public GameObject gauge;
    private float tension1;

    // Start is called before the first frame update
    void Start()
    {
        script = tapoperation.GetComponent<Tap_operation>();
        tension1 = gauge.GetComponent<RectTransform>().sizeDelta.y / 500;
    }

    // Update is called once per frame
    void Update()
    {
        int taptension = script.tension;
        Vector2 nowsafes = gauge.GetComponent<RectTransform>().sizeDelta;
        nowsafes.y = tension1 * taptension;
        gauge.GetComponent<RectTransform>().sizeDelta = nowsafes;
    }
}
