using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour, ILoseObserver, IGoldObserver
{
    List<IGoldSubject> _goldSubjects;
    List<ILoseSubject> _loseSubjects;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _goldText;

    void Start()
    {
        _goldSubjects = new List<IGoldSubject>();
        _loseSubjects = new List<ILoseSubject>();

        _goldText.text = "0";
    }

    public void SetGoldText()
    {
        _goldText.text = Convert.ToInt32(_goldText.text) + 1 + "";
    }

    public void SetTimer(float time)
    {
        _timerText.text = time.ToString("F2");
    }

    public void AddGoldSubject(IGoldSubject subject)
    {
        _goldSubjects.Add(subject);
    }

    public void AddLoseSubject(ILoseSubject subject)
    {
        _loseSubjects.Add(subject);
    }

    public void OnNotifyGold()
    {
        SetGoldText();
    }

    public void OnNotifyLose()
    {
        Debug.LogWarning("Player has been caught");
    }

    public void RemoveLoseSubject(ILoseSubject subject)
    {
        subject.RemoveObserver(this);
        _loseSubjects.Remove(subject);
    }

    public void RemoveGoldSubject(IGoldSubject subject)
    {
        subject.RemoveObserver(this);
        _goldSubjects.Remove(subject);
    }

}
