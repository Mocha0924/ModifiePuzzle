using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<ObstacleController> obstacleControllers = new List<ObstacleController>();
    [SerializeField] private Camera mainCamera;
    PlayerController playerController => PlayerController.instance;


    

    private void ButtonPush()
    {
        foreach (ObstacleController controller in obstacleControllers) 
        {
            controller.ChangeSwitch();
        }
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"&&!playerController.CreateMode)
            ButtonPush();

    }

    public void Createpos()
    {
        var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 388);

        Vector3 currentPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        transform.position = currentPosition;
    }

   

   
    public void OnPointerClick(PointerEventData eventData)
    {
        print($"オブジェクト {name} がクリックされたよ！");
    }
}
