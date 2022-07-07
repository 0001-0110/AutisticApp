using System.Threading.Tasks;
using UnityEngine;

public class LogoScreenController : ScreenController
{
    public GameObject NextScreen;
    /// <summary>
    /// The delay before opening the next screen (in ms)
    /// </summary>
    public int Delay;

    public void OnEnable()
    {
        OpenScreenAsync(NextScreen, Delay);
    }

    protected async void OpenScreenAsync(GameObject screen, int delay = 2000)
    {
        await Task.Delay(delay);
        OpenScreen(screen);
    }
}
