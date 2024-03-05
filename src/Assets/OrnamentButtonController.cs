using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnamentButtonController : MonoBehaviour
{
   
    [SerializeField] private ObstacleController obstacleController;
    private void OnTriggerStay(Collider other)
    {
        if (other == null)
            obstacleController.TrueSwitch();
        else
           obstacleController.FalseSwitch();
    }
}
