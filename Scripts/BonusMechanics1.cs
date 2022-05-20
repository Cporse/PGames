using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class BonusMechanics1 : MonoBehaviour
{
    public static BonusMechanics1 Instance;
    //[SerializeField] private GameObject character;
    [SerializeField] private Rigidbody rbCharacter;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        transform.DORotate(new Vector3(0, 0, 360), 5f, RotateMode.LocalAxisAdd).SetRelative().SetLoops(-1, LoopType.Yoyo);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(AConsts.CHAR_TAG))
        {
            Debug.Log("Silindire temas edildi karaktere saða yada sola doðru kuvvet uygulanmalý.");
            //character.GetComponent<Rigidbody>().AddForce(5, 0, 0);
            rbCharacter.AddForce(1000, 0, 0);
            //rbCharacter.velocity = new Vector3(0, 0, 0);
        }
    }
}