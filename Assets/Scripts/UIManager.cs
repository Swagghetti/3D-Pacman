using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, ILoseObserver, IGoldObserver
{
    List<IGoldSubject> _goldSubjects;
    List<ILoseSubject> _loseSubjects;

    public void AddGoldSubject(IGoldSubject subject)
    {
        subject.AddObserver(this);
        _goldSubjects.Add(subject);
    }

    public void AddLoseSubject(ILoseSubject subject)
    {
        subject.AddObserver(this);
        _loseSubjects.Add(subject);
    }

    public void OnNotifyGold()
    {
        Debug.Log("Gold has been updated");
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

    // Start is called before the first frame update
    void Start()
    {
        _goldSubjects = new List<IGoldSubject>();
        _loseSubjects = new List<ILoseSubject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
