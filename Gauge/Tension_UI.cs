using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//免許とれたのおめでとー！！！
public class Tension_UI : MonoBehaviour
{
    public GameObject tensionui;
    //テンションをとってくる
    public GameObject tapoperation;
    private Tap_operation script;

    private int taptension;

    // Start is called before the first frame update
    void Start()
    {
        script = tapoperation.GetComponent<Tap_operation>();

    }

    // Update is called once per frame
    void Update()
    {
        int taptension = script.tension;
        this.tensionui.GetComponent<TextMeshProUGUI>().text = taptension.ToString();
    }
}
