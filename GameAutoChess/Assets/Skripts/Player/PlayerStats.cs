using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerStats
{
    public string persName;
    public string persBiog;
    public int selectImg;

    public int health;
    public int curHealth;
    public int curVes;
    public int maxVes;
    public int resRad;
    public int curRad;
    public int chanceMiss;
    public int chanceCrit;
    public int selectedSkill;
    public int damage;
    public int Str;
    public int Agl;
    public int Int;
    public int Luck;
    public List<Item> items = new List<Item>();

    public PlayerStats(string name, string bio, int img, int heal, int ves, int rRad, int cM, int cCr, int selSk, int St, int Ag, int Intel, int Lu, int dam)
    {
        persName = name;
        persBiog = bio;
        selectImg = img;
        health = heal;
        maxVes = ves;
        resRad = rRad;
        chanceCrit = cCr;
        chanceMiss = cM;
        selectedSkill = selSk;
        Str = St;
        Agl = Ag;
        Int = Intel;
        Luck = Lu;
        curHealth = health;
        curRad = 0;
        curVes = 0;
        damage = dam;
    }


    public void AddItem(Item item)
    {
        if ((curVes + item.ves) < maxVes)
        {
            items.Add((Item)new Food("Kek", 100, 2));
            items.Add(item);
            curVes += item.ves;
        }
    }
    public PlayerStats()
    {

    }

}
