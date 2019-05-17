using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public VegetableSO myvegSprites;
    SpriteRenderer spriteRenderer;
    public VegetableType vegetableType;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (vegetableType==VegetableType.None && spriteRenderer.sprite !=null) 
        {
            spriteRenderer.sprite = null;
        }
        if (vegetableType != VegetableType.None && spriteRenderer.sprite == null)
        {
            switch (vegetableType)
            {
                
                case VegetableType.Carrot:
                    spriteRenderer.sprite = myvegSprites.Carrot;
                    break;
                case VegetableType.Tomato:
                    spriteRenderer.sprite = myvegSprites.Tomato;
                    break;
                case VegetableType.Cucumber:
                    spriteRenderer.sprite = myvegSprites.Cucumber;
                    break;
                case VegetableType.Celery:
                    spriteRenderer.sprite = myvegSprites.Celery;
                    break;
                case VegetableType.Mayo:
                    spriteRenderer.sprite = myvegSprites.Mayo;
                    break;
                case VegetableType.Chicken:
                    spriteRenderer.sprite = myvegSprites.Chicken;
                    break;
             
               
            }
        }
    }
}
[System.Flags]
public enum VegetableType
{
    None = 0x0, Carrot=0x1, Tomato=0x2, Cucumber=0x4, Celery=0x8, Mayo=0x10, Chicken=0x20, All=0x3F
     
}
