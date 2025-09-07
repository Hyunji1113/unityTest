using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CraftManager : MonoBehaviour
{
    public Inventory inventory;
    public int coinForCrafting = 1;

    public GameObject TempBuildingPrefab;
    private GameObject tempBuildingInstance;

    Ray ray;
    RaycastHit hit;

    Coroutine craftingCoroutine;
    int DefaultLayer = 0;
    bool isCrafting = false;

    private void Awake()
    {
        Debug.Log("Awake");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (Inventory.Instance.HasItem(coinForCrafting, 1001)==true)
            {
                StartCrafting();
                

            }
            else
            {
                Debug.Log("크래프팅 불가");
            }

        }
        if (Input.GetKeyDown(KeyCode.E)) // 취소키
        {
            StopCrafting();
        }
    }


    public void StartCrafting()
    {
        {
            isCrafting = true;
            craftingCoroutine = StartCoroutine(Crafting());

        }      
    }

    public void StopCrafting()
    {
        isCrafting = false;
        StopCoroutine(craftingCoroutine);
        RemoveTempBuilding();
    }

    IEnumerator Crafting()
    {
        while(isCrafting)
        {
            CraftBuilding();
            yield return null;
        }
    }
    
    private void CraftBuilding()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            ShowTempBuilding(hit.transform.CompareTag("Ground"));
        }
    }

    private void RemoveTempBuilding()
    {
        DestroyImmediate(tempBuildingInstance);
    }
    
    private void ShowTempBuilding(bool isOn)
    {
        if(isOn)
        {
            if(tempBuildingInstance == null)
            {
                tempBuildingInstance = Instantiate(TempBuildingPrefab);
            }

            if(tempBuildingInstance.activeInHierarchy == false)
            {
                tempBuildingInstance.SetActive(true);
            }
            tempBuildingInstance.transform.position = hit.point;
            tempBuildingInstance.transform.rotation = Quaternion.LookRotation(hit.collider.transform.forward);

            if(Input.GetMouseButton(0))
            {
                Build();
            }
            // 반투명화 함수
        }
        else
        {
            if(tempBuildingInstance != null)
            {
                tempBuildingInstance.SetActive(false);
            }
        }
    }

    private void Build()
    {
        isCrafting = false;
        tempBuildingInstance.layer = DefaultLayer;
        tempBuildingInstance = null;
        Inventory.Instance.spendCoins(coinForCrafting);
    }
}
