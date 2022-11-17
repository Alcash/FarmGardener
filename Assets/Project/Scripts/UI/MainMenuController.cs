using EventManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button m_ButtonStart;

    [SerializeField] private Slider m_WidthSlider;
    [SerializeField] private Slider m_HeightSlider;

    [SerializeField] private Text m_WidthText;
    [SerializeField] private Text m_HeightText;

    private void Start()
    {

        m_ButtonStart.onClick.AddListener(ButtonStartClicked);
        m_WidthSlider.onValueChanged.AddListener(SliderWidthChangeValue);
        m_HeightSlider.onValueChanged.AddListener(SliderHeightChangeValue);
        m_HeightText.text = m_HeightSlider.value.ToString();
        m_WidthText.text = m_WidthSlider.value.ToString();
        
    }

    private void SliderHeightChangeValue(float value)
    {
        m_HeightText.text = value.ToString();
    }

    private void SliderWidthChangeValue(float value)
    {
        m_WidthText.text = value.ToString();
    }

    private void ButtonStartClicked()
    {
        gameObject.SetActive(false);
        EventManager.EventManager.SendMessage(new StartGameMessage((int)m_HeightSlider.value, (int)m_WidthSlider.value));
    }

   

    

}
