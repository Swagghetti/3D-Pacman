using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using DG.Tweening;

public class GameManager : MonoBehaviour, IGoldObserver, ILoseObserver
{
    private GameObject _player;
    private GameObject _ghost;

    private List<IGoldSubject> _goldSubjects;
    private List<ILoseSubject> _loseSubjects;

    [SerializeField] private GameObject _ghostPrefab;
    [SerializeField] private TextMeshProUGUI _countDownText;
    [SerializeField] private UIManager _uiManager;

    private List<GameObject> _enemies;
    private float _refreshDuration = 5.3f;
    private float _refreshTimer = 0.0f;
    [SerializeField] private int _gold = 0;

    void Start()
    {
        _goldSubjects = new List<IGoldSubject>();
        _loseSubjects = new List<ILoseSubject>();
        _enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        _player = GameObject.FindGameObjectWithTag("Player");

        CreateGhost();
    }

    // Update is called once per frame
    void Update()
    {
        _refreshTimer += Time.deltaTime;
        if (_refreshTimer > _refreshDuration)
        {
            foreach (GameObject enemy in _enemies)
            {
                enemy.GetComponent<EnemyController>().SetTarget(_player.transform);
            }
            _refreshTimer = 0.0f;
            
            CreateGhost();
        }

        _uiManager.SetTimer(_refreshDuration - _refreshTimer);
    }


    private void CreateGhost()
    {
        _ghost = Instantiate(_ghostPrefab, _player.transform.position, Quaternion.identity);
        _ghost.GetComponent<Renderer>().material.DOFade(0.0f, _refreshDuration);
        Destroy(_ghost, _refreshDuration);
    }

    public void OnNotifyGold()
    {
        _gold++;
    }

    public void AddGoldSubject(IGoldSubject subject)
    {
        if (_goldSubjects == null)
            Debug.LogError("List is NULL");

        _goldSubjects.Add(subject);
    }

    public void RemoveGoldSubject(IGoldSubject subject)
    {
        _goldSubjects.Remove(subject);
    }

    public void OnNotifyLose()
    {
        throw new System.NotImplementedException();
    }

    public void AddLoseSubject(ILoseSubject subject)
    {
        _loseSubjects.Add(subject);
    }

    public void RemoveLoseSubject(ILoseSubject subject)
    {
        _loseSubjects.Remove(subject);
    }
}
