using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//通常衣装
public class Teto_bodychange1 : MonoBehaviour
{
    private float time;
    public Renderer hoge;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 65.0 && time < 65.3)
        {
            hoge.enabled = false;
        }
    }
}
