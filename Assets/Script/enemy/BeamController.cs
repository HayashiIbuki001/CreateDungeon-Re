using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public GameObject beamPrefab;        // �r�[���̃v���n�u
    public Transform beamSpawnPoint;     // �r�[���̔��ˈʒu
    public float beamSpeed = 10f;        // �r�[���̑��x
    public float maxBeamDistance = 20f;  // �r�[���̍ő勗��

    private GameObject currentBeam;      // ���݂̃r�[��

    void Start()
    {
        FireBeam();  // �ŏ��Ƀr�[���𔭎�
    }

    void Update()
    {
        // �r�[�������݂��Ȃ��ꍇ�A�V���ɔ���
        if (currentBeam == null)
        {
            FireBeam();
        }
    }

    void FireBeam()
    {
        // �r�[���𐶐����A�����ʒu�ƌ�����ݒ�
        currentBeam = Instantiate(beamPrefab, beamSpawnPoint.position, beamSpawnPoint.rotation);

        // ���˕����� beamSpawnPoint �̌����ɍ��킹��
        Vector2 fireDirection = beamSpawnPoint.up; // up�������g�p����
        currentBeam.GetComponent<Rigidbody2D>().velocity = fireDirection * beamSpeed;

        // ��苗���𒴂�����r�[�����폜
        Destroy(currentBeam, maxBeamDistance / beamSpeed);
    }
}
