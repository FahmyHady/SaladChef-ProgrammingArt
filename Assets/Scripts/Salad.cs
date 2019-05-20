using System;
using System.Collections.Generic;
using UnityEngine;

public class Salad : MonoBehaviour
{
    public VegetableType myType;
    public Vegetable[] myComponents;
    Array myTypes;
    void Start()
    {
        myTypes = Enum.GetValues(myType.GetType());
        myComponents = GetComponentsInChildren<Vegetable>();
    }

    public void SetSaladComponents()
    {
        for (int i = 0; i <myComponents.Length; i++)
        {
            myComponents[i].vegetableType = GetFlag(i+1);
        }
    }
    VegetableType GetFlag(int index)
    {
        if (myType.HasFlag((VegetableType)myTypes.GetValue(index)))
        {
            return (VegetableType)myTypes.GetValue(index);
        }
        else return VegetableType.None;
    }
}
