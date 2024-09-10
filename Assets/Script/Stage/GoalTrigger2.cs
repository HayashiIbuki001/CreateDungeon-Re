using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GoalTrigger2 : MonoBehaviour
{
    public float timeToReturnToTitle = 2f; // タイトルに戻るまでの待機時間
    public GameObject player; // プレイヤーオブジェクトの参照
    public Text stageClearText; // "Stage Clear!" メッセージ用の UI テキスト（手動でアタッチ）
    public AudioClip goalSound; // ゴール時に再生する効果音
    public AudioClip goalSound2; // 追加のゴール効果音
    public AudioSource audioSource; // 効果音再生用の AudioSource
    public AudioSource bgmAudioSource; // BGM再生用の AudioSource

    private void Start()
    {
        // PlayerにはHiyokoオブジェクトをアタッチ
        if (player == null)
        {
            player = GameObject.Find("Hiyoko"); // Hiyokoオブジェクトを名前で探す
            if (player == null) Debug.LogWarning("Player (Hiyoko) が見つかりませんでした。");
        }

        // BGMAudioSourceにはBGMManagerオブジェクトをアタッチ
        if (bgmAudioSource == null)
        {
            GameObject bgmManager = GameObject.Find("BGMManager");
            if (bgmManager != null)
            {
                bgmAudioSource = bgmManager.GetComponent<AudioSource>();
                if (bgmAudioSource == null)
                {
                    Debug.LogWarning("BGMManager に AudioSource コンポーネントが見つかりませんでした。");
                }
            }
            else
            {
                Debug.LogWarning("BGMManager オブジェクトが見つかりませんでした。");
            }
        }

        // AudioSourceが未設定の場合、同じGameObjectから取得
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null) Debug.LogWarning("AudioSource コンポーネントが見つかりませんでした。");
        }
    }

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
        else
        {
            Debug.LogWarning("StageClearText が設定されていません。");
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
