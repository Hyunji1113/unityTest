using System.Collections.Generic;
using UnityEngine;

public class ItemAssetsInfo : MonoBehaviour
{
    public static ItemAssetsInfo Instance;

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


    public List<Item> ItemInfos = new List<Item>();
}

