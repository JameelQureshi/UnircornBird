using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonManager : MonoBehaviour
{
    Animator animator;
    public GameMain gameMain;
    public UnityEvent OnButtonPressed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (gameMain==null)
        {
            gameMain = FindObjectOfType<GameMain>();
        }
    }

    void OnMouseDown()
    {
        OnButtonPressed.Invoke();
        animator.SetTrigger("Push");
        gameMain.OnButtonPushed();
    }
}
