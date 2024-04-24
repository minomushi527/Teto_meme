using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainAudio : MonoBehaviour
{
    AudioSource mainAudio;
    private float time;
    public GameObject tapopr;
    private Tap_operation opr;
    // public Tap_operation opr;
    // //miss,bad,nice,excellentの数を数える
    // public int misscount = 0;
    // public int badcount = 0;
    // public int nicecount = 0;
    // public int excellentcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        mainAudio = this.gameObject.GetComponent<AudioSource>();
        mainAudio.Play();
        opr = tapopr.GetComponent<Tap_operation>();
        // GetComponent<MainAudio>().enabled = false;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         mainAudio.Play();
    //         GetComponent<MainAudio>().enabled = false;
    //     }
    // }
    void Update()
    {
        time += Time.deltaTime;
        if (time > 98.0 && time < 98.3)
        {
            // 値を保存する
            PlayerPrefs.SetInt("miss", opr.misscount);
            PlayerPrefs.SetInt("bad", opr.badcount);
            PlayerPrefs.SetInt("nice", opr.nicecount);
            PlayerPrefs.SetInt("excellent", opr.excellentcount);
            PlayerPrefs.SetInt("score", opr.tension);
            PlayerPrefs.Save();

            SceneManager.LoadScene("Finish");
        }
    }
}
