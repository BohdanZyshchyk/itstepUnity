using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour
{
    [Header("Set in Inspector")]
    public int numClouds = 40; // clouds number
    public GameObject cloudPrefab; // cloud template
    public Vector3 cloudPosMin = new Vector3(-50, -5, 10);
    public Vector3 cloudPosMax = new Vector3(150, 100, 10);
    public float cloudScaleMin = 1;
    public float cloudScaleMax = 3;
    public float cloudSpeedMult = 0.5f;

    private GameObject[] cloudInstances;
    void Awake()
    {
        // Создать массив для хранения всех экземпляров облаков
        cloudInstances = new GameObject[numClouds];
        // Найти родительский игровой объект CloudAnchor
        GameObject anchor = GameObject.Find("CloudAnchor");
        // Создать в цикле заданное количество облаков
        GameObject cloud;
        for (int i = 0; i < numClouds; i++)
        {
            //Создать экземпляр cloudPrefab
            cloud = Instantiate<GameObject>(cloudPrefab);
            // Выбрать местоположение для облака
            Vector3 cpos = Vector3.zero;
            cpos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cpos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);

            // Масштабировать облако
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);
            // Меньшие облака (с меньшим значением scaleU) должны быть ближе
            // к земле
            cpos.y = Mathf.Lerp(cloudPosMin.y, cpos.y, scaleU);
            // Меньшие облака должны быть дальше
            cpos.z = 100 - 90 * scaleU;
            // Применить полученные значения координат и масштаба к облаку
            cloud.transform.position = cpos;
            cloud.transform.localScale = Vector3.one * scaleVal;
            // Сделать облако дочерним по отношению к anchor
            cloud.transform.SetParent(anchor.transform);

            //Добавить облако в массив cloudInstances
            cloudInstances[i] = cloud;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Обойти в цикле все созданные облака
        foreach (GameObject item in cloudInstances)
        {
            // Получить масштаб и координаты облака
            float scaleVal = item.transform.localScale.x;
            Vector3 cpos = item.transform.position;
            // Увеличить скорость для ближних облаков
            cpos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
            // Если облако сместилось слишком далеко влево..
            if (cpos.x <= cloudPosMin.x)
            {
                cpos.x = cloudPosMax.x;
            }
            item.transform.position = cpos;
        }
    }
}
