using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;

public class UIController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Patient patientPrefab;

    #region Singleton
    static private UIController instance = null;
    static public UIController Instance
    {
        get { return instance; }
        set
        {
            if (instance) Destroy(value);
            else instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    #endregion Singleton

    public void CreateNewPatient(TMP_Text NewPatientName)
    {
        if (!patientPrefab || string.IsNullOrWhiteSpace(NewPatientName.text))
        {
            ShowWarningMessage("Input field \"New Patient Name\" is empty!");
            return;
        }

        Patient newPatient = Instantiate(patientPrefab);
        newPatient.SetPatientName(NewPatientName.text);

        ScheduleManager.Instance.AddNewPatient(newPatient);
    }

    public void StartScheduling()
    {
        ScheduleManager.Instance.ScheduleWaitingPatients();
    }

    public void ShowWarningMessage(string message)
    {
        Debug.LogError(message);
    }
}
