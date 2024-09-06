using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public BlockPlacement blockPlacement; // BlockPlacement�X�N���v�g�ւ̎Q��
    private Vector3 checkpointPosition; // �Ō�ɐݒ肳�ꂽ�`�F�b�N�|�C���g�̈ʒu

    void Start()
    {
        checkpointPosition = Vector3.zero; // ������Ԃł̓`�F�b�N�|�C���g���ݒ肳��Ă��Ȃ�
    }

    void Update()
    {
        // �X�y�[�X�L�[���������Ƃ��Ƀ`�F�b�N�|�C���g�Ƀe���|�[�g
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TeleportToCheckpoint();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            // �`�F�b�N�|�C���g�̈ʒu��ݒ�
            checkpointPosition = other.transform.position;

            // �`�F�b�N�|�C���g�̖��O�ƈʒu���f�o�b�O���O�ɕ\��
            Debug.Log($"{other.gameObject.name} checked!");

            // �`�F�b�N�|�C���g�I�u�W�F�N�g���폜����ꍇ
            // Destroy(other.gameObject);
        }
    }

    // �`�F�b�N�|�C���g�Ƀe���|�[�g���郁�\�b�h
    void TeleportToCheckpoint()
    {
        if (checkpointPosition != Vector3.zero)
        {
            // �v���C���[�̈ʒu���`�F�b�N�|�C���g�ɕύX
            transform.position = checkpointPosition;

            // �v���C���[���ݒu�����u���b�N������
            if (blockPlacement != null)
            {
                blockPlacement.ClearBlocks();
            }
        }
    }
}
