using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientsList : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform listTransform;

    [Header("UI")]
    [SerializeField] private float patientsYspaceInBetween = 10.0f;

    private List<Patient> patients = new List<Patient>();


    public void AddPatientToList(Patient patient)
    {
        float lastPatientYPos = -(((RectTransform)patient.transform).rect.height + patientsYspaceInBetween) * listTransform.childCount;

        // Space for the first item
        lastPatientYPos -= ((RectTransform)patient.transform).rect.height;

        patient.transform.SetParent(listTransform);
        patient.transform.localPosition = new Vector2(0, lastPatientYPos);

        patients.Add(patient);
        patient.ParentList = this;
    }
    public void RemovePatientFromList(Patient patient)
    {
        patient.transform.SetParent(transform.parent);

        patients.Remove(patient);
        patient.ParentList = null;
    }

    public bool ContainsPatient(Patient patient)
    {
        return patients.Contains(patient);
    }

    public IEnumerator<Patient> GetEnumerator() { return patients.GetEnumerator(); }
}
