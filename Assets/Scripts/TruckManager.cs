using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckManager : MonoBehaviour
{
    public Animator animator;

    public RockItem rockItem;

    void OnMouseDown()
    {
        animator.SetTrigger("Move");
        if (rockItem != null)
        {
            rockItem.EnableCollision();
        }
    }
}
