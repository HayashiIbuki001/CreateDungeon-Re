using UnityEngine;

public class BeamCollision : GameOverTrigger
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // �r�[������Q���i�u���b�N��ǁj�ɓ��������ꍇ�A�r�[�����폜
        if (collision.CompareTag("Obstacles"))
        {
            Destroy(gameObject); // �r�[�����폜
        }
        // �r�[�����Ђ悱�ɓ��������ꍇ�A�Q�[���I�[�o�[
        else if (collision.CompareTag("Player"))
        {
            GameOver();
        }
    }
}
