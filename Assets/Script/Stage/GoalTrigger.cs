using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GoalTrigger : MonoBehaviour
{
    public float timeToReturnToTitle = 2f; // �^�C�g���ɖ߂�܂ł̑ҋ@����
    public GameObject player; // �v���C���[�I�u�W�F�N�g�̎Q��
    public Text stageClearText; // "Stage Clear!" ���b�Z�[�W�p�� UI �e�L�X�g

    // �S�[�����̌��ʉ���AudioSource��AudioClip��ǉ�
    public AudioSource audioSource; // AudioSource�R���|�[�l���g
    public AudioClip goalSound; // �S�[�����̌��ʉ�

    // �S�[������BGM�p��AudioSource��AudioClip��ǉ�
    public AudioSource bgmSource; // BGM�p��AudioSource
    public AudioClip goalBGM; // �S�[������BGM

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
        // �S�[�����̌��ʉ����Đ�
        if (audioSource != null && goalSound != null)
        {
            audioSource.PlayOneShot(goalSound);
        }

        // �S�[������BGM���Đ�
        if (bgmSource != null && goalBGM != null)
        {
            bgmSource.Stop(); // ������BGM���~
            bgmSource.clip = goalBGM;
            bgmSource.Play();
        }

        // "Stage Clear!" ���b�Z�[�W��\������
        if (stageClearText != null)
        {
            stageClearText.text = "Stage Clear!";
            stageClearText.gameObject.SetActive(true);
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
