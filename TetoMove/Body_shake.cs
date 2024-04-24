using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_shake : MonoBehaviour
{
    private bool state = true; //trueは入力受付中
    public float speed = 1f;

    public int shake = 50;
    private Vector3 syokiti;
    private float time = 0;
    //public GameObject teto;

    // Start is called before the first frame update
    void Start()
    {
        syokiti = this.transform.localPosition;
    }
    // IEnumerator WaitProcess()
    // {
    // 	yield return new WaitForSeconds(10f);
    // }
    // Update is called once per frame
    void Update()
    {
        if (state)
        {
            if (Input.GetMouseButton(0) || time != 0)
            {
                // StartCoroutine(WaitProcess());
                // state = false;
                Vector3 movement = new Vector3(0f, -0.01f * Time.deltaTime * shake, 0f);
                transform.Translate(movement);
                time += Time.deltaTime;
                if (time > 0.08)
                {
                    state = false;
                }
            }
        }
        else
        {
            if (!Input.GetMouseButton(0))
            {
                // StartCoroutine(WaitProcess());
                Vector3 movement = new Vector3(0f, 0.1f * Time.deltaTime * shake, 0f);
                transform.Translate(movement);
                if (this.transform.localPosition.y >= syokiti.y)
                {
                    //Vector3 worldposi = teto.transform.TransformPoint(syokiti); //ローカル座標からワールド座標に変換
                    this.transform.localPosition = syokiti;
                    state = true;
                    time = 0;
                }
            }
        }

    }
}
