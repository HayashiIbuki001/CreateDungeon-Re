using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public BlockPlacement blockPlacement; // BlockPlacementスクリプトへの参照
    private Vector3 checkpointPosition; // 最後に設定されたチェックポイントの位置

    // 効果音のAudioSourceとAudioClipを追加
    public AudioSource audioSource; // AudioSourceコンポーネント
    public AudioClip retrySound; // リトライ時の効果音

    void Start()
    {
        checkpointPosition = Vector3.zero; // 初期状態ではチェックポイントが設定されていない
    }

    void Update()
    {
        // スペースキーを押したときにチェックポイントにテレポート
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TeleportToCheckpoint();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            // チェックポイントの位置を設定
            checkpointPosition = other.transform.position;

            // チェックポイントの名前と位置をデバッグログに表示
            Debug.Log($"{other.gameObject.name} checked!");

            // チェックポイントオブジェクトを削除する場合
            // Destroy(other.gameObject);
        }
    }

    // チェックポイントにテレポートするメソッド
    public void TeleportToCheckpoint()
    {
        if (checkpointPosition != Vector3.zero)
        {
            // プレイヤーの位置をチェックポイントに変更
            transform.position = checkpointPosition;

            // プレイヤーが設置したブロックを消去
            if (blockPlacement != null)
            {
                blockPlacement.ClearBlocks();
            }

            // 効果音を再生
            if (audioSource != null && retrySound != null)
            {
                audioSource.PlayOneShot(retrySound);
            }
        }
    }
}
