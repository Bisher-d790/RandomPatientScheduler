using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ImportController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_InputField filePathText;

    public void OpenPanel()
    {
        gameObject.SetActive(true);

        ResetPanel();
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    protected void ResetPanel()
    {
        filePathText.text = string.Empty;
    }

    public void ImportPatientsFromFile()
    {
        ClosePanel();
    }
}
