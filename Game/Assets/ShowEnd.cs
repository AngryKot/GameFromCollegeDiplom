using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEnd : MonoBehaviour
{
    public GameObject EndgameBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndgameBox.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndgameBox.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
