using TMPro;
using UnityEngine;


public class Patient : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text patientName;
    [SerializeField] private TMP_Text patientIDText;
    [SerializeField] private TMP_Text patientCounterText;
    [SerializeField] private GameObject counterUpButton;
    [SerializeField] private GameObject counterDownButton;
    [SerializeField] private int counterLimit = 7;

    public PatientsList ParentList { get; set; }
    public int PatientId { get; private set; } = -1;
    public int Count { get; private set; } = 1;


    public string GetPatientName() { return patientName.text; }
    public void SetPatientName(string PatientName) { patientName.text = PatientName; }

    public void SetPatientID(int ID)
    {
        PatientId = ID;
        patientIDText.text = ID.ToString();
    }

    public void SetCounter(int NewCount)
    {
        if (Count == NewCount || NewCount > counterLimit || NewCount < 1) return;

        while (NewCount < Count) DecrementCounter();

        while (NewCount > Count) IncrementCounter();
    }

    public void IncrementCounter()
    {
        if (Count + 1 > counterLimit) return;

        Count++;
        patientCounterText.SetText(Count.ToString());

        if (Count + 1 > counterLimit)
            counterUpButton.SetActive(false);

        if (Count > 1) counterDownButton.SetActive(true);
    }

    public void DecrementCounter()
    {
        if (Count - 1 < 1) return;

        Count--;
        patientCounterText.SetText(Count.ToString());

        if (Count - 1 < 1)
            counterDownButton.SetActive(false);

        if (Count < counterLimit) counterUpButton.SetActive(true);
    }
}
