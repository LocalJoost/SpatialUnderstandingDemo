using System.Linq;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Experimental.SpatialAwareness;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace MRTKExtensions.SceneUnderstanding
{
	[MixedRealityExtensionService(SupportedPlatforms.WindowsUniversal)]
	public class SceneUnderstandingLayerSortingService : BaseExtensionService, ISceneUnderstandingLayerSortingService
	{
		private readonly SceneUnderstandingLayerSortingServiceProfile sceneUnderstandingLayerSortingServiceProfile;

		public SceneUnderstandingLayerSortingService(string name,  uint priority,  BaseMixedRealityProfile profile) : base(name, priority, profile) 
		{
			sceneUnderstandingLayerSortingServiceProfile = (SceneUnderstandingLayerSortingServiceProfile)profile;
		}

		public override void Initialize()
		{
			base.Initialize();
			RegisterEventHandlers();
		}
		
		public override void Enable()
		{
			base.Enable();
			RegisterEventHandlers();
		}

		public override void Disable()
		{
			UnregisterEventHandlers();
			base.Disable();
		}

		public override void Destroy()
		{
			UnregisterEventHandlers();
			base.Destroy();
		}

		public void OnObservationAdded(MixedRealitySpatialAwarenessEventData<SpatialAwarenessSceneObject> eventData)
		{
			var layerAssignment = sceneUnderstandingLayerSortingServiceProfile.LayerAssignment.FirstOrDefault(
				p => p.SurfaceType == eventData.SpatialObject.SurfaceType);
			if (layerAssignment != null)
			{
				eventData.SpatialObject.GameObject.transform.SetLayerRecursively(layerAssignment.Layer);
				if (layerAssignment.DisplayMaterial != null)
				{
					foreach (var renderer in eventData.SpatialObject.GameObject.GetComponentsInChildren<Renderer>())
					{
						renderer.material = layerAssignment.DisplayMaterial;
					}
				}
			}
		}

		public void OnObservationUpdated(MixedRealitySpatialAwarenessEventData<SpatialAwarenessSceneObject> eventData)
		{
		}

		public void OnObservationRemoved(MixedRealitySpatialAwarenessEventData<SpatialAwarenessSceneObject> eventData)
		{
		}

		private void RegisterEventHandlers()
		{
			RegisterEventHandlers<ISceneUnderstandingLayerSortingService, SpatialAwarenessSceneObject>();
		}

		private void UnregisterEventHandlers()
		{
			UnregisterEventHandlers<ISceneUnderstandingLayerSortingService, SpatialAwarenessSceneObject>();
		}
		
		// Code below nicked from DemoSpatialMeshHandler
		
		private bool isRegistered;
		
		/// <summary>
		/// Registers for the spatial awareness system events.
		/// </summary>
	private void RegisterEventHandlers<T, TU>()
		where T : IMixedRealitySpatialAwarenessObservationHandler<TU>
		where TU : BaseSpatialAwarenessObject
	{
		if (!isRegistered && CoreServices.SpatialAwarenessSystem != null)
		{
			CoreServices.SpatialAwarenessSystem.RegisterHandler<T>(this);
			isRegistered = true;
		}
	}

		/// <summary>
		/// Unregisters from the spatial awareness system events.
		/// </summary>
		private void UnregisterEventHandlers<T, TU>()
			where T : IMixedRealitySpatialAwarenessObservationHandler<TU>
			where TU : BaseSpatialAwarenessObject
		{
			if (isRegistered && CoreServices.SpatialAwarenessSystem != null)
			{
				CoreServices.SpatialAwarenessSystem.UnregisterHandler<T>(this);
				isRegistered = false;
			}
		}
	}
}
