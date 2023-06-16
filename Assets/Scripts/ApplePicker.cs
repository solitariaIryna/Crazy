using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    private GameObject basketPrefab;
    private int numBaskets = 3;
    private float basketBottomY = -14f;
    private float basketSpacingY = 2f;
    private List<GameObject> basketList;
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i=0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }


    public void AppleDestroyed()
    {
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        
        if (basketList.Count == 0)
            SceneManager.LoadScene("SampleScene");

    }
}   
