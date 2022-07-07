using UnityEngine;

public class AboutScreenController : ScreenController
{
    public void PlayVideo(string url)
    {
        Application.OpenURL(url);
    }
}
