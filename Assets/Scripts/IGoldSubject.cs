using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGoldSubject
{
    void AddObserver(IGoldObserver observer);
    void RemoveObserver(IGoldObserver observer);
    void NotifyObservers();
}
