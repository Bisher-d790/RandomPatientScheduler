using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleManager : MonoBehaviour
{
    [SerializeField] private UIController uiController;

    private List<Patient> patients = new List<Patient>();

    public void AddNewPatient(Patient patient)
    {
        patients.Add(patient);

        uiController.MovePatientToPatientsList(patient);
    }
}
