using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<Day> days;
    [SerializeField] private PatientsList patientsWaitList;


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
}
