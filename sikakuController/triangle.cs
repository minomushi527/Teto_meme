using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    //public gameObject state_change;
    private int state = 1; // 1:→ 2:↓ 3:← 4:↑


    //グローバル座標
    //左上 x=-3,y=5
    //右上 x=-1,y=5
    //右下 x=-1,y=3
    //左下 x=-3,y=3

    //ローカル座標
    //左上 x=-1.2,y=1
    //右上 x=1.1,y=1
    //右下 x=1,y=-1.1
    //左下 x=-1.2,y=-1.1

    //private float bpm = 89; //1分間に89回

    private float speed = 3.411667f;//計算->2.3(正方形の一辺) / (60[min]/89[bpm])
    //少数第七位四捨五入

    //誘導のための正解のリズムをならす
    public AudioSource right_audio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //現在位置を取得
        Vector3 posi = this.transform.localPosition;
        //状態を更新
        if (state == 1 && posi.x >= 1.15)
        {
            state = 2;
            right_audio.PlayOneShot(right_audio.clip);
        }
        else if (state == 2 && posi.y <= -1.15)
        {
            state = 3;
            right_audio.PlayOneShot(right_audio.clip);
        }
        else if (state == 3 && posi.x <= -1.15)
        {
            state = 4;
            right_audio.PlayOneShot(right_audio.clip);
        }
        else if (state == 4 && posi.y >= 1.15)
        {
            state = 1;
            right_audio.PlayOneShot(right_audio.clip);
        }


        //任意の方向に進む
        /*if (state == 1)
        {
            Vector3 movement = new Vector3(speed * Time.deltaTime, 0f, 0f);
            transform.Translate(movement);
        }
        else if (state == 2)
        {
            Vector3 movement = new Vector3(0f, -1 * speed * Time.deltaTime, 0f);
            transform.Translate(movement);
        }
        else if (state == 3)
        {
            Vector3 movement = new Vector3(-1 * speed * Time.deltaTime, 0f, 0f);
            transform.Translate(movement);
        }
        else if (state == 4)
        {
            Vector3 movement = new Vector3(0f, speed * Time.deltaTime, 0f);
            transform.Translate(movement);
        }*/

        //3/10変更
        switch (state)
        {
            case 1:
                transform.Translate(speed * Time.deltaTime, 0f, 0f, Space.Self);
                break;
            case 2:
                transform.Translate(0f, -speed * Time.deltaTime, 0f, Space.Self);
                break;
            case 3:
                transform.Translate(-speed * Time.deltaTime, 0f, 0f, Space.Self);
                break;
            case 4:
                transform.Translate(0f, speed * Time.deltaTime, 0f, Space.Self);
                break;
        }
    }
}
