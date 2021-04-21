using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{

    [Header("Set in Inspector")]
    public GameObject prefabProjectile;

    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    void Awake()
    {
        Transform launchPointsTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointsTrans.gameObject;
        launchPoint.SetActive(false);
    }
    void OnMouseEnter()
    {
        launchPoint.SetActive(true);
        //print("Slingsot:OnMouseEnter");
    }

    void OnMouseExit()
    {
        launchPoint.SetActive(false);
        //print("Slingsot:OnMouseExit");
    }

    void OnMouseDown()
    {
        // Игрок нажал кнопку мыши, когда указатель находился над рогаткой
        aimingMode = true;
        // Создать снаряд
        projectile = Instantiate(prefabProjectile) as GameObject;
        // Поместить в точку launchPoint
        projectile.transform.position = launchPos;
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }
}
