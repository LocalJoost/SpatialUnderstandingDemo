using System;
using Microsoft.MixedReality.Toolkit.Physics;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using MRTKExtensions.Utilities;
using UnityEngine;

namespace MRTKExtensions.SceneUnderstanding
{
    [Serializable]
    public class SpatialUnderstandingLayer
    {
        [SerializeField,SingleEnumFlagSelect(EnumType = typeof(SpatialAwarenessSurfaceTypes))]
        [Tooltip("The surface type to act on")]
        private SpatialAwarenessSurfaceTypes surfaceType;
        
        [SerializeField, PhysicsLayer]
        [Tooltip("Physics layer on which to set understood planes.")]
        private int layer;

        [SerializeField]
        [Tooltip("A material to assign (optionally)")]
        private Material displayMaterial;
        
        public SpatialAwarenessSurfaceTypes SurfaceType => surfaceType;
        
        public int Layer => layer;

        public Material DisplayMaterial => displayMaterial;
    }
}