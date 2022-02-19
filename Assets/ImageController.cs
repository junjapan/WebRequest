using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HttpConnect());
    }

    IEnumerator HttpConnect()
    {
        string url = "https://joytas.net/php/man.jpg";
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
        yield return uwr.SendWebRequest();
        if(uwr.isHttpError|| uwr.isNetworkError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            Texture texture = DownloadHandlerTexture.GetContent(uwr);

            //spriteは中心の概念（アンカー）がある。canvasはスプライトなので。
            Sprite sp = Sprite.Create(
                (Texture2D)texture,
                //元々のtextureのどの部分を使うか
                new Rect(0,0,texture.width,texture.height),
                //真ん中を示す。ピボット。
                new Vector2(0.5f,0.5f)
                );

            sp.name = "man";

            Image image = GetComponent<Image>();

            image.rectTransform.sizeDelta = new Vector2(texture.width,texture.height);

            image.sprite = sp;
        }
    }

}
