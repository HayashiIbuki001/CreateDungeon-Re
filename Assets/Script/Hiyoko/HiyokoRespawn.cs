using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiyokoRespawn : MonoBehaviour
{
    public GameObject hiyokoPrefab; // �Ђ悱�̃v���n�u
    public Transform respawnPoint;  // �`�F�b�N�|�C���g�̈ʒu

    public void Respawn()
    {
        // ���݂̂Ђ悱���폜�܂��͔�\���ɂ���
        Destroy(gameObject);

        // �V�����Ђ悱���C���X�^���X������
        GameObject newHiyoko = Instantiate(hiyokoPrefab, respawnPoint.position, respawnPoint.rotation);

        // �K�v�ɉ����ď����̈ړ�������ݒ�
        HiyokoMove hiyokoMove = newHiyoko.GetComponent<HiyokoMove>();
        if (hiyokoMove != null)
        {
            //hiyokoMove.SetInitialDirection(Vector2.right); // �E�����ɕ����悤�ɐݒ�
        }
    }
}