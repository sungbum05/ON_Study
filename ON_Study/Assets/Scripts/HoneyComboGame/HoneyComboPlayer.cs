using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum PlayerPosition
{
    Left,
    Middle,
    Right
}

public class HoneyComboPlayer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Camera cam;
    [SerializeField] private Vector3[] playerMovePosition = new Vector3[3];
    [SerializeField] private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckMousePos();
    }
    private void CheckMousePos()
    {
        mousePos = cam.transform.position;                  
    }
    public void OnBeginDrag(PointerEventData eventData) //�巡�� �� ó�� �ѹ� ȣ��
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData) //�巡���ϴ� ���� ȣ��
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData) //�巡�� ���� �� �ѹ� ȣ��
    {
        throw new System.NotImplementedException();
    }
}
