using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGoldObserver
{
    void OnNotifyGold();
    void AddGoldSubject(IGoldSubject subject);
    void RemoveGoldSubject(IGoldSubject subject);
}
