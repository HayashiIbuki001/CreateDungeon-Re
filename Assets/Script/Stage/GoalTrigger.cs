using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GoalTrigger : MonoBehaviour
{
    public float timeToReturnToTitle = 2f; // タイトルに戻るまでの待機時間
    public GameObject player; // プレイヤーオブジェクトの参照
    public Text stageClearText; // "Stage Clear!" メッセージ用の UI テキスト

    // ゴール時の効果音のAudioSourceとAudioClipを追加
    public AudioSource audioSource; // AudioSourceコンポーネント
    public AudioClip goalSound; // ゴール時の効果音

    // ゴール時のBGM用のAudioSourceとAudioClipを追加
    public AudioSource bgmSource; // BGM用のAudioSource
    public AudioClip goalBGM; // ゴール時のBGM

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
        // ゴール時の効果音を再生
        if (audioSource != null && goalSound != null)
        {
            audioSource.PlayOneShot(goalSound);
        }

        // ゴール時のBGMを再生
        if (bgmSource != null && goalBGM != null)
        {
            bgmSource.Stop(); // 既存のBGMを停止
            bgmSource.clip = goalBGM;
            bgmSource.Play();
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
