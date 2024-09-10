using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GoalTrigger2 : MonoBehaviour
{
    public float timeToReturnToTitle = 2f; // �^�C�g���ɖ߂�܂ł̑ҋ@����
    public GameObject player; // �v���C���[�I�u�W�F�N�g�̎Q��
    public Text stageClearText; // "Stage Clear!" ���b�Z�[�W�p�� UI �e�L�X�g�i�蓮�ŃA�^�b�`�j
    public AudioClip goalSound; // �S�[�����ɍĐ�������ʉ�
    public AudioClip goalSound2; // �ǉ��̃S�[�����ʉ�
    public AudioSource audioSource; // ���ʉ��Đ��p�� AudioSource
    public AudioSource bgmAudioSource; // BGM�Đ��p�� AudioSource

    private void Start()
    {
        // Player�ɂ�Hiyoko�I�u�W�F�N�g���A�^�b�`
        if (player == null)
        {
            player = GameObject.Find("Hiyoko"); // Hiyoko�I�u�W�F�N�g�𖼑O�ŒT��
            if (player == null) Debug.LogWarning("Player (Hiyoko) ��������܂���ł����B");
        }

        // BGMAudioSource�ɂ�BGMManager�I�u�W�F�N�g���A�^�b�`
        if (bgmAudioSource == null)
        {
            GameObject bgmManager = GameObject.Find("BGMManager");
            if (bgmManager != null)
            {
                bgmAudioSource = bgmManager.GetComponent<AudioSource>();
                if (bgmAudioSource == null)
                {
                    Debug.LogWarning("BGMManager �� AudioSource �R���|�[�l���g��������܂���ł����B");
                }
            }
            else
            {
                Debug.LogWarning("BGMManager �I�u�W�F�N�g��������܂���ł����B");
            }
        }

        // AudioSource�����ݒ�̏ꍇ�A����GameObject����擾
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null) Debug.LogWarning("AudioSource �R���|�[�l���g��������܂���ł����B");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�S�[��������");
            StartCoroutine(GoalReachedCoroutine());
        }
    }

    private IEnumerator GoalReachedCoroutine()
    {
        // BGM���~
        if (bgmAudioSource != null)
        {
            bgmAudioSource.Stop();
        }

        // �S�[�����̌��ʉ����Đ�
        if (audioSource != null && goalSound != null)
        {
            audioSource.PlayOneShot(goalSound);
            audioSource.PlayOneShot(goalSound2);
        }

        // "Stage Clear!" ���b�Z�[�W��\������
        if (stageClearText != null)
        {
            stageClearText.text = "Stage Clear!";
            stageClearText.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("StageClearText ���ݒ肳��Ă��܂���B");
        }

        // �v���C���[���~�߂�
        if (player != null)
        {
            var playerMovement = player.GetComponent<HiyokoMove>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false; // �v���C���[�̈ړ��𖳌���
            }
            var playerAnimator = player.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.enabled = false; // �v���C���[�̃A�j���[�V�����𖳌���
            }
        }

        yield return new WaitForSeconds(timeToReturnToTitle); // �w�肵�����ԑҋ@

        // �^�C�g���V�[���ɖ߂�
        SceneManager.LoadScene("TitleScene");
    }
}
