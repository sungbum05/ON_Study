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


public class HoneyComboPlayer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Camera cam;
    [SerializeField] private Vector3[] playerMovePosition = new Vector3[3];
    [SerializeField] private Vector3 mousePos;
    [SerializeField] private Vector3 readyDragMousePos;
    [SerializeField] private GameObject playerObj;
    public bool IsMoving;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        //mousePos = cam.WorldToScreenPoint(mousePos);                  
    }
    private IEnumerator Moving()
    {
        float targetXPos = 0;
        if (readyDragMousePos.x < mousePos.x && playerObj.transform.position.x != playerMovePosition[(int)PlayerPosition.Right].x && !IsMoving)
        {
            IsMoving = true;
            targetXPos = playerObj.transform.position.x + 1.5f;
            while (playerObj.transform.position.x <= targetXPos)
            {
                print("실행");
                playerObj.transform.position = Vector3.Lerp(playerObj.transform.position, new Vector3(targetXPos + 0.5f, -3.8f, 0), 0.005f);
                yield return null;
            }
            playerObj.transform.position = new Vector3(targetXPos, -3.8f, 0);
            ReMoving();
        }
        else if (readyDragMousePos.x > mousePos.x && playerObj.transform.position.x != playerMovePosition[(int)PlayerPosition.Left].x && !IsMoving)
        {
            IsMoving = true;
            targetXPos = playerObj.transform.position.x - 1.5f;
            while (playerObj.transform.position.x >= targetXPos)
            {
                print("실행");
                playerObj.transform.position = Vector3.Lerp(playerObj.transform.position, new Vector3(targetXPos - 0.5f, -3.8f, 0), 0.005f);
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
