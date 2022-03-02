#if UNITY_EDITOR
using System;
using Microsoft.MixedReality.Toolkit.Editor;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using UnityEditor;

namespace MRTKExtensions.SceneUnderstanding.Editor
{	
	[MixedRealityServiceInspector(typeof(ISceneUnderstandingLayerSortingService))]
	public class SceneUnderstandingLayerSortingServiceInspector : BaseMixedRealityServiceInspector
	{
		public override void DrawInspectorGUI(object target)
		{
			SceneUnderstandingLayerSortingService service = (SceneUnderstandingLayerSortingService)target;
			
			// Draw inspector here
		}
	}
}

#endif