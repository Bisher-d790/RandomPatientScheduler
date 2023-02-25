using TMPro;
using UnityEngine;

public class ErrorMessage : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text messageText;


    public void Close()
    {
        Destroy(gameObject);
    }

    public void SetTitleAndMessage(string title, string message)
    {
        titleText.text = title;
        messageText.text = message;
    }
}
