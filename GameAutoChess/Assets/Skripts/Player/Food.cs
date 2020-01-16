using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{
    public int healthPoints;
    public int foodPoints;

    public Food(string name, int countPrise, float vesItem)
    {
        itemName = name;
        
    }
}
