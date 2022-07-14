using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObj : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private bool Answering, IsLeftRotation, IsReturning;
    [SerializeField] private GameObject GM;
    [Header("������Ʈ ȸ�� �ִϸ��̼� ���� ����")]
    [SerializeField] private float RotationZ;
    [SerializeField] private float RotateSpeed, MaxRotateR, MaxRotateL;
    [Header("�巡���� �Ǻ� / ������Ʈ �� �ε���")]
    public bool IsDraging;
    public bool IsWrong;
    public int ObjIndex;
    public static Vector2 defaultposition;
    [SerializeField] private Vector3 NowMousePos;
    [SerializeField] private Camera Cam;
    [Header("�� �ݶ��̴� �̸�")]
    [SerializeField] private string ColliderName;
    [Header("�������� ��ġ")]
    [SerializeField] private int StageIndex;

    [Tooltip("�巡�� ���̾� ĵ����")]
    [SerializeField] private Canvas canvas;


    private void Awake()
    {
    }

    private void FixedUpdate()
    {
        MousePos();
    }
   
    private void MousePos()
    {
        NowMousePos = Input.mousePosition;
        NowMousePos = Cam.ScreenToWorldPoint(NowMousePos) + new Vector3(0, 0, 10);
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) => defaultposition = this.transform.position;
   

    void IDragHandler.OnDrag(PointerEventData eventData)//�巡������ ��
    {
        if (!Answering && !IsReturning)
        {
            //canvas.sortingOrder = 2;
            IsDraging = true;
            transform.position = NowMousePos + new Vector3(0, 0, 10);
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)//�巡�� ������ ��
    {
        //canvas.sortingOrder = 1;
        IsReturning = true;
        Answering = true;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        IsDraging = false;
        StartCoroutine(DragEnd());
    }
    private IEnumerator DragEnd()
    {
        yield return new WaitForSeconds(0.02f);
        transform.position = defaultposition;
        IsWrong = false;
        yield return new WaitForSeconds(0.1f);
        Answering = false;
        IsReturning = false;
    }
   
}
