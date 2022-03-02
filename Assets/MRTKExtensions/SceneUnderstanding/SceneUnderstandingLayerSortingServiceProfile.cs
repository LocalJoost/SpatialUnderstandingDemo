using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Utilities;

namespace MRTKExtensions.SceneUnderstanding
{
	[MixedRealityServiceProfile(typeof(ISceneUnderstandingLayerSortingService))]
	[CreateAssetMenu(fileName = "SceneUnderstandingLayerSortingServiceProfile", 
		menuName = "Mixed Reality Toolkit/Profiles/Scene Understanding LayerSortingService Configuration Profile", 
		order = (int)CreateProfileMenuItemIndices.SceneUnderstandingObserver)]
	public class SceneUnderstandingLayerSortingServiceProfile : BaseMixedRealityProfile
	{
		[SerializeField]
		private List<SpatialUnderstandingLayer> layerAssignment;

		public List<SpatialUnderstandingLayer> LayerAssignment => layerAssignment;
	}
}