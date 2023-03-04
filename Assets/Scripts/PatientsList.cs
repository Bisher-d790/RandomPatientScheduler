using System.Collections.Generic;
using UnityEngine;


public class PatientsList : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform listTransform;

    private List<Patient> patients = new List<Patient>();


    public void AddPatientToList(Patient patient)
    {
        float lastPatientYPos = -(((RectTransform)patient.transform).rect.height) * listTransform.childCount;

        patient.transform.SetParent(listTransform);
        patient.transform.localPosition = new Vector2(0, lastPatientYPos);
        patient.transform.localScale = Vector2.one;

        patients.Add(patient);
        patient.ParentList = this;

        RefreshContainerListSize();
    }

    public void RemovePatientFromList(Patient patient)
    {
        patient.transform.SetParent(transform.parent);

        patients.Remove(patient);
        patient.ParentList = null;

        RefreshContainerListSize();
    }

    public bool ContainsPatient(Patient patient)
    {
        return (patients.Contains(patient) || patients.Exists(
            (patientToCheck) => patientToCheck.PatientId == patient.PatientId));
    }

    private void RefreshContainerListSize()
    {
        if (patients.Count <= 0) return;

        // Get the last patient inside the list
        RectTransform lastPatient = (RectTransform)patients[patients.Count - 1].transform;

        if (!lastPatient) return;

        // Get the last patients pos and add the height
        float height = lastPatient.rect.height + Mathf.Abs(lastPatient.localPosition.y);

        // Resize the list
        listTransform.sizeDelta = new Vector2(listTransform.sizeDelta.x, height);
    }

    public IEnumerator<Patient> GetEnumerator() { return patients.GetEnumerator(); }

    public int GetCount() { return patients.Count; }

    public void DeleteAllPatients()
    {
        for (int i = patients.Count - 1; i >= 0; i--)
        {
            Patient patient = patients[i];

            if (!patient) continue;

            RemovePatientFromList(patient);

            Destroy(patient.gameObject);
        }

        RefreshContainerListSize();
    }
}
