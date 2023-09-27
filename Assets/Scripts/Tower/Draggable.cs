using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition;
    private Tower tower;
    public GameObject towerPrefab; // Tower ���� ������Ʈ�� ������

    void Start()
    {
        tower = GetComponent<Tower>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Ŭ��");
        originalPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f); // Z �� ���� 0���� ����
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Tower otherTower = CanMergeWithOtherTower();

        if (otherTower != null)
            MergeWithOthertower(otherTower);
        else
            transform.position = originalPosition; // ���� ��ġ�� ���ư��ϴ�.
    }

    Tower CanMergeWithOtherTower()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);

        foreach (var collider in colliders)
        {
            Tower otherTower = collider.GetComponent<Tower>();

            if (otherTower != null && otherTower.towerData == tower.towerData && otherTower.level == tower.level)
                return otherTower; // ��ĥ �� �ִ� ������ �Ӽ� �� ������ Ÿ���� �ִٸ� �ش� Ÿ���� ��ȯ�մϴ�.
        }

        return null; // ��ĥ �� �ִ� ������ �Ӽ� �� ������ Ÿ���� ���ٸ� null�� ��ȯ�մϴ�.
    }

    void MergeWithOthertower(Tower othertower)
    {
        GameObject newtowerObject = Instantiate(towerPrefab, transform.position, Quaternion.identity);
        Tower newtowerSpawner = newtowerObject.GetComponent<Tower>();

        if (newtowerSpawner != null)
        {
            Destroy(othertower.gameObject);   // ������ġ�� �ִ� ���յ� ���ž ���� 
            Destroy(gameObject);  // �巡�� ���� ��������Ʈ�� ����ž ���� 

            newtowerSpawner.level = tower.level + 1;   // ���յ� ������� ���� �������� �Ѵܰ� ��� 
        }
    }
}
