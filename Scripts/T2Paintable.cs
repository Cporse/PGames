using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2Paintable : MonoBehaviour
{
    [SerializeField] private GameObject brush;
    [SerializeField] private float brushSize = 0.05f;
    private void Update()
    {
        if (T2ControllerFinishLine.Instance.isFinish)
        {
            if (Input.GetMouseButton(0))
            {
                var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(Ray, out hit))
                {
                    //var gameObject = Instantiate(brush, hit.point + Vector3.up * .1f, Quaternion.identity, transform);
                    var gameObject = Instantiate(brush, hit.point + new Vector3(0, 0, 1) * -.2f, Quaternion.Euler(-90, 0, 0), transform);
                    gameObject.transform.localScale = Vector3.one * brushSize;
                }
            }
        }
    }

    //Functions,

    //END LINE.
}