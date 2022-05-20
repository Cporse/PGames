using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class BonusMechanics2 : MonoBehaviour
{
    public static BonusMechanics2 Instance;

    [SerializeField] private Rigidbody rbCharacter;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void FixedUpdate()
    {
        //transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + .5f, 0);
        transform.localEulerAngles = new Vector3(0, Mathf.PingPong(Time.time * 60, 90) - 180);
    }
    private void Start()
    {
        //transform.DORotate(new Vector3(0, 180, 0), 10f, RotateMode.LocalAxisAdd).SetRelative().SetLoops(-1, LoopType.Yoyo);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag(AConsts.CHAR_TAG))
        //{
        //    Debug.Log("Çubuða temas edildi karaktere geriye doðru kuvvet uygulanmalý.");
            
        //    //rbCharacter.AddForce(0, 0, -500);
        //    rbCharacter.velocity = new Vector3(0, 0, -500);
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(AConsts.CHAR_TAG))
        {
            Debug.Log("Çubuða temas edildi karaktere geriye doðru kuvvet uygulanmalý.");

            //rbCharacter.AddForce(0, 0, -500);
            rbCharacter.velocity = new Vector3(0, 0, -30);
        }
    }
}