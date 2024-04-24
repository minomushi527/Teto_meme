using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundChange : MonoBehaviour
{
    public Sprite newSprite;
    private Image image;

    void Start()
    {
        // SpriteRendererコンポーネントを取得します
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // 画像を切り替えます
            image.sprite = newSprite;
        }
    }
}
