using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    public static AnimatorScript Instance;

    public Animator animator;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        //anim.SetInteger("isRunning", 1);
    }
}