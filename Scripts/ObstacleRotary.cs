using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class ObstacleRotary : MonoBehaviour
{
    public static ObstacleRotary Instance;

    [SerializeField] private AudioSource obstacleSound;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        transform.DOMoveZ(10, 1f).SetRelative().SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(new Vector3(0, 360, 0), 5f, RotateMode.LocalAxisAdd).SetRelative().SetLoops(-1, LoopType.Yoyo);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(AConsts.CHAR_TAG))
        {
            Debug.Log("Rotary Temas edildi,\n" + AConsts.GAME_OVER);
            obstacleSound.Play();
            MovementCharacter.Instance.gameObject.transform.localPosition = new Vector3(0, 2, 2);
        }
    }
}