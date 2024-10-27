using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEnter : MonoBehaviour
{
   // public GameObject dialogBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // dialogBox.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
           // dialogBox.SetActive(false);

        }
    }
}
