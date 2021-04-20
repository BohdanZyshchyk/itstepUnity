using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
    public static float appleSpeed = -5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, appleSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            // Получить ссылку на компонент ApplePicker главной камеры Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Вызвать общедоступный метод AppleDestroyed() из apScript
            apScript.AppleDestroyed(); // c
        }
        GameObject scoreGO = GameObject.Find("ScoreCounter"); // b
        var scoreGT = scoreGO.GetComponent<Text>();
        int score = int.Parse(scoreGT.text);
        if ((score % 500) == 0 && score != 0)
        {
            appleSpeed +=-10.0F;
        }
        
    }
}
