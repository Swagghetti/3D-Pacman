using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, ILoseSubject
{
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] public bool isOnLink;
    private GameManager _gameManager;
    private UIManager _uiManager;
    private GameObject _player;
    private List<ILoseObserver> _observers = new List<ILoseObserver>();

    void Update()
    {
        isOnLink = agent.isOnOffMeshLink;
    }

    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        _player = GameObject.FindGameObjectWithTag("Player");

        agent.SetDestination(_player.transform.position);

        AddObserver(_uiManager);
        AddObserver(_gameManager);
    }

    public void SetTarget(Transform target)
    {
        agent.SetDestination(target.position);
    }

    public void SetTargetAsPlayer()
    {
        agent.SetDestination(_player.transform.position);
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NotifyObservers();
        }
    }

    public void AddObserver(ILoseObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(ILoseObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.OnNotifyLose();
        }
    }
}
