using UnityEngine;

public class Dot : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // ��������Ʈ ������

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetColor(Color color)
    {
        // ���� ����
        spriteRenderer.color = color;
    }

    public void SetLocalPosition(Vector3 localPosition)
    {
        // ���� ��ġ ����
        transform.localPosition = localPosition;
    }

    public void SetActive(bool active)
    {
        // Ȱ��/��Ȱ�� ���� ����
        gameObject.SetActive(active);
    }
}
