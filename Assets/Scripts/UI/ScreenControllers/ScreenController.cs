using UnityEngine;

public abstract class ScreenController : MonoBehaviour
{
    public void OpenScreen(GameObject screen)
    {
        screen.SetActive(true);
        gameObject.SetActive(false);
    }
}
