//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//public class TeleportManager : MonoBehaviour
//{
//    PlayerController playerController;
//    //[SerializeField] GameObject player;
    
    
//    void Start()
//    {
//        playerController = gameObject.GetComponent<PlayerController>();
//    }

//    void Update()
//    {
//       if(Input.GetKeyDown(KeyCode.E))
//        {
//            StartCoroutine("Teleport");
//        }
//    }

//    IEnumerator Teleport()
//    {
//        playerController.disabled = true;
//        yield return new WaitForSeconds(0.01f);
//        gameObject.transform.position  = new Vector3(-11f,5f,21f);
//        yield return new WaitForSeconds(0.01f);
//        playerController.disabled = false;
//    }
//}
