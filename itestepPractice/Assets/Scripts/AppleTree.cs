using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // шаблон для створення яблук
    public GameObject applePrefab;
    //швидкість переміщення яблуні
    public float speed = 1f;
    //межі руху яблуні
    public float leftAndRightEdge = 10f;
    //імовірність зміни напрямку руху яблуні
    public float changeToChangeDirections = 0.1f;
    // частота скидання яблук
    public float secondBetweenAppleDrops = 20f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }
    void DropApple() 
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondBetweenAppleDrops);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        
    }

    private void FixedUpdate()
    {
        if (Random.value < changeToChangeDirections)
        {
            speed *= -1;
        }
    }
}
