using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats PlayerStats;
    public GameObject target;
    public Transform gunPoint;
    public LineRenderer bullet;
    public struct Position{
        public int x;
        public int y;
    }
    public Position pos;
    public Vector2 SetStartPos(GameObject[,] cells)
    {
        pos.x = 4;
        pos.y = 7;
        return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);
    }
    public Vector2 MoveForward(GameObject[,] cells) 
    {
          if (pos.y > 0)
              pos.y = pos.y - 1;

        return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);
    }
    public Vector2 MoveRight(GameObject[,] cells)
    {
        if (pos.x <9)
            pos.x = pos.x+1;
        return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);
    }
    public Vector2 MoveLeft(GameObject[,] cells)
    {
        if (pos.x > 0)
            pos.x = pos.x-1;
        return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);
    }
    public Vector2 GetPosition(GameObject cell)
    {
        return new Vector2(cell.transform.position.x, cell.transform.position.y);
    }
}
