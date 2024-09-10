using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public GameObject beamPrefab;        // ビームのプレハブ
    public Transform beamSpawnPoint;     // ビームの発射位置
    public float beamSpeed = 10f;        // ビームの速度
    public float maxBeamDistance = 20f;  // ビームの最大距離
    public float fireRate = 0.5f;        // ビームを発射する間隔（秒）

    private void Start()
    {
        // ビームを定期的に発射するコルーチンを開始
        StartCoroutine(FireBeamContinuously());
    }

    private IEnumerator FireBeamContinuously()
    {
        while (true)
        {
            FireBeam();
            yield return new WaitForSeconds(fireRate); // 指定した間隔で発射
        }
    }

    void FireBeam()
    {
        // ビームを生成し、初期位置と向きを設定
        GameObject currentBeam = Instantiate(beamPrefab, beamSpawnPoint.position, beamSpawnPoint.rotation);
        currentBeam.GetComponent<Rigidbody2D>().velocity = beamSpawnPoint.up * beamSpeed;

        // 一定距離を超えたらビームを削除
        //Destroy(currentBeam, maxBeamDistance / beamSpeed);
    }
}
