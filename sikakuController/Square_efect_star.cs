using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Square_efect_star : MonoBehaviour
{
    private float time;
    public VideoPlayer videoPlayer;
    private float zposi = 10.0f;
    private bool a = true;
    void Start()
    {
        time = 0;
    }

    public void videoplay(int state)
    {
        if (time < 65.0)
        {
            //ローカル座標
            //左上 x=-1.2,y=1
            //右上 x=1.1,y=1
            //右下 x=1,y=-1.1
            //左下 x=-1.2,y=-1.1
            if (state == 1)
            {
                this.transform.localPosition = new Vector3(-1.2f, 1f, zposi);
            }
            else if (state == 2)
            {
                this.transform.localPosition = new Vector3(1.1f, 1f, zposi);
            }
            else if (state == 3)
            {
                this.transform.localPosition = new Vector3(1f, -1.1f, zposi);
            }
            else if (state == 4)
            {
                this.transform.localPosition = new Vector3(-1.2f, -1.1f, zposi);
            }
            videoPlayer.Play();
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        if (a)
        {
            if (time > 65.0)
            {
                this.transform.localPosition = new Vector3(-5f, -1.1f, 15);
                a = false;
            }
        }
    }
}