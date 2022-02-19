using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HttpController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HttpConnect());
    }
    IEnumerator HttpConnect()
    {
        string url = "https://joytas.net/php/hello.php";

        //2018年から出てきたクラス。uwrにget通信が出来るインスタンスを入れる。
        UnityWebRequest uwr = UnityWebRequest.Get(url);
        //以下で実際に通信処理。yield returnなので return以降も処理される。
        yield return uwr.SendWebRequest();
        //isNetworkErrorはwifiがつながらないとか。
        //isHttpErrorは、wifiつながったけど、404エラーとか。
        if (uwr.isHttpError || uwr.isNetworkError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            Debug.Log(uwr.downloadHandler.text);
        }
    }

}
