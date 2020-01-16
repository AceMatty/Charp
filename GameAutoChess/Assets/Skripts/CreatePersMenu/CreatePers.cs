using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization;

public class CreatePers : MonoBehaviour
{
    [Header("UI")]
    public Text txtStr;
    public Text txtAg;
    public Text txtInt;
    public Text txtLuck;
    public Text txtFreePoints;
    public Text txtStats;
    public Text txtInfo;

    [Space]
    [Header("Values")]
    public int Str = 5;
    public int Agl = 5;
    public int Int = 5;
    public int Luck = 5;
    public int freePoints = 10;
    [Space]
    [Header("Player Stats")]
    public int health;
    public int maxVes;
    public int resRad;
    public int chanceMiss;
    public int chanceCrit;
    [Space]
    string info;
    public bool equipSkill = false;
    public int selectedSkill;
    string nameSkill;
    public GameObject MainPanel;
    public GameObject SecondPanel;
    public GameObject ErrorPanel;
    [Space]
    [Header("Player Data")]
    public Texture[] images = new Texture[15];
    public string persName;
    public string persBiog;
    public int selectImg;
    public Slider sliderImg;
    public InputField txtName;
    public InputField txtBoig;
    public RawImage icon;

    public static string path;

    void Start()
    {
        Str = 5;
        Agl = 5;
        Int = 5;
        Luck = 5;
        freePoints = 10;
    }
    public void AddPoint(int type)
    {
        switch (type)
        {
            case 0: //Str
                if (Str < 15 && freePoints > 0)
                {
                    Str++;
                    freePoints -= 1;
                }
                break;
            case 1: //Agility
                if (Agl < 15 && freePoints > 0)
                {
                    Agl++;
                    freePoints -= 1;
                }
                break;
            case 2: //Inte
                if (Int < 15 && freePoints > 0)
                {
                    Int++;
                    freePoints -= 1;
                }
                break;
            case 3: //Luck
                if (Luck < 15 && freePoints > 0)
                {
                    Luck++;
                    freePoints -= 1;
                }
                break;
        }
    }
    public void Sub(int type)
    {
        switch (type)
        {
            case 0: //Str
                if (Str > 1)
                {
                    Str--;
                    freePoints++;
                }
                break;
            case 1: //Agility
                if (Agl > 1)
                {
                    Agl--;
                    freePoints++;
                }
                break;
            case 2: //Inte
                if (Int > 1)
                {
                    Int--;
                    freePoints++;
                }
                break;
            case 3: //Luck
                if (Luck > 1)
                {
                    Luck--;
                    freePoints++;
                }
                break;
        }
    }
    public void Info(int type)
    {
        switch (type)
        {
            case 0:
                info = "Описание: Сила. \n Сила влияет на масимальный запас здоровья, на переносимы вес, на общию выносливость персонажа.";
                break;
            case 1:
                info = "Описание: Ловкость. \n Ловкость влияет на скорость передвежение, на ловкость в бою.";
                break;
            case 2:
                info = "Описание: Интелект. \n Интелект увеличивает получаемый опыт, влияет на уровень владения с техникой, отображает уровень общего развития персонажа.";
                break;
            case 3:
                info = "Описание: Удача. \n Определяет на сколько ваш персонаж везучий.";
                break;
            case 10:
                info = "Описание: Иследователь. \n Вы знаете все особенности аномалий, что дает вам повышенные шансы найти артефакт и выжить.";
                break;
            case 11:
                info = "Описание: Твердая рука. \n Вы меткий стрелок и чаще попадаете по более уязвимым местам. (+10% к шансу критического урона)";
                break;
            case 12:
                info = "Описание: Свинцовый человек. \n Вы от природы имеете хорошую сопротивляемость к радиации (+10% к сопротивлению к радиации).";
                break;
            case 13:
                info = "Описание: Верблюжий горб. \n Вы можете переносить очень большой вес на себе без особых затрат сил (+20 к переносимому весу).";
                break;
            case 14:
                info = "Описание: Ловкач. \n Вы очень шустрый и гибкий, что позволяет вам в бою быть более маневренным (+10% к шансу уклонения).";
                break;

        }
    }
    public void ChooseSkill(int selected)
    {
        switch (selected)
        {
            case 0:
                if(equipSkill == false)
                {
                    selectedSkill = selected;
                    equipSkill = true;
                    nameSkill = "Иследователь";
                    return;
                }
                else
                {
                    equipSkill = false;
                }
            break;
            case 1:
                if (equipSkill == false)
                {
                    selectedSkill = selected;
                    equipSkill = true;
                    chanceCrit += 10;
                    nameSkill = "Твердая рука";
                    return;
                }
                else
                {
                    equipSkill = false;
                    chanceCrit -= 10;
                }
                break;
            case 2:
                if (equipSkill == false)
                {
                    selectedSkill = selected;
                    equipSkill = true;
                    resRad += 10;
                    nameSkill = "Свинцовый человек";
                    return;
                }
                else
                {
                    equipSkill = false;
                    resRad -= 10;
                }
                break;
            case 3:
                if (equipSkill == false)
                {
                    selectedSkill = selected;
                    equipSkill = true;
                    maxVes+=20;
                    nameSkill = "Верблюжий горб";
                    return;
                }
                else
                {
                    equipSkill = false;
                    maxVes -= 20;
                }
                break;
            case 4:
                if (equipSkill == false)
                {
                    selectedSkill = selected;
                    equipSkill = true;
                    chanceMiss += 10;
                    nameSkill = "Ловкач";
                    return;
                }
                else
                {
                    equipSkill = false;
                    chanceMiss -= 10;
                }
                break;


        }
    }
    void UpdateUI()
    {
        txtStr.text = " Сила: " + Str;
        txtAg.text = " Ловкость: " + Agl;
        txtInt.text = " Интелект: " + Int;
        txtLuck.text = " Удача: " + Luck;
        txtFreePoints.text = " Cвободные очки: " + freePoints;
        txtStats.text = "Основные параметры: \n"+"Здоровье: " + health + "\n"+ "Максимально переносмый вес: "+maxVes+ "\n"+"Сопротивление к радиации: "+ resRad+"%\n"+"Шанс уклонения: "+ chanceMiss+"%\n"+"Шанс критического урона: " + chanceCrit + "%\n";
        if(equipSkill == true)
        {
            txtStats.text += "Выбранный скилл: " + nameSkill;
        }
        txtInfo.text = info;
        icon.texture = images[(int)sliderImg.value];



    }
    void UpdateStats()
    {
        health = (int)(40 + (1.5 * Str));
        maxVes = (int)((Str * 2) + 10);
        resRad = (int)(10 + (0.5 * Str));
        chanceMiss = (int)((Agl * 0.5) + 5);
        chanceCrit = (int)((Luck + Agl) * 0.5);

        if(selectedSkill == 2 && equipSkill==true)
            resRad += 10;
        if(selectedSkill == 3 && equipSkill == true)
            maxVes += 20;
        if (selectedSkill == 4 && equipSkill == true)
            chanceMiss += 10;
        if (selectedSkill == 1 && equipSkill == true)
            chanceCrit += 10;

        

    }
    public void NextPanel()
    {
        if(equipSkill == true && freePoints == 0)
        {
            MainPanel.SetActive(false);
            SecondPanel.SetActive(true);

        }
        else
        {
            MainPanel.SetActive(false);
            ErrorPanel.SetActive(true);
        }
    }
    public void ErrPnlBtn()
    {
        MainPanel.SetActive(true);
        ErrorPanel.SetActive(false);
    }
    public void EnterGame()
    {
        if (txtName.text!=""&& sliderImg.value != 0)
        {
            persName = txtName.text;
            persBiog = txtBoig.text;
            selectImg = (int)sliderImg.value;
            PlayerStats playerStats = new PlayerStats(persName, persBiog, selectImg, health, maxVes, resRad, chanceMiss, chanceCrit, selectedSkill, Str, Agl, Int, Luck, 2);
            
            try
            {
                path = @"Assets\Saves\NewGame_" + persName + ".save";
                Directory.CreateDirectory(@"Assets\Saves\");
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, playerStats);
                stream.Close();
                
              

            }
            catch (System.Exception ex)
            {
                Debug.Log(ex.Message);
            }
            PlayerPrefs.SetString("path", path);
            PlayerPrefs.Save();
            SceneManager.LoadScene(2);
        }
     
       
    }
    void Update()
    {
        UpdateStats();
        UpdateUI();
    }
}
