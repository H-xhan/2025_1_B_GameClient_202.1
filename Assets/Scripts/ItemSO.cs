using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = " Inventory/item")]

public class ItemSO : ScriptableObject
{
    //기존 GameDV Excel에서 선언한 변수를 나열 한다.
    public int id;
    public string itemName;
    public string nameEng;
    public string description;
    public ItemType itemType;
    public int price;
    public int power;
    public int level;
    public bool isStackable;
    public Sprite icon;

    public override string ToString()
    {
        return $"[{id}] {itemName} ({itemType} - 가격 : {price}골드, 속성 : {power}";
    }

    public string DisplayName
    {
        get { return string.IsNullOrEmpty(nameEng) ? itemName : nameEng; }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}