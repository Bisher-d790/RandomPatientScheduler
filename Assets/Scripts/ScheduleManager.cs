using System.Collections.Generic;
using UnityEngine;


public class ScheduleManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Patient patientPrefab;
    [SerializeField] private List<Day> days;
    [SerializeField] private PatientsList patientsWaitList;
    [SerializeField] private int patientInitialCount = 2;

    public static int LastUsedID = -1;

    #region Singleton
    static private ScheduleManager instance = null;
    static public ScheduleManager Instance
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


    public void CreateNewPatient(string NewPatientName)
    {
        if (!patientPrefab || string.IsNullOrWhiteSpace(NewPatientName))
        {
            UIController.Instance.ShowWarningMessage("Error:", "Input field \"New Patient Name\" is empty!");
            return;
        }

        Patient newPatient = Instantiate(patientPrefab);
        newPatient.SetPatientName(NewPatientName);
        newPatient.SetPatientID(++LastUsedID);
        newPatient.SetCounter(patientInitialCount);

        AddNewPatient(newPatient);
    }

    public void AddNewPatient(Patient patient)
    {
        patientsWaitList.AddPatientToList(patient);
    }

    public void MovePatientToDay(Patient patient, Days dayType)
    {
        foreach (Day day in days)
        {
            if (day.day == dayType)
            {
                day.AddPatientToList(patient);
            }
        }
    }

    public void MovePatientToList(Patient patient, PatientsList targetList)
    {
        if (patient == null || targetList.ContainsPatient(patient)) return;

        patient.ParentList.RemovePatientFromList(patient);
        targetList.AddPatientToList(patient);
    }

    public void ScheduleWaitingPatients()
    {
        foreach (Patient patient in patientsWaitList)
        {
            if (patient.Count > 1)
            {
                for (int i = 1; i < patient.Count; i++)
                {
                    Patient patientInstance = Instantiate(patient);
                    SchedulePatientRandomly(patientInstance);
                }
            }

            SchedulePatientRandomly(patient);
        }
    }

    private void SchedulePatientRandomly(Patient patient)
    {
        if (patient == null && days.Count > 0) return;

        int randomDayIndex = 0;
        do
        {
            randomDayIndex = Random.Range(0, days.Count);
        }
        while (!days[randomDayIndex].CheckCanAddPatient(patient) && GetFirstAvailableFreeSlot(patient));

        if (days[randomDayIndex].CheckCanAddPatient(patient))
        {
            MovePatientToDay(patient, days[randomDayIndex].day);
        }

        patient.SetCounterActive(false);
    }

    private Day GetFirstAvailableFreeSlot(Patient patient)
    {
        foreach (Day day in days)
        {
            if (day.CheckCanAddPatient(patient))
                return day;
        }

        return null;
    }

    public void ClearAllPatients()
    {
        patientsWaitList.DeleteAllPatients();

        foreach (Day day in days)
        {
            day.DeleteAllPatients();
        }

        LastUsedID = -1;
    }
}
