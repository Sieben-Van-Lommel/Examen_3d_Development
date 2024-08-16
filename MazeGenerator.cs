
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.AI.Navigation;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCellObject _mazeCellPrefab;

    [SerializeField]
    private int _mazeWidth;

    [SerializeField]
    private int _mazeDepth;

    [SerializeField]
    public int _seed;

    [SerializeField]
    private bool _useSeed;

    [SerializeField]
    public int saveSeed;

    GameManager gameManager;
    ScenesManager scenesManager;
    

    private MazeCellObject[,] _mazeGrid;


    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        scenesManager = FindAnyObjectByType<ScenesManager>();
        
        MakeSeed();
   
        _mazeGrid = new MazeCellObject[_mazeWidth, _mazeDepth];

        for (int x = 0; x < _mazeWidth; x++)
        {
            for (int z = 0; z < _mazeDepth; z++)
            {
                _mazeGrid[x, z] = Instantiate(_mazeCellPrefab, new Vector3(x, 0, z), Quaternion.identity.normalized, transform);
                _mazeGrid[x, z].transform.localPosition = new Vector3(x, 0, z);
            }
        }

        GenerateMaze(null, _mazeGrid[0, 0]);
        //GetComponent<NavMeshSurface>().BuildNavMesh();

        foreach (NavMeshSurface surface in GetComponents<NavMeshSurface>())
        {
            surface.BuildNavMesh();
        }
    }
    private void MakeSeed()
    {
        if (_useSeed)
        {
            Random.InitState(_seed);
            saveSeed = _seed;
        }
        else
        {
            int randomSeed = Random.Range(1, 1000000);
            Random.InitState(randomSeed);
            saveSeed = randomSeed;


            Debug.Log(randomSeed);
        }
        //Random.InitState(_seed);
    }

    private void GenerateMaze(MazeCellObject previousCell, MazeCellObject currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);

        MazeCellObject nextCell;

        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
    }

    private MazeCellObject GetNextUnvisitedCell(MazeCellObject currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    private IEnumerable<MazeCellObject> GetUnvisitedCells(MazeCellObject currentCell)
    {
        int x = (int)currentCell.transform.localPosition.x;
        int z = (int)currentCell.transform.localPosition.z;

        if (x + 1 < _mazeWidth)
        {
            var cellToRight = _mazeGrid[x + 1, z];

            if (cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        if (x - 1 >= 0)
        {
            var cellToLeft = _mazeGrid[x - 1, z];

            if (cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }
        }

        if (z + 1 < _mazeDepth)
        {
            var cellToFront = _mazeGrid[x, z + 1];

            if (cellToFront.IsVisited == false)
            {
                yield return cellToFront;
            }
        }

        if (z - 1 >= 0)
        {
            var cellToBack = _mazeGrid[x, z - 1];

            if (cellToBack.IsVisited == false)
            {
                yield return cellToBack;
            }
        }
    }

    private void ClearWalls(MazeCellObject previousCell, MazeCellObject currentCell)
    {
        if (previousCell == null)
        {
            return;
        }

        if (previousCell.transform.localPosition.x < currentCell.transform.localPosition.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }

        if (previousCell.transform.localPosition.x > currentCell.transform.localPosition.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }

        if (previousCell.transform.localPosition.z < currentCell.transform.localPosition.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }

        if (previousCell.transform.localPosition.z > currentCell.transform.localPosition.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }
    }


}


