using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hantei_move : MonoBehaviour
{
    private float speed1 = 20.0f;
    private float speed2 = 40.0f;
    private float time = 0.0f;
    private bool type = true;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 posi = this.transform.localPosition;
        if (posi.y < -6)
        {
            type = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posi = this.transform.localPosition;
        if (type)//右から左へ
        {
            //右から中心へ
<<<<<<< HEAD
            if (posi.x > -6)
            {
                transform.Translate(-speed1 * Time.deltaTime * 3, 0f, 0f, Space.Self);
=======
            if (posi.x > -1.2)
            {
                transform.Translate(-speed1 * Time.deltaTime, 0f, 0f, Space.Self);
>>>>>>> 959dbc3f8bdddeee1e355568b49c42f53bcc2db2

            }
            //中心でピタっ
            else if (time < 0.5f)
            {
                time += Time.deltaTime;
            }
            //中心から左へ
            else
            {
<<<<<<< HEAD
                transform.Translate(-speed1 * Time.deltaTime * 3, 0f, 0f, Space.Self);
=======
                transform.Translate(-speed1 * Time.deltaTime, 0f, 0f, Space.Self);
>>>>>>> 959dbc3f8bdddeee1e355568b49c42f53bcc2db2
            }

            //消去
            if (posi.x < -8)
            {
                Destroy(this.gameObject);
            }
        }
        else //下から上へ
        {

<<<<<<< HEAD
            if (posi.y < 0)
            {
                transform.Translate(-speed2 * Time.deltaTime * 2, 0f, 0f, Space.Self);
=======
            if (posi.y < 4)
            {
                transform.Translate(-speed2 * Time.deltaTime, 0f, 0f, Space.Self);
>>>>>>> 959dbc3f8bdddeee1e355568b49c42f53bcc2db2

            }
            //中心でピタっ
            else if (time < 0.5f)
            {
                time += Time.deltaTime;
            }
            //中心から左へ
            else
            {
<<<<<<< HEAD
                transform.Translate(-speed2 * Time.deltaTime * 2, 0f, 0f, Space.Self);
=======
                transform.Translate(-speed2 * Time.deltaTime, 0f, 0f, Space.Self);
>>>>>>> 959dbc3f8bdddeee1e355568b49c42f53bcc2db2
            }

            //消去
            if (posi.y > 8)
            {
                Destroy(this.gameObject);
            }
        }
    }
}