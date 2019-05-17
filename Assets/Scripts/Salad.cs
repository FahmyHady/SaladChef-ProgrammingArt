using System;
using System.Collections.Generic;
using UnityEngine;

public class Salad : MonoBehaviour
{
    public VegetableType myType;
    public Vegetable[] myComponents;
    void Start()
    {
        myComponents = GetComponentsInChildren<Vegetable>();
    }

    public void SetSaladComponents()
    {
        for (int i = 0; i < myComponents.Length; i++)
        {
            myComponents[i].vegetableType = GetFlag(i);
        }
    }
    VegetableType GetFlag(int index)
    {
        if (myType.HasFlag((VegetableType)Enum.GetValues(myType.GetType()).GetValue(index)))
        {
            return (VegetableType)Enum.GetValues(myType.GetType()).GetValue(index);
        }
        else return VegetableType.None;
    }
}
