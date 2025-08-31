using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEditor.Progress;
using DG.Tweening;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemSlot> itemSlotList = new List<ItemSlot>();
    public int maxSlotCount = 10;
    public GameObject inventoryWindow;

    public static Inventory Instance;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

        inventoryWindow.SetActive(false);
    }

    public void AddItem(int uuid)
    {
        CheckItemHave(uuid);
    }

    private void CheckItemHave(int uuid)
    {
        foreach (var slot in itemSlotList)
        {
            if (slot.item != null)
            {
                if (slot.item.GetUUID() == uuid)
                {
                    slot.Count++;
                    return;
                }
            }
        }

        SetNewItem(uuid);
    }

    private void SetNewItem(int uuid)
    {
        var emptySlot = GetFirstEmptySlot();

        if (emptySlot == null)
        {
            Debug.Log("¿Œ∫•≈‰∏Æ∞° ≤À √°Ω¿¥œ¥Ÿ.");
        }
        else
        {
            emptySlot.SetItem(uuid);
        }
    }

    private ItemSlot GetFirstEmptySlot()
    {
        foreach (var slot in itemSlotList)
        {
            if (slot.item == null)
            {
                return slot;
            }
        }

        return null;
    }
    //bool isOn = true;
    private Vector3 targetPos = new Vector3(425,270,0);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            transform.DOMove(targetPos, 1.0f);
            //OnOffInventory();
        }   

        
    }


   
    //private void OnOffInventory()
    //{
    //    isOn = !isOn;
    //    inventoryWindow.SetActive(isOn);

    //}
}