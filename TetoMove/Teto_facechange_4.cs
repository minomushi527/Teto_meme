using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//目開き口開きテトface_utau
public class Teto_facechange_4 : MonoBehaviour
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
        //１から移行
        if (time > 65.0 && time < 65.3)
        {
            hoge.enabled = true;
        }
        //3へ移行
        if (time > 75.0 && time < 75.3)
        {
            hoge.enabled = false;
        }
        //3から移行
        if (time > 81.0 && time < 81.3)
        {
            hoge.enabled = true;
        }
        //5へ移行
        if (time > 85.0 && time < 85.3)
        {
            hoge.enabled = false;
        }
    }
}
