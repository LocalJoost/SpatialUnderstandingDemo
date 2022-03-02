using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Experimental.SpatialAwareness;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;

namespace MRTKExtensions.SceneUnderstanding
{
	public interface ISceneUnderstandingLayerSortingService : IMixedRealityExtensionService,
		IMixedRealitySpatialAwarenessObservationHandler<SpatialAwarenessSceneObject>
	{
	}
}