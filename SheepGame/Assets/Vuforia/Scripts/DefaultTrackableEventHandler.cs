/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS
		public MazeTimer mazeTimerScript;
		public CollectTimer collectTimerScript;
		public CarrotTimer carrotTimerScript;
		public CropTimer2 cropTimerScript;
		public SpawnPointsController spawnScript;
		public BullTimer bullTimerScript;
		//public DuckTimer duckTimerScript;

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			Terrain[] terrainComponents = GetComponentsInChildren<Terrain> (true);

			foreach( Terrain component in terrainComponents)
			{
					component.enabled = true;
			}

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
			try {
			mazeTimerScript.activate();
			}
			catch {
			}
			try {
			collectTimerScript.activate();
			}
			catch {
			}
			try {
			carrotTimerScript.activate();
			}
			catch {
			}
			try {
			cropTimerScript.activate();
			}
			catch {
			}
			try {
			spawnScript.activate();
			bullTimerScript.activate();
			}
			catch {
			}
			/*try {
			duckTimerScript.activate();
			}
			catch {
			}*/
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			Terrain[] terrainComponents = GetComponentsInChildren<Terrain> (true);

			foreach (Terrain component in terrainComponents) {
				component.enabled = false;
			}
			
            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
			if (mTrackableBehaviour.TrackableName == "bull") {
				spawnScript.deactivate ();
			}
        }

        #endregion // PRIVATE_METHODS
    }
}
