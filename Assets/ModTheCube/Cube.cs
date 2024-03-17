using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    // 커스텀 MeshRenderer 를 담기위한 변수
    public MeshRenderer Renderer;

    // 변수에 한 번 담아서 이후 전역에서 사용하기 위한 변수들
    private Material material;
    private int xAngle = 0, yAngle = 0, zAngle = 0;                 // 회전 각도 관련
    private float rColor = 0, gColor = 0, bColor = 0, alpha = 0;    // 랜덤 색상 관련
    private float speed = 50f;      // 회전 속도

    void Start()
    {
        // 랜덤한 좌표를 담아서 실제 적용
        Vector3 RandomPos = new Vector3(transform.position.x + Random.Range(-2.0f, 2.0f), transform.position.y + Random.Range(-2.0f, 2.0f), 0);
        transform.position = RandomPos;
        // 랜덤한 스케일 적용
        transform.localScale = Vector3.one * Random.Range(1, 5);

        // 회전 각도 랜덤 지정
        xAngle = Random.Range(10, 25);
        yAngle = Random.Range(10, 25);
        zAngle = Random.Range(10, 25);
        transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime);

        // 마터리얼 변수에 현재 렌더된 마터리얼을 담고 초기 색사 랜덤 지정
        material = Renderer.material;
        material.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
    }

    void Update()
    {
        // 원하는 회전 각도로 XYZ 랜덤 변경
        transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime);

        // 랜덤 색상 지정한 속도로 수치값 증가
        rColor = material.color.r + (speed / 255f) * Time.deltaTime;
        gColor = material.color.g + (speed / 255f) * Time.deltaTime;
        bColor = material.color.b + (speed / 255f) * Time.deltaTime;
        alpha = material.color.a + (speed / 255f) * Time.deltaTime;

        // RGBA 값의 최대치인 1.0f 를 돌파시 자동으로 랜덤 값으로 재지정
        if (rColor >= 1.0f) rColor = Random.Range(0, 1.0f);
        if (gColor >= 1.0f) gColor = Random.Range(0, 1.0f);
        if (bColor >= 1.0f) bColor = Random.Range(0, 1.0f);
        if (alpha >= 1.0f) alpha = Random.Range(0, 1.0f);

        // 실제 랜덤 색상 적용
        material.color = new Color(rColor, gColor, bColor, alpha);
    }
}
