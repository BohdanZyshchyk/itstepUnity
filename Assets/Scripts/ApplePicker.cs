using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;





    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

    }

    public void AppleDestroyed()
    {
        // Удалить все упавшие яблоки
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple"); // b
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        // Удалить одну корзину // e
        // Получить индекс последней корзины в basketList
        int basketindex = basketList.Count - 1;
        // Получить ссылку на этот игровой объект Basket
        GameObject tBasketGO = basketList[basketindex];
        // Исключить корзину из списка и удалить сам игровой объект
        basketList.RemoveAt(basketindex);
        Destroy(tBasketGO);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
