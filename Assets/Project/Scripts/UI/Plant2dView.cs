using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant2dView : MonoBehaviour
{    
    [SerializeField] private Image m_Image;
    public Image Image => m_Image;
    [SerializeField]  private Button m_Button;
    public Button Button => m_Button; 
}
