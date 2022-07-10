using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public abstract class ScrollViewController_OBSOLETE : MonoBehaviour
{
    public GameObject ButtonPrefab;
    private float buttonPrefabHeight;

    public ScreenController ScreenController;
    public GameObject NextScreen;

    protected GameObject content;
    /// <summary>
    /// Unused for now
    /// </summary>
    protected List<GameObject> buttons;

    public virtual void Start()
    {
        buttonPrefabHeight = ButtonPrefab.GetComponent<RectTransform>().rect.height;
    }

    /*public void Update()
    {
        // For some reason, putting it in update does sometihing totally different
        //for (int i = 0; i < buttons.Count; i++)
        //    buttons[i].transform.position = GetPosition(i);
    }*/

    protected Vector3 GetPosition(int index)
    {
        //Rect buttonRect = ButtonPrefab.GetComponent<RectTransform>().rect;
        Vector3 position = new Vector3(content.transform.position.x, content.transform.position.y - 64);
        Debug.Log($"DEBUG - 22 | content: {content.transform.position.x}, {content.transform.position}");
        Debug.Log($"DEBUG - 22 | position: {position.x}, {position.y}");
        return position;
    }

    protected virtual string NameButton(int i)
    {
        return $"Button{i + 1}";
    }

    public void Init<T>(T[] array, Func<T, string> buttonText, Func<T, UnityAction> listener)
    {
        content = transform.Find("Viewport").Find("Content").gameObject;
        // Set the correct heigth to contain all the buttons
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, buttonPrefabHeight * array.Length);
        buttons = new List<GameObject>();

        for (int i = 0; i < array.Length; i++)
        {
            // Create a new button, child from the content object, at the correct position
            GameObject newButton = Instantiate(ButtonPrefab, GetPosition(i), Quaternion.identity, content.transform);
            newButton.name = NameButton(i);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = buttonText(array[i]);
            Button newButtonComponent = newButton.GetComponent<Button>();
            // Add all the actions for this button
            newButtonComponent.onClick.AddListener(listener(array[i]));
            buttons.Add(newButton);
        }
    }
}
