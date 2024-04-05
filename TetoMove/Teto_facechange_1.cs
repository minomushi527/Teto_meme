using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//めつぶり口閉じテトface_sleep
public class Teto_facechange_1 : MonoBehaviour
{
    private float time;
    public Renderer hoge;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        //一番手
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //２に移行
        if (time > 32.0 && time < 32.3)
        {
            hoge.enabled = false;
        }
        //3から移行
        if (time > 54.0 && time < 54.3)
        {
            hoge.enabled = true;
        }
        //4へ移行
        if (time > 65.0 && time < 65.3)
        {
            hoge.enabled = false;
        }
    }
}
