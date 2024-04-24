using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoseSubject
{
    void AddObserver(ILoseObserver observer);
    void RemoveObserver(ILoseObserver observer);
    void NotifyObservers();
}
