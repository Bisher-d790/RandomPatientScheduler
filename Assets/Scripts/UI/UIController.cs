using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;

public class UIController : MonoBehaviour
{
    [SerializeField] private ScheduleManager scheduleManager;

    [SerializeField] private RectTransform patientsList;
    [SerializeField] private List<RectTransform> daysLists;
    [SerializeField] private Patient patientPrefab;

    [SerializeField] private float patientsYspaceInBetween = 10.0f;


    public void CreateNewPatient(TMP_Text NewPatientName)
    {
        if (!patientPrefab || string.IsNullOrWhiteSpace(NewPatientName.text))
        {
            ShowWarningMessage("Input field \"New Patient Name\" is empty!");
            return;
        }

        Patient newPatient = Instantiate(patientPrefab);
        newPatient.SetPatientName(NewPatientName.text);

        scheduleManager.AddNewPatient(newPatient);
    }

    public void StartScheduling()
    {

    }

    public void MovePatientToPatientsList(Patient patient)
    {
        float lastPatientYPos = -(((RectTransform)patient.transform).rect.height + patientsYspaceInBetween) * patientsList.childCount;

        // Space for the first item
        lastPatientYPos -= ((RectTransform)patient.transform).rect.height;

        patient.transform.SetParent(patientsList);
        patient.transform.localPosition = new Vector2(0, lastPatientYPos);
    }

    public void ShowWarningMessage(string message)
    {
        Debug.LogError(message);
    }
}
