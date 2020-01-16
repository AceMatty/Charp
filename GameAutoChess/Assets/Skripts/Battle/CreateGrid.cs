using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{

    public const int max_x = 10;
    public const int max_y = 8;
    public GameObject first;
    public GameObject pref;
    Vector2 lastPos;
    Vector2 firstPos;
    public GameObject[,] grid = new GameObject[8, 10];
    void Start()
    {
        
    }
    public GameObject[,] DrawGrid()
    {
        firstPos = new Vector2(-5.5f, 3.5f);
        lastPos = firstPos;
        for (int i = 0; i < max_y; i++)
        {
            for (int j = 0; j < max_x; j++)
            {
                GameObject p = GameObject.Instantiate(pref, first.transform);
                p.transform.position = new Vector2(lastPos.x + 1f, lastPos.y);
                lastPos = p.transform.position;
                grid[i, j] = p;

            }
            lastPos = new Vector2(firstPos.x, lastPos.y - 1f);

        }

        return grid;
    }

    void Update()
    {
       
       
    }
    void FillCell(int y, int x)
    {
        grid[y, x].gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
