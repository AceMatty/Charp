using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class MainMebu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject loadPanel;
    public GameObject mainMenuPanel;
    public GameObject MessagePanel;
    [Space]
    [Header("UI")]
    public GameObject itemList;
    public GameObject content;
    public Text txtSaveInfo;

    string[] files;
    int saveSelect = -1;

    public Text version;

    void Start()
    {
        version.text = "Версия: " +Application.version;    
    }


    public void NewGame()
    {
        SceneManager.LoadScene(1);

    }
    public void LoadGame()
    {
        loadPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        LoadSaves();
    }
    void LoadSaves()
    {
        files = GameFunc.GetSaves();
        
        for (int i = 0; i < files.Length; i++)
        {
            GameObject inst = GameObject.Instantiate(itemList, content.gameObject.transform);
            inst.transform.GetChild(0).gameObject.GetComponent<Text>().text = (files[i].Substring(13)).Remove((files[i].Substring(13)).IndexOf('.'));
            var ind = i;
            inst.GetComponent<Button>().onClick.AddListener(() => { SelectSave(ind); });
        }

    }
    public void SelectSave(int ind)
    {
        saveSelect = ind;
        PlayerStats statsInfo = GameFunc.LoadGame(files[ind]);
        txtSaveInfo.text = "Выбранное сохранение: " + (files[ind].Substring(13)).Remove((files[ind].Substring(13)).IndexOf('.')) + "\n Персонаж: " + statsInfo.persName + "\nТекущее здоровье: " + statsInfo.curHealth;
    }
    public void DeleteSave()
    {
        if (saveSelect != -1)
        {
            if (GameFunc.DeleteSave(files[saveSelect]))
            {
                MessageBox("Удаление успешно!", 1);
                txtSaveInfo.text = "";
                CheckSaves();
            }
            else
            {
                MessageBox("Ошибка удаления!", 1);
            }
        }

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
    public void btnOkMesPan(int l)
    {
        switch (l)
        {
            case 0://MainPanel
                HideAll();
                mainMenuPanel.SetActive(true);
                break;
            case 1:
                HideAll();
                loadPanel.SetActive(true);
                break;
            case 2:
                MessagePanel.SetActive(false);
                break;
            

        }
    }

    private void HideAll()
    {
        mainMenuPanel.SetActive(false);
        loadPanel.SetActive(false);
        MessagePanel.SetActive(false);
    }

    public void MessageBox(string Message, int lvl)
    {
        HideAll();
        MessagePanel.SetActive(true);
        var i = lvl;
        MessagePanel.transform.GetChild(0).GetComponent<Text>().text = Message;
        MessagePanel.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => { btnOkMesPan(i); });

    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ShowSettings()
    {
        
       
    }
    public void OnlineGame()
    {
        SceneManager.LoadScene(4);
    }
    public void CloseLoadPanel()
    {
        loadPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        int max = content.transform.childCount;
        for (int i = 0; i < max; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }
    }
    void Update()
    {
        
    }
}
