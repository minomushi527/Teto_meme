using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreMove : MonoBehaviour
{
    //ゲームオブジェクト
    public GameObject miss;
    public GameObject bad;
    public GameObject nice;
    public GameObject excellent;
    public GameObject score;
    public GameObject touch;

    // //テキスト
    // private Text misstext;
    // private Text badtext;
    // private Text nicetext;
    // private Text excellenttext;

    //ポイントの定義
    private int miss_point;
    private int bad_point;
    private int nice_point;
    private int excellent_point;
    private int score_point;
    private int score_display = 0;

    //音
    public AudioSource sound;
    public AudioClip excelent_sound;//excelent
    public AudioClip good_sound;//good

    //その他変数
    private int state = 0;//missから順に
    public float speed = 50f; // 移動速度
    private Vector3 objectPosition;

    // Start is called before the first frame update
    private void Start()
    {
        //mainシーンで保存していたスコア
        miss_point = PlayerPrefs.GetInt("miss", 0);
        bad_point = PlayerPrefs.GetInt("bad", 0);
        nice_point = PlayerPrefs.GetInt("nice", 0);
        excellent_point = PlayerPrefs.GetInt("excellent", 0);
        score_point = PlayerPrefs.GetInt("score", 0);

        //スコアを文字に代入
        miss.GetComponent<TextMeshProUGUI>().text = "miss ....... " + miss_point.ToString();
        bad.GetComponent<TextMeshProUGUI>().text = "bad ....... " + bad_point.ToString();
        nice.GetComponent<TextMeshProUGUI>().text = "nice ....... " + nice_point.ToString();
        excellent.GetComponent<TextMeshProUGUI>().text = "excellent ....... " + excellent_point.ToString();

        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        //miss
        if (state == 0)
        {
            miss.transform.Translate(speed * Time.deltaTime, 0f, 0f, Space.Self);
            objectPosition = miss.transform.position;
            if (objectPosition.x > 485)
            {
                sound.PlayOneShot(good_sound);
                state = 1;
            }
        }

        //bad
        else if (state == 1)
        {
            bad.transform.Translate(speed * Time.deltaTime, 0f, 0f, Space.Self);
            objectPosition = bad.transform.position;
            if (objectPosition.x > 551)
            {
                sound.PlayOneShot(good_sound);
                state = 2;
            }
        }

        //nice
        else if (state == 2)
        {
            nice.transform.Translate(speed * Time.deltaTime, 0f, 0f, Space.Self);
            objectPosition = nice.transform.position;
            if (objectPosition.x > 568)
            {
                sound.PlayOneShot(good_sound);
                state = 3;
            }
        }

        //excellent
        else if (state == 3)
        {
            excellent.transform.Translate(speed * Time.deltaTime, 0f, 0f, Space.Self);
            objectPosition = excellent.transform.position;
            if (objectPosition.x > 587)
            {
                sound.PlayOneShot(excelent_sound);
                state = 4;
            }
        }
        else if (state == 4)
        {
            if (score_display < score_point)
            {
                score.GetComponent<TextMeshProUGUI>().text = "総得点 " + score_display.ToString();
                score_display++;
            }
            else
            {
                state = 5;
            }
        }
        else if (state == 5)
        {
            touch.GetComponent<TextMeshProUGUI>().text = "画面をタップで戻る";
            state = 6;
        }
        else if (state == 6)
        {
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("Start");
            }
        }
    }
}

//自動車免許受かった？