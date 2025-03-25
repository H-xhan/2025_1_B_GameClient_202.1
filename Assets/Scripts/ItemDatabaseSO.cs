using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Inventory/Database")]
public class ItemDatabaseSO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();

    //캐싱을 위한 사전
    private Dictionary<int, ItemSO> itemsByld;
    private Dictionary<string, ItemSO> itemsByName;

    // Start is called before the first frame update
    public void Initialize()
    {
        itemsByld = new Dictionary<int, ItemSO>();
        itemsByName = new Dictionary<string, ItemSO>();

        foreach (var item in items)
        {
            itemsByld[item.id] = item;
            itemsByName[item.itemName] = item;
        }
    }

    // Update is called once per frame
    public ItemSO GetItemByld(int id)
    {
        if(itemsByld == null)
        {
            Initialize();
        }
        if (itemsByld.TryGetValue(id, out ItemSO item))
            return item;

        return null;
    }

    public ItemSO GetItemByName(string name)
    {
        if (itemsByName == null)
        {
            Initialize();
        }
        if (itemsByName.TryGetValue(name, out ItemSO item))
            return item;

        return null;
    }

    public List<ItemSO> GetItemByType(ItemType type)
    {
        return items.FindAll(item => item.itemType == type);
    }
}
