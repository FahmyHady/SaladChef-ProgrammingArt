using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public VegetableType vegetableType;
}
[System.Flags]
public enum VegetableType
{
    None = 0x0, Carrot=0x1, Tomato=0x2, Cucumber=0x4, Celery=0x8, Mayo=0x10, Chicken=0x20, All=0x3F
     
}
