using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class ObstacleWall : MonoBehaviour
{
    public static ObstacleWall Instance;

    [SerializeField] private AudioSource obstacleSound;
    private bool isRight = false;
    private bool isLeft = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        //transform.DOMoveX(7.5f, 2f).SetRelative().SetLoops(-1, LoopType.Yoyo);
    }
    private void Update()
    {
        if (transform.position.x < -3.75f)
        {
            isLeft = false;
            isRight = true;
        }
        else if(transform.position.x > 3.75f)
        {
            isRight = false;
            isLeft = true;
            
        }

        if (isRight) transform.position = new Vector3(transform.position.x + .05f, transform.position.y, transform.position.z);
        if (isLeft) transform.position = new Vector3(transform.position.x - .05f, transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(AConsts.CHAR_TAG))
        {
            Debug.Log("Duvara temas edildi,\n" + AConsts.GAME_OVER);
            obstacleSound.Play();
            MovementCharacter.Instance.gameObject.transform.localPosition = new Vector3(0, 2, 2);
        }
        else if (other.gameObject.CompareTag("AI"))
        {
            other.gameObject.transform.localPosition = new Vector3(0, 2, 2);
        }
    }
}