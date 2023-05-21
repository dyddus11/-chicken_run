using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public float rotateSpeed = 0.1f;
    public GameObject rectangleObject; // 사각형 오브젝트
    public float rotationOffset = 90f; // 사각형 오브젝트의 회전 오프셋
    // Start is called before the first frame update
    void Start()
    {
        // 사각형 오브젝트를 원형 오브젝트의 자식으로 설정
        rectangleObject.transform.parent = transform;

        // 사각형 오브젝트의 위치를 원형 오브젝트의 중심으로 조정
        rectangleObject.transform.localPosition = Vector3.zero;

        Vector3 surfacePoint = transform.position + (transform.up * transform.localScale.x/ 2);
        rectangleObject.transform.position = surfacePoint ;
                                            
        float rectangleWidth = 0.1f; // 사각형의 가로 길이
        float rectangleHeight = 0.1f; // 사각형의 세로 길이
        rectangleObject.transform.localScale = new Vector3(rectangleWidth, rectangleHeight, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(0,0,rotateSpeed));
    }
}
