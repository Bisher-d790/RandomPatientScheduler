using TMPro;
using UnityEngine;


public class Patient : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text patientName;
    [SerializeField] private TMP_Text patientIDText;

    private PatientsList parentList;
    public PatientsList ParentList { get { return parentList; } set { parentList = value; } }

    private int patientID = -1;
    public int PatientID { get { return patientID; } }

    public string GetPatientName() { return patientName.text; }
    public void SetPatientName(string PatientName) { patientName.text = PatientName; }

    public void SetPatientID(int ID)
    {
        patientID = ID;
        patientIDText.text = ID.ToString();
    }
}
