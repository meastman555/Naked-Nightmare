using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSorting : MonoBehaviour
{

    private Renderer myRend;
    [SerializeField]
    private int sortingOrderBase = 500;
    [SerializeField]
    private int offset = 0;
    [SerializeField]
    private bool runOnlyOnce = false;

    private void Awake()
    {
        myRend = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        myRend.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
        if(runOnlyOnce)
        {
            Destroy(this);
        }
    }

}
