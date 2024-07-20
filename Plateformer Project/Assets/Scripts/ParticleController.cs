using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;
    [SerializeField] ParticleSystem jumpParticle;
    [SerializeField] ParticleSystem myParticle;

    // �÷��̾��� �ӵ��� ���� ��ƼŬ�� �����ϴ� ���� ����
    [SerializeField] int occurAfterVelocity;
    // ������ ���� �ֱ�
    [Range(0, 0.3f)]
    [SerializeField] float dustFormationTime;

    [SerializeField] Rigidbody2D playerRb;
    float counter; // ������ ���� �ֱ⸦ üũ�ϱ� ���� �ð� ����
    bool isGround; // �÷��̾��� ���� ���¸� üũ�ϱ� ���� ����

    private void Update()
    {
        CheckAfterVelocity();        
    }

    public void PlayParticle()
    {
        myParticle.Play();
        if (AudioManager.instance == null)
        {
            Debug.LogWarning($"{nameof(AudioManager)}�� instance�� �����ϴ�");
            return;
        }
        AudioManager.instance.PlaySFX(6);
        
    }
    private void CheckAfterVelocity()
    {
        counter += Time.deltaTime;
        if (isGround && Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity)
        {
            CheckDustFormation();
        }
    }

    private void CheckDustFormation()
    {
        if (counter > dustFormationTime)
        {
            movementParticle.Play();
            counter = 0;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            jumpParticle.Play();
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
