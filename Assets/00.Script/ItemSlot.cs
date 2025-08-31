using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public RawImage image;

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

    public void SetItem(int uuid)
    {
        var itemInfo = ItemAssetsInfo.Instance.GetItemInfo(uuid);
        item = itemInfo;
        image.texture = item.itemImage.mainTexture;
    }
}

