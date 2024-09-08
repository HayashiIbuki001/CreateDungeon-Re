using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public float moveAmount = 2.0f;  // カメラの動き量
    public float moveSpeed = 5.0f;   // カメラの移動速度

    private Vector3 originalOffset;  // 元のカメラのオフセット

    void Start()
    {
        // CinemachineVirtualCameraコンポーネントの取得
        if (vcam == null)
        {
            vcam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        }

        // 初期のカメラのオフセットを保存
        originalOffset = vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
    }

    void Update()
    {
        // 現在のオフセットを取得
        Vector3 currentOffset = vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;

        // 矢印キーが押されているかをチェック
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 右矢印キーが押されているとき
            Vector3 targetOffset = originalOffset + new Vector3(moveAmount, 0, 0);
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(currentOffset, targetOffset, Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 左矢印キーが押されているとき
            Vector3 targetOffset = originalOffset - new Vector3(moveAmount, 0, 0);
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(currentOffset, targetOffset, Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // 下矢印キーが押されているとき
            Vector3 targetOffset = originalOffset - new Vector3(0, moveAmount, 0);  // Y軸方向に下げる
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(currentOffset, targetOffset, Time.deltaTime * moveSpeed);
        }
        else
        {
            // 矢印キーが押されていないときは元の位置に戻す
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(currentOffset, originalOffset, Time.deltaTime * moveSpeed);
        }
    }
}
