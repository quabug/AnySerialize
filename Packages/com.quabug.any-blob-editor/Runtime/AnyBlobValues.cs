#if USE_UNITY_BLOB

namespace Blob
{

#region Primitive Types
    [System.Serializable] public class AnyBlobValue_Boolean : AnyBlobValue<System.Boolean> {}
    [System.Serializable] public class AnyBlobValue_Byte : AnyBlobValue<System.Byte> {}
    [System.Serializable] public class AnyBlobValue_Char : AnyBlobValue<System.Char> {}
    [System.Serializable] public class AnyBlobValue_Double : AnyBlobValue<System.Double> {}
    [System.Serializable] public class AnyBlobValue_Int16 : AnyBlobValue<System.Int16> {}
    [System.Serializable] public class AnyBlobValue_Int32 : AnyBlobValue<System.Int32> {}
    [System.Serializable] public class AnyBlobValue_Int64 : AnyBlobValue<System.Int64> {}
    [System.Serializable] public class AnyBlobValue_SByte : AnyBlobValue<System.SByte> {}
    [System.Serializable] public class AnyBlobValue_Single : AnyBlobValue<System.Single> {}
    [System.Serializable] public class AnyBlobValue_UInt16 : AnyBlobValue<System.UInt16> {}
    [System.Serializable] public class AnyBlobValue_UInt32 : AnyBlobValue<System.UInt32> {}
    [System.Serializable] public class AnyBlobValue_UInt64 : AnyBlobValue<System.UInt64> {}
    [System.Serializable] public class AnyBlobValue_IntPtr : AnyBlobValue<System.IntPtr> {}
    [System.Serializable] public class AnyBlobValue_UIntPtr : AnyBlobValue<System.UIntPtr> {}
#endregion

#region UnityEngine Types
#if UNITY_2020_1_OR_NEWER
    [System.Serializable] public class AnyBlobValue_Vector2 : AnyBlobValue<UnityEngine.Vector2> {}
    [System.Serializable] public class AnyBlobValue_Vector3 : AnyBlobValue<UnityEngine.Vector3> {}
    [System.Serializable] public class AnyBlobValue_Vector4 : AnyBlobValue<UnityEngine.Vector4> {}
    [System.Serializable] public class AnyBlobValue_Vector2Int : AnyBlobValue<UnityEngine.Vector2Int> {}
    [System.Serializable] public class AnyBlobValue_Vector3Int : AnyBlobValue<UnityEngine.Vector3Int> {}
    [System.Serializable] public class AnyBlobValue_Quaternion : AnyBlobValue<UnityEngine.Quaternion> {}
    [System.Serializable] public class AnyBlobValue_Matrix4x4 : AnyBlobValue<UnityEngine.Matrix4x4> {}
    [System.Serializable] public class AnyBlobValue_Color : AnyBlobValue<UnityEngine.Color> {}
    [System.Serializable] public class AnyBlobValue_Rect : AnyBlobValue<UnityEngine.Rect> {}
    [System.Serializable] public class AnyBlobValue_LayerMask : AnyBlobValue<UnityEngine.LayerMask> {}
#endif
#endregion

#region Unity.Mathematics Types
#if USE_UNITY_MATHEMATICS
    [System.Serializable] public class AnyBlobValue_bool2 : AnyBlobValue<Unity.Mathematics.bool2> {}
    [System.Serializable] public class AnyBlobValue_bool2x2 : AnyBlobValue<Unity.Mathematics.bool2x2> {}
    [System.Serializable] public class AnyBlobValue_bool2x3 : AnyBlobValue<Unity.Mathematics.bool2x3> {}
    [System.Serializable] public class AnyBlobValue_bool2x4 : AnyBlobValue<Unity.Mathematics.bool2x4> {}
    [System.Serializable] public class AnyBlobValue_bool3 : AnyBlobValue<Unity.Mathematics.bool3> {}
    [System.Serializable] public class AnyBlobValue_bool3x2 : AnyBlobValue<Unity.Mathematics.bool3x2> {}
    [System.Serializable] public class AnyBlobValue_bool3x3 : AnyBlobValue<Unity.Mathematics.bool3x3> {}
    [System.Serializable] public class AnyBlobValue_bool3x4 : AnyBlobValue<Unity.Mathematics.bool3x4> {}
    [System.Serializable] public class AnyBlobValue_bool4 : AnyBlobValue<Unity.Mathematics.bool4> {}
    [System.Serializable] public class AnyBlobValue_bool4x2 : AnyBlobValue<Unity.Mathematics.bool4x2> {}
    [System.Serializable] public class AnyBlobValue_bool4x3 : AnyBlobValue<Unity.Mathematics.bool4x3> {}
    [System.Serializable] public class AnyBlobValue_bool4x4 : AnyBlobValue<Unity.Mathematics.bool4x4> {}
    [System.Serializable] public class AnyBlobValue_double2 : AnyBlobValue<Unity.Mathematics.double2> {}
    [System.Serializable] public class AnyBlobValue_double2x2 : AnyBlobValue<Unity.Mathematics.double2x2> {}
    [System.Serializable] public class AnyBlobValue_double2x3 : AnyBlobValue<Unity.Mathematics.double2x3> {}
    [System.Serializable] public class AnyBlobValue_double2x4 : AnyBlobValue<Unity.Mathematics.double2x4> {}
    [System.Serializable] public class AnyBlobValue_double3 : AnyBlobValue<Unity.Mathematics.double3> {}
    [System.Serializable] public class AnyBlobValue_double3x2 : AnyBlobValue<Unity.Mathematics.double3x2> {}
    [System.Serializable] public class AnyBlobValue_double3x3 : AnyBlobValue<Unity.Mathematics.double3x3> {}
    [System.Serializable] public class AnyBlobValue_double3x4 : AnyBlobValue<Unity.Mathematics.double3x4> {}
    [System.Serializable] public class AnyBlobValue_double4 : AnyBlobValue<Unity.Mathematics.double4> {}
    [System.Serializable] public class AnyBlobValue_double4x2 : AnyBlobValue<Unity.Mathematics.double4x2> {}
    [System.Serializable] public class AnyBlobValue_double4x3 : AnyBlobValue<Unity.Mathematics.double4x3> {}
    [System.Serializable] public class AnyBlobValue_double4x4 : AnyBlobValue<Unity.Mathematics.double4x4> {}
    [System.Serializable] public class AnyBlobValue_float2 : AnyBlobValue<Unity.Mathematics.float2> {}
    [System.Serializable] public class AnyBlobValue_float2x2 : AnyBlobValue<Unity.Mathematics.float2x2> {}
    [System.Serializable] public class AnyBlobValue_float2x3 : AnyBlobValue<Unity.Mathematics.float2x3> {}
    [System.Serializable] public class AnyBlobValue_float2x4 : AnyBlobValue<Unity.Mathematics.float2x4> {}
    [System.Serializable] public class AnyBlobValue_float3 : AnyBlobValue<Unity.Mathematics.float3> {}
    [System.Serializable] public class AnyBlobValue_float3x2 : AnyBlobValue<Unity.Mathematics.float3x2> {}
    [System.Serializable] public class AnyBlobValue_float3x3 : AnyBlobValue<Unity.Mathematics.float3x3> {}
    [System.Serializable] public class AnyBlobValue_float3x4 : AnyBlobValue<Unity.Mathematics.float3x4> {}
    [System.Serializable] public class AnyBlobValue_float4 : AnyBlobValue<Unity.Mathematics.float4> {}
    [System.Serializable] public class AnyBlobValue_float4x2 : AnyBlobValue<Unity.Mathematics.float4x2> {}
    [System.Serializable] public class AnyBlobValue_float4x3 : AnyBlobValue<Unity.Mathematics.float4x3> {}
    [System.Serializable] public class AnyBlobValue_float4x4 : AnyBlobValue<Unity.Mathematics.float4x4> {}
    [System.Serializable] public class AnyBlobValue_half : AnyBlobValue<Unity.Mathematics.half> {}
    [System.Serializable] public class AnyBlobValue_half2 : AnyBlobValue<Unity.Mathematics.half2> {}
    [System.Serializable] public class AnyBlobValue_half3 : AnyBlobValue<Unity.Mathematics.half3> {}
    [System.Serializable] public class AnyBlobValue_half4 : AnyBlobValue<Unity.Mathematics.half4> {}
    [System.Serializable] public class AnyBlobValue_int2 : AnyBlobValue<Unity.Mathematics.int2> {}
    [System.Serializable] public class AnyBlobValue_int2x2 : AnyBlobValue<Unity.Mathematics.int2x2> {}
    [System.Serializable] public class AnyBlobValue_int2x3 : AnyBlobValue<Unity.Mathematics.int2x3> {}
    [System.Serializable] public class AnyBlobValue_int2x4 : AnyBlobValue<Unity.Mathematics.int2x4> {}
    [System.Serializable] public class AnyBlobValue_int3 : AnyBlobValue<Unity.Mathematics.int3> {}
    [System.Serializable] public class AnyBlobValue_int3x2 : AnyBlobValue<Unity.Mathematics.int3x2> {}
    [System.Serializable] public class AnyBlobValue_int3x3 : AnyBlobValue<Unity.Mathematics.int3x3> {}
    [System.Serializable] public class AnyBlobValue_int3x4 : AnyBlobValue<Unity.Mathematics.int3x4> {}
    [System.Serializable] public class AnyBlobValue_int4 : AnyBlobValue<Unity.Mathematics.int4> {}
    [System.Serializable] public class AnyBlobValue_int4x2 : AnyBlobValue<Unity.Mathematics.int4x2> {}
    [System.Serializable] public class AnyBlobValue_int4x3 : AnyBlobValue<Unity.Mathematics.int4x3> {}
    [System.Serializable] public class AnyBlobValue_int4x4 : AnyBlobValue<Unity.Mathematics.int4x4> {}
    [System.Serializable] public class AnyBlobValue_quaternion : AnyBlobValue<Unity.Mathematics.quaternion> {}
    [System.Serializable] public class AnyBlobValue_Random : AnyBlobValue<Unity.Mathematics.Random> {}
    [System.Serializable] public class AnyBlobValue_RigidTransform : AnyBlobValue<Unity.Mathematics.RigidTransform> {}
    [System.Serializable] public class AnyBlobValue_uint2 : AnyBlobValue<Unity.Mathematics.uint2> {}
    [System.Serializable] public class AnyBlobValue_uint2x2 : AnyBlobValue<Unity.Mathematics.uint2x2> {}
    [System.Serializable] public class AnyBlobValue_uint2x3 : AnyBlobValue<Unity.Mathematics.uint2x3> {}
    [System.Serializable] public class AnyBlobValue_uint2x4 : AnyBlobValue<Unity.Mathematics.uint2x4> {}
    [System.Serializable] public class AnyBlobValue_uint3 : AnyBlobValue<Unity.Mathematics.uint3> {}
    [System.Serializable] public class AnyBlobValue_uint3x2 : AnyBlobValue<Unity.Mathematics.uint3x2> {}
    [System.Serializable] public class AnyBlobValue_uint3x3 : AnyBlobValue<Unity.Mathematics.uint3x3> {}
    [System.Serializable] public class AnyBlobValue_uint3x4 : AnyBlobValue<Unity.Mathematics.uint3x4> {}
    [System.Serializable] public class AnyBlobValue_uint4 : AnyBlobValue<Unity.Mathematics.uint4> {}
    [System.Serializable] public class AnyBlobValue_uint4x2 : AnyBlobValue<Unity.Mathematics.uint4x2> {}
    [System.Serializable] public class AnyBlobValue_uint4x3 : AnyBlobValue<Unity.Mathematics.uint4x3> {}
    [System.Serializable] public class AnyBlobValue_uint4x4 : AnyBlobValue<Unity.Mathematics.uint4x4> {}
#endif
#endregion
}

#endif

