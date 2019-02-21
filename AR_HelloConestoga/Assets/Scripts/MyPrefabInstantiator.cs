using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MyPrefabInstantiator : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public Transform myModelPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
    void Update()
    {
    }
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {

        if(newStatus == TrackableBehaviour.Status.DETECTED || 
           newStatus == TrackableBehaviour.Status.TRACKED || 
           newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
    }

    private void OnTrackingFound()
    {

        if(myModelPrefab != null)
        {
            Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;
            myModelTrf.parent = mTrackableBehaviour.transform;
            myModelTrf.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            myModelTrf.localRotation = Quaternion.identity;
            myModelTrf.localScale = new Vector3(0.0005f, 0.0005f, 0.0005f);
            myModelTrf.gameObject.active = true;
        }
    }
}
