using EventManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button m_ButtonStart;

    [SerializeField] private Slider m_WidthSlider;
    [SerializeField] private Slider m_HeightSlider;

    private void Start()
    {

        m_ButtonStart.onClick.AddListener(ButtonStartClicked);
    }

    private void ButtonStartClicked()
    {
        gameObject.SetActive(false);
        EventManager.EventManager.SendMessage(new StartGameMessage((int)m_HeightSlider.value, (int)m_WidthSlider.value));
    }

}
