using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{

    public string nameEnemy;
    public int health;
    public int curHealth;
    public int damage;
    public int armor;
    public int chanceMiss;
    public int chanceCrit;
    public GameObject target;
    public Text log;
    public Transform enemyTrans;
    public struct Position
    {
        public int x;
        public int y;
    }
    public Position pos;
    public Vector2 SetStartPos(GameObject[,] cells, int x, int y)
    {
        pos.x = x;
        pos.y = y;
        return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);
    }
    public Vector2 MoveForward(GameObject[,] cells)
    {
        if (pos.y < 9)
            pos.y = pos.y + 1;

        return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);
    }
    public Vector2 MoveRight(GameObject[,] cells)
    {
        if (pos.x >0)
            pos.x = pos.x -1;
        return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);
    }
    public Vector2 MoveLeft(GameObject[,] cells)
    {
        if (pos.x < 9)
            pos.x = pos.x + 1;
        return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);
    }
    public Vector2 GetPosition(GameObject cell)
    {
        return new Vector2(cell.transform.position.x, cell.transform.position.y);
    }
    public Vector2 MoveToPlayer(GameObject[,] cells, int[,] stateCell, int x, int y)
    {
        if(x == pos.x)
        {
            if(y > pos.y && stateCell[pos.y+1, pos.x]!=1 && stateCell[pos.y+1, pos.x] != 2)
            {
                pos.y++;
                enemyTrans.Rotate(180, 0, 0);
                return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);
            }
            else if(y < pos.y && stateCell[pos.y-1, pos.x] != 1 && stateCell[pos.y-1, pos.x] != 2)
            {
                pos.y --;
                enemyTrans.Rotate(-180, 0, 180);
                return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);
            }
            return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);
        }
        else
        {
            if(x > pos.x && stateCell[pos.y,pos.x+1] != 1 && stateCell[pos.y, pos.x+1] != 2)
            {
                pos.x++;
                return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);
            }
            else if(x < pos.x && stateCell[pos.y, pos.x-1] != 1 && stateCell[pos.y, pos.x-1] != 2)
            {
                pos.x--;
                return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);

            }
            return new Vector2(cells[pos.y, pos.x].transform.position.x, cells[pos.y, pos.x].transform.position.y);
        }

    }
    public void GetDamage(PlayerStats playerStats)
    {
        int chance = Random.Range(0,100);
        if (chance <= chanceMiss)
            log.text += nameEnemy+" увернулся"+"\n";
        else
        {
            chance = Random.Range(0, 100);
            if (chance <= playerStats.chanceCrit)
            {
                curHealth -= (int)(damage * 1.5);
                log.text += "Вы нанесли крит. урон: "+ (int)(damage * 1.5) + "\n";
                log.text += "У " + nameEnemy + " осталось " + curHealth+" здоровья \n";
            }
            else
            {
                curHealth -= damage;
                log.text += "Вы нанесли: "+ damage+ "\n";
                log.text += "У " + nameEnemy + " осталось " + curHealth + " здоровья \n";
            }
        }
        
        if(curHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

