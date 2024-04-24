using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, ILoseObserver, IGoldObserver
{
    List<IGoldSubject> _goldSubjects;
    List<ILoseSubject> _loseSubjects;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private GameObject _panel; 

    void Start()
    {
        _goldSubjects = new List<IGoldSubject>();
        _loseSubjects = new List<ILoseSubject>();

        _goldText.text = "0";

        SetHighScoreText();
    }

    public void SetGoldText()
    {
        _goldText.text = Convert.ToInt32(_goldText.text) + 1 + "";
    }

    public void SetHighScoreText()
    {
        _highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
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
        _panel.SetActive(true);
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
