using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Patient : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text patientName;

    private PatientsList parentList;
    public PatientsList ParentList { get; set; }

    public string GetPatientName() { return patientName.text; }
    public void SetPatientName(string PatientName) { patientName.text = PatientName; }
}
