using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;
    [Header("Set Dynamically")]
    public float camZ;
    
    void Awake()
    {
        camZ = this.transform.position.z;    
    }
    void FixedUpdate()
    {
        if (POI == null) return; // выйти, если нет интересующего объекта
        
        // Получить позицию интересующего объекта
        Vector3 destination = POI.transform.position;
        
        // Принудительно установить значение destination.z равным camZ, чтобы
        // отодвинуть камеру подальше
        destination.z = camZ;

        // Поместить камеру в позицию destination

        transform.position = destination;
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
