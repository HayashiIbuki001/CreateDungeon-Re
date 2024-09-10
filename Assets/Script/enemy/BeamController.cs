using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public GameObject beamPrefab;        // �r�[���̃v���n�u
    public Transform beamSpawnPoint;     // �r�[���̔��ˈʒu
    public float beamSpeed = 10f;        // �r�[���̑��x
    public float maxBeamDistance = 20f;  // �r�[���̍ő勗��
    public float fireRate = 0.5f;        // �r�[���𔭎˂���Ԋu�i�b�j

    private void Start()
    {
        // �r�[�������I�ɔ��˂���R���[�`�����J�n
        StartCoroutine(FireBeamContinuously());
    }

    private IEnumerator FireBeamContinuously()
    {
        while (true)
        {
            FireBeam();
            yield return new WaitForSeconds(fireRate); // �w�肵���Ԋu�Ŕ���
        }
    }

    void FireBeam()
    {
        // �r�[���𐶐����A�����ʒu�ƌ�����ݒ�
        GameObject currentBeam = Instantiate(beamPrefab, beamSpawnPoint.position, beamSpawnPoint.rotation);
        currentBeam.GetComponent<Rigidbody2D>().velocity = beamSpawnPoint.up * beamSpeed;

        // ��苗���𒴂�����r�[�����폜
        //Destroy(currentBeam, maxBeamDistance / beamSpeed);
    }
}
