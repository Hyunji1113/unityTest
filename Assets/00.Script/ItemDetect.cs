using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ItemDetect : MonoBehaviour
{
    public KeyCode getkey = KeyCode.G;

    private List<GameObject> itemInRange = new List<GameObject>();


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange.Add(other.gameObject);
        }
    }



    private void Update()
    {
        if (itemInRange.Count > 0 && Input.GetKeyDown(getkey))
        {
            GameObject closestItem = GetClosestItem();
            if (closestItem != null)
            {
                Item info = closestItem.GetComponent<Item>();
                
                
                //인벤 추가
                itemInRange.Remove(closestItem);
                Destroy(closestItem);


            }

        }
    }

    private GameObject GetClosestItem()
    {
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (var item in itemInRange)
        {
            if (item == null) continue;

            float dist = Vector3.Distance(item.transform.position, currentPos);

            if (dist < minDistance)
            {
                closest = item;
                minDistance = dist;
            }
        }

        return closest;
    }

}
