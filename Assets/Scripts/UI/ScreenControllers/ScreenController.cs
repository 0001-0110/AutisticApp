using UnityEngine;

public abstract class ScreenController : MonoBehaviour
{
    public virtual void OpenScreen(GameObject screen)
    {
        screen.SetActive(true);
        gameObject.SetActive(false);
    }
}
