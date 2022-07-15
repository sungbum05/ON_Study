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
public enum MoveCompleatPosition 
{
    LeftCompleat,
    RightCompleat = 2
}


public class HoneyComboPlayerDragMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Tooltip("플레이어 도착 위치 오브젝트")]
    [SerializeField] private Vector3[] playerMovePosition = new Vector3[3];
    [Tooltip("마우스 위치 판별")]
    [SerializeField] private Vector3 mousePos, readyDragMousePos;
    [Tooltip("플레이어 오브젝트")]
    [SerializeField] private GameObject playerObj;
    [Tooltip("드래그시 손가락 최소 움직임")]
    [SerializeField] private float DragMoveLength;
    private bool IsMoving;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckMousePos();
    }
    private void ReMoving()
    {
        IsMoving = false;
    }
    private void CheckMousePos()
    {
        mousePos = Input.mousePosition;
        if(Input.GetMouseButtonDown(0))
           readyDragMousePos = mousePos;
    }
        
    private IEnumerator Moving()
    {
        float targetXPos = 0;
        yield return new WaitForSeconds(0.15f);
        if (readyDragMousePos.x + DragMoveLength < mousePos.x && playerObj.transform.position.x != playerMovePosition[(int)PlayerPosition.Right].x && !IsMoving)
        {
            IsMoving = true;
            targetXPos = playerObj.transform.position.x + 1.5f;
            while (playerObj.transform.position.x <= targetXPos)
            {
                playerObj.transform.position = Vector3.Lerp(playerObj.transform.position, new Vector3(targetXPos + 0.5f, -3.8f, 0), 0.05f);
                yield return null;
            }
            playerObj.transform.position = new Vector3(targetXPos, -3.8f, 0);
            ReMoving();
        }
        else if (readyDragMousePos.x - DragMoveLength > mousePos.x && playerObj.transform.position.x != playerMovePosition[(int)PlayerPosition.Left].x && !IsMoving)
        {
            IsMoving = true;
            targetXPos = playerObj.transform.position.x - 1.5f;
            while (playerObj.transform.position.x >= targetXPos)
            {
                playerObj.transform.position = Vector3.Lerp(playerObj.transform.position, new Vector3(targetXPos - 0.5f, -3.8f, 0), 0.05f);
                yield return null;
            }
            playerObj.transform.position = new Vector3(targetXPos, -3.8f, 0);
            ReMoving();
        }
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) //드래그 시 처음 한번 호출
    {
        StartCoroutine(Moving());
    }

    void IDragHandler.OnDrag(PointerEventData eventData) //드래그하는 동안 호출
    {
     
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData) //드래그 종료 시 한번 호출
    {

    }
}
