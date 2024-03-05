using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public bool Switch;
    private bool ReSwitch;
    private void Start()
    {
        ReSwitch = Switch;
        if(Switch)
            this.gameObject.SetActive(true);
        else
            this.gameObject.SetActive(false);
    }

    public void ChangeSwitch()
    {
        if (Switch)
        {
            Switch = false;
            this.gameObject.SetActive(false);
        }
        else
        {
            Switch = true;
            this.gameObject.SetActive(true);
        }
           
    }

    public void Reset()
    {
        Switch = ReSwitch;
        if (Switch)
            this.gameObject.SetActive(true);
        else
            this.gameObject.SetActive(false);
    }

    public void TrueSwitch()
    {
        Switch = true;
        this.gameObject.SetActive(true);
    }
    public void FalseSwitch()
    {
        Switch = false;
        this.gameObject.SetActive(true);
    }
}
