using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ウインクテトface_wink
public class Teto_facechange_5 : MonoBehaviour
{
    private float time;
    public Renderer hoge;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        hoge.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //4から移行
        if (time > 85.0 && time < 85.3)
        {
            hoge.enabled = true;
        }
        //2へ移行
        if (time > 89.0 && time < 89.3)
        {
            hoge.enabled = false;
        }
    }
}
