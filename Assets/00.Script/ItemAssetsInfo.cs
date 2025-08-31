using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemAssetsInfo : MonoBehaviour
{
    public static ItemAssetsInfo Instance;

    public List<Item> ItemInfos = new List<Item>();

    public Item GetItemInfo(int id)
    {
        return ItemInfos.Find(x => x.GetUUID() == id);
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


}

