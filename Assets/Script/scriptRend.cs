using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptRend : MonoBehaviour
{
    public enum Obs { 
        rendFora, rendDentro
    }

    public Obs obsType;

    private void Update()
    {
        if((int) obsType == 0)
        {
            this.gameObject.transform.Rotate(0f, 0f, this.gameObject.transform.rotation.z + 10, Space.World);        
        }
        else if ((int) obsType == 1)
        {
            this.gameObject.transform.Rotate(0f, 0f, this.gameObject.transform.rotation.z - 10, Space.World);
        }
    }

}
