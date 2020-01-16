using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization;
using System;

public class PlayerController : MonoBehaviour
{
    public PlayerStats plStats;
    string path;

    [Header("Panels")]
    public GameObject LoadPanel;
    public GameObject SavePanel;
    public GameObject MainPanel;
    public GameObject MessagePanel;
    public GameObject PausePanel;
    public GameObject InventPanel;
    [Space]
    [Header("UI")]
    public GameObject itemList;
    public GameObject content;
    public Text txtSaveInfo;
    public InputField saveName;


    string[] files;
    int saveSelect = -1;
    void Start()
    {
        
        path = PlayerPrefs.GetString("path");
        Debug.Log(path);
        plStats = GameFunc.LoadGame(path);
    }
    void Update()
    {
        if(LoadPanel.activeSelf == false)
        {
            txtSaveInfo.text = "";
        }
        CheckInput();   
    }
    void CheckSaves()
    {
        int max = content.transform.childCount;
        for (int i = 0; i < max; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }
        files = GameFunc.GetSaves();
        for (int i = 0; i < files.Length; i++)
        {
            GameObject inst = GameObject.Instantiate(itemList, content.gameObject.transform);
            inst.transform.GetChild(0).gameObject.GetComponent<Text>().text = (files[i].Substring(13)).Remove((files[i].Substring(13)).IndexOf('.'));
            var ind = i;
            inst.GetComponent<Button>().onClick.AddListener(() => { SelectSave(ind); });
        }
        
    }
    void CheckInput()
    {
        if (Input.GetButtonDown("Load") && LoadPanel.activeSelf == false)
        {
            HideAll();
            LoadPanel.SetActive(true);
            CheckSaves();
            Debug.Log(files.Length);
            content.GetComponent<RectTransform>().rect.Set(content.GetComponent<RectTransform>().rect.x, content.GetComponent<RectTransform>().rect.y, content.GetComponent<RectTransform>().rect.width, files.Length * 30);
            return;
        }else if(Input.GetButtonDown("Load") && LoadPanel.activeSelf == true)
        {
            LoadPanel.SetActive(false);
            MainPanel.SetActive(true);
        }
        if(Input.GetButtonDown("Save") && SavePanel.activeSelf == false)
        {
            HideAll();
            SavePanel.SetActive(true);
            return;
        }
        else if(Input.GetButtonDown("Save") && SavePanel.activeSelf == true)
        {
            HideAll();
            MainPanel.SetActive(true);
        }
        if(Input.GetButtonDown("Cancel") && PausePanel.activeSelf == false)
        {
            HideAll();
            PausePanel.SetActive(true);
            return;
        }else if(Input.GetButtonDown("Cancel") && PausePanel.activeSelf == true)
        {
            HideAll();
            MainPanel.SetActive(true);
        }
        if(Input.GetButtonDown("Inv") && InventPanel.activeSelf == false)
        {
            HideAll();
            InventPanel.SetActive(true);
            return;
        }else if(Input.GetButtonDown("Inv") && InventPanel.activeSelf == true)
        {
            HideAll();
            MainPanel.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D raycast = Physics2D.Raycast(ray.origin, ray.direction);
            if (raycast)
            {
                if(raycast.collider.gameObject.tag == "Item")
                {
                    plStats.AddItem(raycast.collider.gameObject.GetComponent<Item>());
                    Destroy(raycast.collider.gameObject);
                    Debug.Log(plStats.items);
                }
            }
           

           

        }
    }
    public void SelectSave(int ind)
    {
        saveSelect = ind;
        PlayerStats statsInfo = GameFunc.LoadGame(files[ind]);
        txtSaveInfo.text = "Выбранное сохранение: " + (files[ind].Substring(13)).Remove((files[ind].Substring(13)).IndexOf('.'))+ "\n Персонаж: "+statsInfo.persName+"\nТекущее здоровье: "+statsInfo.curHealth;
    }
    public void LoadGame()
    {
        if (saveSelect != -1)
        {

            plStats = GameFunc.LoadGame(files[saveSelect]); 
            LoadPanel.SetActive(false);
            MessageBox("Сохранение загружено", 0);
        }
        else
        {
            MessageBox("Выберете сохранение и нажмите кнопку Загрузить", 0);
        }       


    }
    void HideAll()
    {
        MainPanel.SetActive(false);
        LoadPanel.SetActive(false);
        SavePanel.SetActive(false);
        MessagePanel.SetActive(false);
        PausePanel.SetActive(false);
        InventPanel.SetActive(false);
    }
    public void btnOkMesPan(int l)
    {
        switch (l)
        {
            case 0://MainPanel
                HideAll();
                MainPanel.SetActive(true);
            break;
            case 1:
                HideAll();
                LoadPanel.SetActive(true);
                break;
            case 2:
                MessagePanel.SetActive(false);
                break;
            case 3:
                HideAll();
                SavePanel.SetActive(true);
                break;

        }
    }
    public void MessageBox(string Message, int lvl)
    {
        HideAll();
        MessagePanel.SetActive(true);
        var i = lvl;
        MessagePanel.transform.GetChild(0).GetComponent<Text>().text = Message;
        MessagePanel.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => { btnOkMesPan(i); });
        
    }
    public void SaveGame()
    {
        if(saveName.text != ""&&saveName.text != null)
        {
            
                if(GameFunc.SaveGame(plStats, saveName.text))
                {
                    MessageBox("Сохранение успешно", 0);
                    saveName.text = "";
                }
                else
                {
                    MessageBox("Ошибка сохранения!", 3);
                }
        }
        else
        {
            MessageBox("Введите корректно название сохранения!", 3);
        }
    }
    public void DeleteSave()
    {
        if (saveSelect != -1)
        {
            if (GameFunc.DeleteSave(files[saveSelect]))
            {
                CheckSaves();
                MessageBox("Удаление успешно!", 1);
                txtSaveInfo.text = "";
            }
            else
            {
                MessageBox("Ошибка удаления!", 1);
            }
        }
        
    }
    public void OpenLoadPanel()
    {
        HideAll();
        LoadPanel.SetActive(true);
        CheckSaves();
        Debug.Log(files.Length);
        content.GetComponent<RectTransform>().rect.Set(content.GetComponent<RectTransform>().rect.x, content.GetComponent<RectTransform>().rect.y, content.GetComponent<RectTransform>().rect.width, files.Length * 30);
    }
    public void Close(GameObject o)
    {
        GameFunc.ClosePanel(o);
        MainPanel.SetActive(true);
    }
    public void LoadBattle()
    {
        GameFunc.DeleteSave("loadBattle");
        GameFunc.SaveGame(plStats, "loadBattle");
        SceneManager.LoadScene(3);
    }
}
