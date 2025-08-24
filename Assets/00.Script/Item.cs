using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Item : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int uuid;
    public Image itemImage;

    public GameObject GetPrefab()
    {
        return prefab;
    }
    public int GetUUID()
    {
        return uuid;
    }

}

