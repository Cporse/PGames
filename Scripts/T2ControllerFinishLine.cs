using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2ControllerFinishLine : MonoBehaviour
{
    public static T2ControllerFinishLine Instance;

    [SerializeField] private Transform newTargetForCamera;
    public bool isFinish = false;
    [SerializeField] private GameObject character;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //E�er biti� �izgisine karakter �arpt�ysa,
        //1-) Karakteri durdur,
        if (other.gameObject.CompareTag(AConsts.CHAR_TAG))
        {
            isFinish = true;
            Debug.Log("Biti� �izgisine temas edildi.");
            character.GetComponent<Rigidbody>().isKinematic = true;
            ControllerCamera.Instance.targetObject = newTargetForCamera;
            ControllerCamera.Instance.functionSetTarget();
            AnimatorScript.Instance.animator.SetInteger("isRunning", 0);
        }
    }
}