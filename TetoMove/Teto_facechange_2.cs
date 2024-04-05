using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ぱちっと目の空いた口閉じテトface_natural
public class Teto_facechange_2 : MonoBehaviour
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
        //2から移行
        if (time > 32.0 && time < 32.3)
        {
            hoge.enabled = true;
        }
        //３に移行
        if (time > 43.0 && time < 43.3)
        {
            hoge.enabled = false;
        }
        //5から移行
        if (time > 89.0 && time < 89.3)
        {
            hoge.enabled = true;
        }
    }
}
