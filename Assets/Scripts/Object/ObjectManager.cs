using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public void Visible()
    {
        this.gameObject.SetActive(true);
    }

    public void Invisible()
    {
        this.gameObject.SetActive(false);
    }
}
