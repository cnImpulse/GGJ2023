using UnityEngine;

public class CameraFollw : MonoBehaviour
{

    // ��Ҫ�����Ŀ�����
    public Transform target;

    // ��Ҫ���������꣨����ʵʱ��Ч��
    public bool freazeX, freazeY, freazeZ;

    // �����ƽ��ʱ�䣨�������ͺ�ʱ�䣩
    public float smoothTime = 0.3F;
    private float xVelocity, yVelocity, zVelocity = 0.0F;

    // �����ƫ����
    private Vector3 offset;

    // ȫ�ֻ����λ�ñ���
    private Vector3 oldPosition;

    // ��¼��ʼλ��
    private Vector3 startPosition;

    void Start()
    {
        transform.position = target.position;
        offset = Vector3.zero;
    }

    void LateUpdate()
    {
        oldPosition = transform.position;

        if (!freazeX)
        {
            oldPosition.x = Mathf.SmoothDamp(transform.position.x, target.position.x + offset.x, ref xVelocity, smoothTime);
        }

        if (!freazeY)
        {
            oldPosition.y = Mathf.SmoothDamp(transform.position.y, target.position.y + offset.y, ref yVelocity, smoothTime);
        }

        if (!freazeZ)
        {
            oldPosition.z = -10f;
        }

        transform.position = oldPosition;
    }

    /// <summary>
    /// �������¿�ʼ��Ϸʱֱ���������λ��
    /// </summary>
    public void ResetPosition()
    {
        target.position = target.position;
        
    }
}