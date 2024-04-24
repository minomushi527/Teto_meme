using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_operation : MonoBehaviour
{
    public GameObject triangle;
    public int spotstate = 1; //三角の位置から割り出される現在押そうとしている拍
    private int rismstate = 1;  //待機、次に押す拍はrismstateの値
    public int evaluation = 0; //1:excelent,2:good,3:bad 0:miss//使ってない必要ない

    public int tension = 0; //テンション

    //点数
    public int excelent_point = 5;
    public int good_point = 1;
    public int bad_point = -5;
    public int miss_point = -10;

    public AudioSource sound;
    public AudioClip excelent_sound;//excelent
    public AudioClip good_sound;//good
    public AudioClip bad_sound;//bad


    public GameObject flower_prefab; //押した位置に生まれる
    public GameObject sikaku;//ワールド座標取得用

    //タップしたら四角の隅にエフェクト
    public GameObject Square_efect_star;
    private Square_efect_star starefect;

    private bool switch4to1 = false;

    //判定の良し悪しの表示を出す
    public GameObject excellent_prefab;
    public GameObject nice_prefab;
    public GameObject bad_prefab;
    public GameObject miss_prefab;

    public Vector3 hantei_syokiiti_right = new Vector3(15f, -3f, 0.0f);
    public Vector3 hantei_syokiiti_under = new Vector3(8f, -11f, 9.0f);


    // 1:左上 2:右上 3:右下 4:左下

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
    // Start is called before the first frame update

    //miss,bad,nice,excellentの数を数える
    public int misscount = 0;
    public int badcount = 0;
    public int nicecount = 0;
    public int excellentcount = 0;

    // void hantei_destroy()
    // {
    //     GameObject[] pre_hanteis = GameObject.FindGameObjectsWithTag("hantei");
    //     foreach (GameObject hantei_end in pre_hanteis)
    //     {
    //         Destroy(hantei_end);
    //     }
    // }
    //判定の文字を生成する関数
    void hantei_text_excellent()
    {
        GameObject excellent1 = Instantiate(excellent_prefab);
        GameObject excellent2 = Instantiate(excellent_prefab);
        excellent1.transform.localPosition = hantei_syokiiti_right;
        excellent2.transform.Rotate(0, 0, -90, Space.World);
        excellent2.transform.localPosition = hantei_syokiiti_under;

    }

    void hantei_text_nice()
    {
        GameObject nice1 = Instantiate(nice_prefab);
        GameObject nice2 = Instantiate(nice_prefab);
        nice1.transform.localPosition = hantei_syokiiti_right;
        nice2.transform.Rotate(0, 0, -90, Space.World);
        nice2.transform.localPosition = hantei_syokiiti_under;

    }
    void hantei_text_bad()
    {
        GameObject bad1 = Instantiate(bad_prefab);
        GameObject bad2 = Instantiate(bad_prefab);
        bad1.transform.localPosition = hantei_syokiiti_right;
        bad2.transform.Rotate(0, 0, -90, Space.World);
        bad2.transform.localPosition = hantei_syokiiti_under;

    }
    void hantei_text_miss()
    {
        GameObject miss1 = Instantiate(miss_prefab);
        GameObject miss2 = Instantiate(miss_prefab);
        miss1.transform.localPosition = hantei_syokiiti_right;
        miss2.transform.Rotate(0, 0, -90, Space.World);
        miss2.transform.localPosition = hantei_syokiiti_under;

    }

    void Start()
    {
        starefect = Square_efect_star.GetComponent<Square_efect_star>();
    }

    // Update is called once per frame
    void Update()
    {
        //現在の三角の位置を取得spotstate
        Vector3 posi = triangle.transform.localPosition;
        //左上
        if (posi.x <= 0 && posi.y > 0)
        {
            spotstate = 1;
            if (rismstate == 4)
            {
                rismstate = 1;
                evaluation = 0;//miss
                Debug.Log("miss");
                misscount++;
                if (tension >= -miss_point)
                {
                    tension += miss_point;
                }
                else if (tension < -miss_point)
                {
                    tension = 0;
                }
                this.hantei_text_miss();
            }
            if (switch4to1)
            {
                GameObject[] flowers = GameObject.FindGameObjectsWithTag("flower");
                foreach (GameObject flower_end in flowers)
                {
                    Destroy(flower_end);
                }
                switch4to1 = false;
            }
        }
        //右上
        if (posi.x > 0 && posi.y > 0)
        {
            spotstate = 2;
            if (rismstate == 1)
            {
                rismstate = 2;
                evaluation = 0;//miss
                Debug.Log("miss");
                misscount++;
                if (tension >= -miss_point)
                {
                    tension += miss_point;
                }
                else if (tension < -miss_point)
                {
                    tension = 0;
                }
                this.hantei_text_miss();
            }
        }
        //右下
        if (posi.x > 0 && posi.y <= 0)
        {
            spotstate = 3;
            if (rismstate == 2)
            {
                rismstate = 3;
                evaluation = 0;//miss
                Debug.Log("miss");
                misscount++;
                if (tension >= -miss_point)
                {
                    tension += miss_point;
                }
                else if (tension < -miss_point)
                {
                    tension = 0;
                }
                this.hantei_text_miss();
            }
        }
        //左下
        if (posi.x < 0 && posi.y <= 0)
        {
            spotstate = 4;
            if (rismstate == 3)
            {
                rismstate = 4;
                evaluation = 0;//miss
                Debug.Log("miss");
                misscount++;
                if (tension >= -miss_point)
                {
                    tension += miss_point;
                }
                else if (tension < -miss_point)
                {
                    tension = 0;
                }
                this.hantei_text_miss();
            }
            if (!switch4to1)
            {
                switch4to1 = true;
            }
        }
        //これで一周完成


        //タップ入力があった時
        if (Input.GetMouseButton(0))
        {
            //左上
            if (spotstate == 1 && rismstate == 1)
            {
                rismstate = 2;
                if (posi.x < -1.0 && posi.y > 0.9)
                {
                    evaluation = 1;//excellent
                    Debug.Log("excellent");
                    excellentcount++;
                    sound.PlayOneShot(excelent_sound);
                    starefect.videoplay(spotstate);//星エフェクト
                    tension += excelent_point;
                    this.hantei_text_excellent();
                }
                else if (posi.x < -0.5 && posi.y > 0.5)
                {
                    evaluation = 2;//good
                    Debug.Log("good");
                    nicecount++;
                    sound.PlayOneShot(good_sound);
                    tension += good_point;
                    this.hantei_text_nice();
                }
                else
                {
                    evaluation = 3;//bad
                    Debug.Log("bad");
                    badcount++;
                    sound.PlayOneShot(bad_sound);
                    if (tension >= -bad_point)
                    {
                        tension += bad_point;
                    }
                    else if (tension < -bad_point)
                    {
                        tension = 0;
                    }
                    this.hantei_text_bad();
                }

                Vector3 worldposi = sikaku.transform.TransformPoint(posi); //ローカル座標からワールド座標に変換
                GameObject flower = Instantiate(flower_prefab);
                // flower.transform.localPosition = new Vector3(worldposi.x, worldposi.y, 5.0f);
                flower.transform.position = worldposi + new Vector3(0, 0, 2.0f);


            }

            //右上
            if (spotstate == 2 && rismstate == 2)
            {
                rismstate = 3;
                if (posi.x > 1.0 && posi.y > 0.9)
                {
                    evaluation = 1;//excellent
                    Debug.Log("excellent");
                    excellentcount++;
                    sound.PlayOneShot(excelent_sound);
                    starefect.videoplay(spotstate);//星エフェクト
                    tension += excelent_point;
                    this.hantei_text_excellent();
                }
                else if (posi.x > 0.5 && posi.y > 0.5)
                {
                    evaluation = 2;//good
                    Debug.Log("good");
                    nicecount++;
                    sound.PlayOneShot(good_sound);
                    tension += good_point;
                    this.hantei_text_nice();
                }
                else
                {
                    evaluation = 3;//bad
                    Debug.Log("bad");
                    badcount++;
                    sound.PlayOneShot(bad_sound);
                    if (tension >= -bad_point)
                    {
                        tension += bad_point;
                    }

                    else if (tension < -bad_point)
                    {
                        tension = 0;
                    }
                    this.hantei_text_bad();
                }

                Vector3 worldposi = sikaku.transform.TransformPoint(posi); //ローカル座標からワールド座標に変換
                GameObject flower = Instantiate(flower_prefab);
                flower.transform.position = worldposi + new Vector3(0, 0, 2.0f);


            }

            //右下
            if (spotstate == 3 && rismstate == 3)
            {
                rismstate = 4;
                if (posi.x > 0.9 && posi.y < -1.0)
                {
                    evaluation = 1;//excellent
                    Debug.Log("excellent");
                    excellentcount++;
                    sound.PlayOneShot(excelent_sound);
                    starefect.videoplay(spotstate);//星エフェクト
                    tension += excelent_point;
                    this.hantei_text_excellent();
                }
                else if (posi.x > 0.5 && posi.y < -0.5)
                {
                    evaluation = 2;//good
                    Debug.Log("good");
                    nicecount++;
                    sound.PlayOneShot(good_sound);
                    tension += good_point;
                    this.hantei_text_nice();
                }
                else
                {
                    evaluation = 3;//bad
                    Debug.Log("bad");
                    badcount++;
                    sound.PlayOneShot(bad_sound);
                    if (tension >= -bad_point)
                    {
                        tension += bad_point;
                    }
                    else if (tension < -bad_point)
                    {
                        tension = 0;
                    }
                    this.hantei_text_bad();
                }

                Vector3 worldposi = sikaku.transform.TransformPoint(posi); //ローカル座標からワールド座標に変換
                GameObject flower = Instantiate(flower_prefab);
                flower.transform.position = worldposi + new Vector3(0, 0, 2.0f);

            }

            //左下
            if (spotstate == 4 && rismstate == 4)
            {
                rismstate = 1;
                if (posi.x < -1.0 && posi.y < -1.0)
                {
                    evaluation = 1;//excellent
                    Debug.Log("excellent");
                    excellentcount++;
                    sound.PlayOneShot(excelent_sound);
                    starefect.videoplay(spotstate);//星エフェクト
                    tension += excelent_point;
                    this.hantei_text_excellent();
                }
                else if (posi.x < -0.5 && posi.y < -0.5)
                {
                    evaluation = 2;//good
                    Debug.Log("good");
                    nicecount++;
                    sound.PlayOneShot(good_sound);
                    tension += good_point;
                    this.hantei_text_nice();
                }
                else
                {
                    evaluation = 3;//bad
                    Debug.Log("bad");
                    badcount++;
                    sound.PlayOneShot(bad_sound);
                    if (tension >= -bad_point)
                    {
                        tension += bad_point;
                    }
                    else if (tension < -bad_point)
                    {
                        tension = 0;
                    }
                    this.hantei_text_bad();
                }

                Vector3 worldposi = sikaku.transform.TransformPoint(posi); //ローカル座標からワールド座標に変換
                GameObject flower = Instantiate(flower_prefab);
                flower.transform.position = worldposi + new Vector3(0, 0, 2.0f);

            }
        }
    }
}
