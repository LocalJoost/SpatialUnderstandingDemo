using System;
using UnityEngine;

namespace MRTKExtensions.SceneUnderstanding
{
    public class SingleSurfaceTypeAttribute : PropertyAttribute
    {
        public Type EnumType { get; set; }
    }
}