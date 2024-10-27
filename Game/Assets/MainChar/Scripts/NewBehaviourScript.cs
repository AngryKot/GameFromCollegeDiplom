

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMoveWithCamera : MonoBehaviour
{
    public Camera mainCamera; // ссылка на камеру, с которой вы хотите связать движение игрока
    public float speed = 10f; // скорость игрока
    private Vector3 targetDirection; // направление, в которое игрок должен двигаться

    // Start is called before the first frame update
    void Start()
    {
        // привязка камеры
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("No main camera found. Please add a Camera component to your player object.");
        }
    }

    // Update is called once per frame
    void Update()
    {

        // получение направления камеры
        targetDirection = mainCamera.transform.forward;
       
         // движение игрока в зависимости от положения камеры
        transform.Translate(targetDirection * speed * Time.deltaTime);
    }
}