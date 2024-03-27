using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _parentObject;
    [SerializeField] private GameObject _startingPoint;
    [SerializeField] private GameObject _mazeCellPrefab;

    [SerializeField] private int _mazeWidth;
    [SerializeField] private int _mazeHeight;

    private MazeCell[,] _mazeCells;

    void Start()
    {
        _mazeCells = new MazeCell[_mazeWidth, _mazeHeight];

        FillGrid();

        GenerateMaze(null, _mazeCells[0, 0]);
    }

    private void FillGrid()
    {
        for (int i = 0; i < _mazeWidth; i++)
        {
            for (int j = 0; j < _mazeHeight; j++)
            {
                GameObject mazeCell = Instantiate(_mazeCellPrefab, new Vector3(i * 5 + _startingPoint.transform.position.x, 0, -j * 5 + _startingPoint.transform.position.z), Quaternion.identity);
                mazeCell.GetComponent<MazeCell>().xIndex = i;
                mazeCell.GetComponent<MazeCell>().yIndex = j;
                mazeCell.name = "MazeCell_" + i + "_" + j;
                _mazeCells[i, j] = mazeCell.GetComponent<MazeCell>();
                mazeCell.transform.parent = _parentObject.transform;
            }
        }
    }

    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWallsInBetween(previousCell, currentCell);

        MazeCell nextCell;

        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        }
        while (nextCell != null);

        RemoveCenter();
        
    }

    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        List<MazeCell> unvisitedCells = GetUnvisitedCells(currentCell);

        if(unvisitedCells.Count > 0)
        {
            int randomIndex = Random.Range(0, unvisitedCells.Count);
            return unvisitedCells[randomIndex];
        }
        return null;
    }

    private List<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        if (currentCell == null)
        {
            return null;
        }

        List<MazeCell> unvisitedCells = new List<MazeCell>();

        if (currentCell.xIndex != 0 && !_mazeCells[currentCell.xIndex - 1, currentCell.yIndex].isVisited)
        {
            unvisitedCells.Add(_mazeCells[currentCell.xIndex - 1, currentCell.yIndex]);
        }

        if(currentCell.xIndex != _mazeWidth - 1 && !_mazeCells[currentCell.xIndex + 1, currentCell.yIndex].isVisited)
        {
            unvisitedCells.Add(_mazeCells[currentCell.xIndex + 1, currentCell.yIndex]);
        }

        if(currentCell.yIndex != 0 && !_mazeCells[currentCell.xIndex, currentCell.yIndex - 1].isVisited)
        {
            unvisitedCells.Add(_mazeCells[currentCell.xIndex, currentCell.yIndex - 1]);
        }

        if(currentCell.yIndex != _mazeHeight - 1 && !_mazeCells[currentCell.xIndex, currentCell.yIndex + 1].isVisited)
        {
            unvisitedCells.Add(_mazeCells[currentCell.xIndex, currentCell.yIndex + 1]);
        }

        return unvisitedCells;
    }

    private void ClearWallsInBetween(MazeCell previous, MazeCell current)
    {
        if(previous == null)
        {
            return;
        }

        if(previous.transform.position.x < current.transform.position.x)
        {
            previous.ClearRightWall();
            current.ClearLeftWall();
        }
        else if(previous.transform.position.x > current.transform.position.x)
        {
            previous.ClearLeftWall();
            current.ClearRightWall();
        }
        else if(previous.transform.position.z < current.transform.position.z)
        {
            previous.ClearTopWall();
            current.ClearBottomWall();
        }
        else if(previous.transform.position.z > current.transform.position.z)
        {
            previous.ClearBottomWall();
            current.ClearTopWall();
        }
    }

    private void RemoveCenter()
    {
        _mazeCells[4, 4].gameObject.SetActive(false);
        _mazeCells[4, 5].gameObject.SetActive(false);
        _mazeCells[5, 4].gameObject.SetActive(false);
        _mazeCells[5, 5].gameObject.SetActive(false);
    }
}
