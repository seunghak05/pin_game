using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCircle : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1.0f; // (미사용) Inspector에서 회전 속도 조절용
    public float minSpeed = 50f; // 최소 회전 속도
    public float maxSpeed = 200f; // 최대 회전 속도
    public float minChangeTime = 1f; // 회전 방향/속도 변경 최소 시간
    public float maxChangeTime = 3f; // 회전 방향/속도 변경 최대 시간

    private float currentSpeed; // 현재 회전 속도
    private float timer; // 다음 회전 변경까지 남은 시간

    void Start()
    {
        SetRandomRotation(); // 시작 시 랜덤 회전 설정
    }

    void Update()
    {
        // 게임 오버가 아닐 때만 회전
        if (GameManager.instance.isGameOver == false)
        transform.Rotate(0, 0, currentSpeed * Time.deltaTime); // Z축 기준 회전

        // 타이머 감소
        timer -= Time.deltaTime;

        // 타이머가 0 이하가 되면 회전 방향/속도 재설정
        if (timer <= 0f)
        {
            SetRandomRotation();
        }
    }

    // 회전 방향, 속도, 변경 타이머를 랜덤하게 설정하는 함수
    void SetRandomRotation()
    {
        // 회전 속도를 minSpeed~maxSpeed 사이에서 랜덤 설정
        currentSpeed = Random.Range(minSpeed, maxSpeed);

        // 50% 확률로 회전 방향 반전
        if (Random.value < 0.5f)
        {
            currentSpeed *= -1f;
        }

        // 다음 회전 변경까지의 시간 랜덤 설정
        timer = Random.Range(minChangeTime, maxChangeTime);
    }
}
