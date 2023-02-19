using UnityEngine;
using TMPro;

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
        CreateNewPatient(NewPatientName.text);
    }

    public void CreateNewPatient(string NewPatientName)
    {
        if (!patientPrefab || string.IsNullOrWhiteSpace(NewPatientName))
        {
            ShowWarningMessage("Input field \"New Patient Name\" is empty!");
            return;
        }

        Patient newPatient = Instantiate(patientPrefab);
        newPatient.SetPatientName(NewPatientName);

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
