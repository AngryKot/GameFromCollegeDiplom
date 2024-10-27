using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
 

  public static void LookAtSmooth(this Transform me, Vector3 target, float t)
    {
        var look = Quaternion.LookRotation(target - me.position);

        me.rotation = Quaternion.Lerp(me.rotation, look, t * Time.deltaTime);
    }
}