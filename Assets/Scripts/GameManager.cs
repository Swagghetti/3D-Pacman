using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private GameObject _ghost;

    [SerializeField] private GameObject _ghostPrefab;
    [SerializeField] private TextMeshProUGUI _countDownText;

    private List<GameObject> _enemies;
    private float _refreshDuration = 5.3f;
    private float _refreshTimer = 0.0f;

    void Start()
    {
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

        _countDownText.text = (_refreshDuration - _refreshTimer).ToString("F2");
    }


    private void CreateGhost()
    {
        _ghost = Instantiate(_ghostPrefab, _player.transform.position, Quaternion.identity);
        _ghost.GetComponent<Renderer>().material.DOFade(0.0f, _refreshDuration);
        Destroy(_ghost, _refreshDuration);
    }
}
