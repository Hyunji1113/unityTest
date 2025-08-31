using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotpanel;
    public int slotcount = 10;

    private void Start()
    {
        for(int i = 0; i < slotcount; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotpanel);
            

        }
    }
}
