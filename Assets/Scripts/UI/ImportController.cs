using System.IO;
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
        bool hasFailed = false;

        hasFailed = (filePathText.text == string.Empty);

        if (!hasFailed)
        {
            try
            {
                string file = File.ReadAllText(filePathText.text);

                hasFailed = string.IsNullOrWhiteSpace(file);

                if (!hasFailed)
                {
                    string[] rows = file.Split('\n');

                    foreach (string row in rows)
                    {
                        string patientName = row.Split(',')[0];

                        Debug.Log("Patient: " + patientName);

                        UIController.Instance.CreateNewPatient(patientName);
                    }
                }
            }
            catch
            {
                hasFailed = true;
            }
        }

        if (hasFailed)
        {
            UIController.Instance.ShowWarningMessage("No file found, file is empty, or file was not supported.");
        }

        ClosePanel();
    }
}
