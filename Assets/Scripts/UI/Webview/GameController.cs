using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : MonoBehaviour
{
    private WebViewObject webViewObject;

    /// <summary>
    /// Dark magic, do not touch
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public void InitWebView(string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ")
    {
#if UNITY_EDITOR
        Debug.LogWarning("Warning: WebView is not compatible with the editor, please use a development build");
#else
        webViewObject = GetComponent<WebViewObject>();
        webViewObject.Init();
        // TODO are these lines useful ? need some tests on IOS
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        webViewObject.bitmapRefreshCycle = 1;
#endif
        // no margins means full screen
        webViewObject.SetMargins(0, 0, 0, 0);
        webViewObject.SetTextZoom(100);     // android only. cf. https://stackoverflow.com/questions/21647641/android-webview-set-font-size-system-default/47017410#47017410
        webViewObject.SetVisibility(true);

        //DebugText.text = $"DEBUG - 22 | Trying to start coroutine";
        StartCoroutine(LoadUrl(url));
#endif
    }

    private IEnumerator LoadUrl(string url)
    {
        if (url.StartsWith("http"))
            webViewObject.LoadURL(url.Replace(" ", "%20"));
        else
        {
            var exts = new string[]
            {
                ".jpg",
                ".js",
                ".html"  // should be last
            };
            foreach (var ext in exts)
            {
                var _url = url.Replace(".html", ext);
                var src = System.IO.Path.Combine(Application.streamingAssetsPath, _url);
                var dst = System.IO.Path.Combine(Application.persistentDataPath, _url);
                byte[] result = null;
                if (src.Contains("://"))
                {
                    // for Android
                    // NOTE: a more complete code that utilizes UnityWebRequest can be found in https://github.com/gree/unity-webview/commit/2a07e82f760a8495aa3a77a23453f384869caba7#diff-4379160fa4c2a287f414c07eb10ee36d
                    var unityWebRequest = UnityWebRequest.Get(src);
                    yield return unityWebRequest.SendWebRequest();
                    result = unityWebRequest.downloadHandler.data;
                }
            }
        }
        yield break;
    }
}