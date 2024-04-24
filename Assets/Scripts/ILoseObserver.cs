using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoseObserver
{
    void OnNotifyLose();
    void AddLoseSubject(ILoseSubject subject);
    void RemoveLoseSubject(ILoseSubject subject);
}
