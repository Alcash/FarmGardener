using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCounterView : MonoBehaviour
{
    [SerializeField] private Image m_Image;
    public Image Image => m_Image;
    [SerializeField] private Text m_Text;
    public Text Text => m_Text;

}
