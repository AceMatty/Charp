using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public CreateGrid CreateGrid;
    public int curStep;
    public float timerOfStep;
    public float curTimerOfStep;
    GameObject player;
    GameObject[] enemys;
    public Player playerScript;
    GameObject[,] cells;
    public Text log;
    int[,] stateCell = new int[8,10];

    void LoadPlayerStats()
    {
        playerScript.PlayerStats = GameFunc.LoadGame(@"Assets\Saves\loadBattle.save");
        GameFunc.DeleteSave("loadBattle");
    }

    void Start()
    {
        curTimerOfStep = timerOfStep;
        CreateGrid.DrawGrid();
        cells = CreateGrid.grid;
        curStep = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        playerScript = player.GetComponent<Player>();
        LoadPlayerStats();
        player.transform.position = playerScript.SetStartPos(cells);
        stateCell[playerScript.pos.y, playerScript.pos.x] = 1;
        foreach (GameObject enemy in enemys)
        {
            enemy.transform.position = enemy.GetComponent<Enemy>().SetStartPos(cells, 0, 0);
            enemy.GetComponent<Enemy>().log = log;
            stateCell[enemy.GetComponent<Enemy>().pos.y, enemy.GetComponent<Enemy>().pos.x] = 2;
        }
        playerScript.target = NearEnemy();
        
    }
    void NextStep()
    {
        UpdStateCell();
        playerScript.target = NearEnemy();
        enemys[0].transform.position = enemys[0].GetComponent<Enemy>().MoveToPlayer(cells, stateCell, playerScript.pos.x, playerScript.pos.y);
        StartCoroutine(PlayerShoot());
    }
    void Update()
    {

        Timer();
        LookPlayerToEnemy();
        InputPlayer();
    }
    void UpdStateCell()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                stateCell[i, j] = 0;
            }
        }
        stateCell[playerScript.pos.y, playerScript.pos.x] = 1;
        foreach (GameObject enemy in enemys)
        {
            stateCell[enemy.GetComponent<Enemy>().pos.y, enemy.GetComponent<Enemy>().pos.x] = 2;
        }

    }
    void Timer()
    {
           
        curTimerOfStep -= Time.deltaTime;
        if(curTimerOfStep < 0)
        {
            NextStep();
            curTimerOfStep = timerOfStep;
            curStep++;

        }
    }
    GameObject NearEnemy()
    {
        GameObject nerEn = enemys[0];
        if (enemys.Length == 0)
            return nerEn;
        else
        {
            foreach (GameObject en in enemys)
            {
                if (((playerScript.pos.x - en.GetComponent<Enemy>().pos.x) < (playerScript.pos.x - nerEn.GetComponent<Enemy>().pos.x)) && ((playerScript.pos.y - en.GetComponent<Enemy>().pos.y) < (playerScript.pos.y - nerEn.GetComponent<Enemy>().pos.y)))
                {
                    nerEn = en;
                }
            }
        }



        return nerEn;
    }
    void LookPlayerToEnemy()
    {
        player.transform.rotation = Quaternion.Lerp(playerScript.gunPoint.rotation, Quaternion.LookRotation(Vector3.forward, playerScript.target.transform.position - playerScript.gunPoint.position), Time.deltaTime * 3f);

        
    }
    void InputPlayer()
    {
        if(Input.GetKeyDown(KeyCode.W))
            player.transform.position = playerScript.MoveForward(cells);
        if (Input.GetKeyDown(KeyCode.A))
            player.transform.position = playerScript.MoveLeft(cells);
        if (Input.GetKeyDown(KeyCode.D))
            player.transform.position = playerScript.MoveRight(cells);

    }
    IEnumerator PlayerShoot()
    {
        Debug.Log("Strike");
        playerScript.bullet.enabled = true;
        playerScript.bullet.SetPosition(0, playerScript.gunPoint.position);
        playerScript.bullet.SetPosition(1, playerScript.target.transform.position);
        playerScript.target.GetComponent<Enemy>().GetDamage(playerScript.PlayerStats);
        yield return 0;
        playerScript.bullet.enabled = false;

    }
}
