using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHPService : MonoBehaviour
{
    public static PHPService Self;

    void Awake()
    {
        Self = this;
    }

}
