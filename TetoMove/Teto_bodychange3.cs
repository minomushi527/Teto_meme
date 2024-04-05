using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ステージ衣装マイクあり
public class Teto_bodychange3 : MonoBehaviour
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
        if (time > 75.0 && time < 75.3)
        {
            hoge.enabled = true;
        }
    }
}
