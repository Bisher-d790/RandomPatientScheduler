using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Patient : MonoBehaviour
{
    [SerializeField] private TMP_Text patientName;


    public string GetPatientName() { return patientName.text; }
    public void SetPatientName(string PatientName) { patientName.text = PatientName; }
}
