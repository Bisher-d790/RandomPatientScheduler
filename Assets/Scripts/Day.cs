using UnityEngine;
using TMPro;


public class Day : PatientsList
{
    [Header("Config")]
    public Days day;

    [SerializeField] private TMP_Text capacityText;
    [SerializeField] private int capacity = 25;


    protected void Start()
    {
        SetCapacity(capacity);
    }

    public int GetCapacity()
    {
        return capacity;
    }

    public void SetCapacity(int capacity)
    {
        if (!capacityText || capacity < 0) return;

        capacityText.text = capacity.ToString();
        this.capacity = capacity;
    }

    public void IncreamentCapacity(int increament = 1)
    {
        SetCapacity(GetCapacity() + increament);
    }

    public void DecreamentCapacity(int decreament = 1)
    {
        SetCapacity(GetCapacity() - decreament);
    }

    public bool CheckCanAddPatient(Patient patient)
    {
        return patient &&
            !ContainsPatient(patient) &&
            GetCount() < GetCapacity();
    }
}
