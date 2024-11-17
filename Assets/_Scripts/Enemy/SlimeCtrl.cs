using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SlimeCtrl : MonoBehaviour
{
    public Vector3 targetSlimeMove;
    [SerializeField]
    private float rotateDuration = 1f;
    Vector3 directionToTarget;
    float curInterpolationVal;
    float elapsedTime;
    [SerializeField]
    const float DELTA_ANGLE = 2;
    Quaternion targetQuarternion;
    Quaternion startQuarternion;
    private void Awake()
    {
        SetTarget();
    }
    private void Update()
    {
        //Tính toán liên tục hướng đến đích
        CalculateDirectionToTarget();
        if (IsReachTarget())
        {
            OnReachTarget();
        }
        //Điểu chỉnh hướng đến khi trùng với hướng đến đích
        LerpDirectionToTarget();
    }
    public void OnReachTarget()
    {
        //Chuyển đến điểm đích tiếp theo
        SetTarget();
        //Tính toán lại hướng của đích và hướng hiện tại
        CalculateDirectionToTarget();
        CalculateStartTargetQuarternion();
        //Tính toán lại vận tốc và đặt lại thời gian tăng nội suy
        ResetLerpWhenReachTarget();
    }
    public void LerpDirectionToTarget()    //Xoay hướng đến điểm đích
    {
        //Tính góc giữa hướng trước mặt và hướng đến điểm đích
        float angle = Vector3.Angle(directionToTarget, transform.forward);
        if (angle < DELTA_ANGLE)
        {
            transform.forward = directionToTarget;
            return;
        }
        //Nội suy curInterpolationVal chạy từ 0 => 1 tương ứng với hướng của startQuarternion
        //đang chuyển dần thành hướng targetQuarternion
        elapsedTime += Time.deltaTime;
        curInterpolationVal = elapsedTime / rotateDuration;
        if (curInterpolationVal >= 1)
        {
            curInterpolationVal = 1;
        }
        targetQuarternion = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(startQuarternion, targetQuarternion, curInterpolationVal);
    }
    //Reset lại thời gian để tăng nội suy
    public void ResetLerpWhenReachTarget()
    {
        elapsedTime = 0;
    }
    //Tích nội hướng của 2 vector <=0 nghĩa là góc giữa 2 vector >=90%
    //Xét xem đã đến điểm đích chưa
    public bool IsReachTarget()
    {
        return Vector3.Dot(transform.forward, directionToTarget) <= 0;
    }
    public void SetTarget()
    {
        targetSlimeMove = new Vector3(Random.Range(72f, 78f), transform.position.y, Random.Range(82f, 88f));
    }
    public void CalculateStartTargetQuarternion()
    {
        startQuarternion = Quaternion.LookRotation(transform.forward);
    }
    public void CalculateDirectionToTarget()
    {
        directionToTarget = targetSlimeMove - transform.position;
    }
}
