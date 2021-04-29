using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    private List<Vector3> points;
    static public ProjectileLine S; //Singleton
    private LineRenderer line;
    private GameObject _poi;
    [Header("Set in Inspector")]
    public float minDist = 0.1f;
    public GameObject poi
    {
        get { return _poi; }
        set { 
            _poi = value; 
            if(_poi != null)
            {
                // Если поле _poi содержит действительную ссылку,
                // сбросить все остальные параметры в исходное состояние
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }
        }
    }

    // Возвращает местоположение последней добавленной точки
    public Vector3 lastPoint {
        get
        {
            if(points == null)
            {
                return Vector3.zero;
            }
            return points[points.Count - 1];
        }
    }

    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }

    public void AddPoint()
    {
        // Вызывается для добавления точки в линии
        Vector3 pt = _poi.transform.position;
        if(points.Count > 0 && (pt - lastPoint).magnitude < minDist)
        {
            // Если точка недостаточно далека от предыдущей, просто выйти
            return;
        }
        // Если это точка запуск
        if (points.Count == 0)
        {
            Vector3 launchPosDiff = pt - Slingshot.LAUNCH_POS;
            // ...добавить дополнительный фрагмент линии,
            // чтобы помочь лучше прицелиться в будущем
            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.positionCount = 2;
            // Установить первые две точки
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);
            // Включить LineRenderer
            line.enabled = true;
        }
    }

    void FixedUpdate()
    {
        if (poi == null)
        {
            // Если свойство poi содержит пустое значение, найти интересующий
            // объект
            if (FollowCam.POI != null)
            {
                if (FollowCam.POI.tag == "Projectile")
                {
                    poi = FollowCam.POI;
                }
                else
                {
                    return; // Выйти, если интересующий объект не найден
                }
            }
            else
            {
                return; // Выйти, если интересующий объект не найден
            }
        }
        // Если интересующий объект найден,
        // попытаться добавить точку с его координатами в каждом FixedUpdate
        AddPoint();
        if(FollowCam.POI == null)
        {
            // Если FollowCam.POI содержит null, записать nulll в poi
            poi = null;
        }

    }
    void Awake()
    {
        S = this; // init singleton
        // Получить ссылку на LineRenderer
        line = GetComponent<LineRenderer>();
        // Выключить LineRenderer, пока он не понадобится
        line.enabled = false;
        // Инициализировать список точек
        points = new List<Vector3>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
