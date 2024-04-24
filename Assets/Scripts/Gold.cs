using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour, IGoldSubject
{
    private List<IGoldObserver> _goldObservers;
    private GameManager _gameManager;
    private UIManager _uiManager;
    

    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        if (_gameManager == null)
            Debug.LogError("Game Manager is NULL");

        _goldObservers = new List<IGoldObserver>();

        StartCoroutine(AddObserverCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AddObserverCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        AddObserver(_gameManager);
        AddObserver(_uiManager);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NotifyObservers();
            Destroy(gameObject);
        }
    }

    public void AddObserver(IGoldObserver observer)
    {
        if (observer == null)
            Debug.LogError("Observer is NULL");

        _goldObservers.Add(observer);
        observer.AddGoldSubject(this);
    }

    public void RemoveObserver(IGoldObserver observer)
    {
        _goldObservers.Remove(observer);
        observer.RemoveGoldSubject(this);
    }

    public void NotifyObservers()
    {
        foreach (IGoldObserver observer in _goldObservers)
        {
            observer.OnNotifyGold();
        }
    }
}
