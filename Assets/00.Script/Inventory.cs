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
    private Vector3 originPosition;

    ItemSlot itemSlot;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

        inventoryWindow.SetActive(true);
        originPosition= inventoryWindow.transform.position;
        
    }
    public bool HasItem(int count , int id)
    {
        bool result = false;

        foreach(var slotItem in itemSlotList)
        {
            if(slotItem.item != null)
            {
                if(slotItem.item.GetUUID() == id)
                {
                    itemSlot = slotItem;
                    return slotItem.count >= count;
                }
            }
        }

        return result;
    }

    public void spendCoins(int count)
    {
        itemSlot.count--;
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
    private Vector3 targetPos = new Vector3(262, 91, 2);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryWindow.transform.position == originPosition)
            {
                MoveUpInven();
            }
            else
            {
                MoveDownInven();
            }
            
        }          
    }


    private void MoveUpInven()
    {
      
        inventoryWindow.transform.DOMove(targetPos, 1.0f);

    }

    private void MoveDownInven()
    {
        inventoryWindow.transform.DOMove(originPosition, 1.0f);
    }


    //private void OnOffInventory()
    //{
    //    isOn = !isOn;
    //    inventoryWindow.SetActive(isOn);

    //}
}