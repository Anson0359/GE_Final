using UnityEngine;
using System.Collections;


public class CameraFollow : MonoBehaviour
{
    [Header("相機設定")]
    [SerializeField] private Transform target;  // 要跟隨的物件
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);

    [Header("地圖邊界")]
    [SerializeField] private Vector2 minBounds = new Vector2(-12,-18); // 左下角
    [SerializeField] private Vector2 maxBounds = new Vector2(12, 6); // 右上角

    private float camHalfHeight;
    private float camHalfWidth;

    #region Mono
    void Start()
    {
        Camera cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = cam.aspect * camHalfHeight;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // 限制邊界（Clamp）
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
    #endregion

    #region Function
    public void Init(Transform follow, Vector2 leftBottom, Vector2 rightUp)
    {
        target = follow;
        minBounds = leftBottom;
        maxBounds = rightUp;
    }
    #endregion
}
