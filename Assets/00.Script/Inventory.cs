using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemSlot> itemSlotList;
    public int maxSlotCount = 10;

    public void AddItem(Item item)
    {
        CheckItemHave(item);
    }

    private void CheckItemHave(Item item)
    {
        int itemUUID = item.GetUUID();

        foreach (var slot in itemSlotList)
        {
            if (slot.item.GetUUID() == itemUUID)
            {
                slot.Count++;
                return;
            }
        }

        SetNewItem(item);
    }

    private void SetNewItem(Item item)
    {
        var emptySlot = GetFirstEmptySlot();

        if (emptySlot == null)
        {
            Debug.Log("ÀÎº¥Åä¸®°¡ ²Ë Ã¡½À´Ï´Ù.");
        }
        else
        {
            emptySlot.SetItem(item);
        }
    }

    private ItemSlot GetFirstEmptySlot()
    {
        foreach (var slot in itemSlotList)
        {
            if (slot.item ==  null)
            {
                return slot;
            }
        }

        return null;
    }



    public class ItemSlot : MonoBehaviour
    {
        public TextMeshProUGUI countText;
        public Image image;

        public Item item;
        private int count;
        public int Count
        {
            get => count;
            set
            {
                count = value;
                countText.text = count.ToString();
            }
        }

        public void SetItem(Item item)
        {
            this.item = item;
            this.count = 1;
            this.image = item.itemImage;
        }
    }
}
