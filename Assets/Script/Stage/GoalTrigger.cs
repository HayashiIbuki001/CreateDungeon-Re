using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GoalTrigger : MonoBehaviour
{
    public float timeToReturnToTitle = 2f; // タイトルに戻るまでの待機時間
    public GameObject player; // プレイヤーオブジェクトの参照
    public Text stageClearText; // "Stage Clear!" メッセージ用の UI テキスト
    public AudioClip goalSound; // ゴール時に再生する効果音
    public AudioClip goalSound2;
    public AudioSource audioSource; // 効果音再生用の AudioSource
    public AudioSource bgmAudioSource; // BGM再生用の AudioSource

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
        // BGMを停止
        if (bgmAudioSource != null)
        {
            bgmAudioSource.Stop();
        }

        // ゴール時の効果音を再生
        if (audioSource != null && goalSound != null)
        {
            audioSource.PlayOneShot(goalSound);
            audioSource.PlayOneShot(goalSound2);
        }

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
