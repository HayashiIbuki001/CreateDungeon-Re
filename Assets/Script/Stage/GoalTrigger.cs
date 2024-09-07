using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GoalTrigger : MonoBehaviour
{
    public float timeToReturnToTitle = 2f; // タイトルに戻るまでの待機時間
    public GameObject player; // プレイヤーオブジェクトの参照
    public Text stageClearText; // "Stage Clear!" メッセージ用の UI テキスト

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ゴールしたよ");
            StartCoroutine(GoalReachedCoroutine());
        }
    }

    private IEnumerator GoalReachedCoroutine()
    {
        // "Stage Clear!" メッセージを表示する
        if (stageClearText != null)
        {
            stageClearText.text = "Stage Clear!";
            stageClearText.gameObject.SetActive(true);
        }

        // プレイヤーを止める
        if (player != null)
        {
            var playerMovement = player.GetComponent<HiyokoMove>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false; // プレイヤーの移動を無効化
            }
            var playerAnimator = player.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.enabled = false; // プレイヤーのアニメーションを無効化
            }
        }

        yield return new WaitForSeconds(timeToReturnToTitle); // 指定した時間待機

        // タイトルシーンに戻る
        SceneManager.LoadScene("TitleScene");
    }
}
