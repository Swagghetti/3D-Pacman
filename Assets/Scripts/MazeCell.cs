using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] GameObject _centerBlock;
    [SerializeField] GameObject _topWall;
    [SerializeField] GameObject _bottomWall;
    [SerializeField] GameObject _leftWall;
    [SerializeField] GameObject _rightWall;

    public bool isVisited = false;
    

    public void Visit()
    {
        isVisited = true;
        _centerBlock.SetActive(false);
    }

    public void ClearLeftWall()
    {
        _leftWall.SetActive(false);
    }
    
    public void ClearRightWall()
    {
        _leftWall.SetActive(false);
    }

    public void ClearTopWall()
    {
        _topWall.SetActive(false);
    }

    public void ClearBottomWall()
    {
        _bottomWall.SetActive(false);
    }
}
