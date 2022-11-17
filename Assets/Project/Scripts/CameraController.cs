using EventManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera m_MainCamera;

    [SerializeField] private TransformValues m_NearView;
    [SerializeField] private TransformValues m_DefautlValues;
    [SerializeField] private Transform m_DefaultTarget;

    private bool _isDefaultView;

    private Coroutine _coroutine;

    void Start()
    {
        m_MainCamera = Camera.main;
        m_MainCamera.transform.localPosition = m_DefautlValues.Position;
        m_MainCamera.transform.localRotation = m_DefautlValues.Rotation;
    }

    private void OnEnable()
    {
        EventManager.EventManager.SubscribeMessage(typeof(FarmCellPlantedMessage), NearView);
    }

    private void OnDisable()
    {
        EventManager.EventManager.UnSubscribeMessage(typeof(FarmCellPlantedMessage), NearView);
    }

    private void NearView(IEventMessage eventMessage)
    {
        if(eventMessage is FarmCellPlantedMessage plantedMessage)
        {
            if(_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            StartCoroutine(SmoothShowNearView(plantedMessage.Cell.transform));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_isDefaultView)
        {
            transform.position = m_DefaultTarget.position;
        }
    }

    private IEnumerator SmoothShowNearView(Transform viewTransform)
    {
        float lerpValue = 0;

        var startPosition = transform.position;
        _isDefaultView = false;
        while (lerpValue <= 1 )
        {
            lerpValue += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, viewTransform.position, lerpValue);
            m_MainCamera.transform.localPosition = Vector3.Lerp(m_DefautlValues.Position, m_NearView.Position, lerpValue);
            m_MainCamera.transform.localRotation = Quaternion.Lerp(m_DefautlValues.Rotation, m_NearView.Rotation, lerpValue);
            yield return null;
        }

        lerpValue = 1;
        while (lerpValue > 0)
        {
            lerpValue -= Time.deltaTime;
            transform.position = Vector3.Lerp(m_DefaultTarget.position, viewTransform.position, lerpValue);
            m_MainCamera.transform.localPosition = Vector3.Lerp(m_DefautlValues.Position, m_NearView.Position, lerpValue);
            m_MainCamera.transform.localRotation = Quaternion.Lerp(m_DefautlValues.Rotation, m_NearView.Rotation, lerpValue);
            yield return null;
        }        
        yield return null;
        _isDefaultView = true;
    }
    
}

[Serializable]
public struct TransformValues
{
    public Vector3 Position;
    public Quaternion Rotation;
}
