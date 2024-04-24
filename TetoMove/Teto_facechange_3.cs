using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//めつぶり口開きテトface_metuburiutai
public class Teto_facechange_3 : MonoBehaviour
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
        //２から移行
        if (time > 43.0 && time < 43.3)
        {
            hoge.enabled = true;
        }
        //１へ移行
        if (time > 54.0 && time < 54.3)
        {
            hoge.enabled = false;
        }
        //4から移行
        if (time > 75.0 && time < 75.3)
        {
            hoge.enabled = true;
        }
        //4へ移行
        if (time > 81.0 && time < 81.3)
        {
            hoge.enabled = false;
        }
    }
}
