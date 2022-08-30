﻿using System.Collections.Generic;

namespace AnySerialize
{
    
#region String

    [System.Serializable] public class AnyValue_String : AnyValue<System.String> {}
    [System.Serializable] public class AnyArray_String : AnyValue<System.String[]> {}
    [System.Serializable] public class AnyList_String : AnyValue<List<System.String>> {}
#endregion

#region Primitive Types

    [System.Serializable] public class AnyValue_Boolean : AnyValue<System.Boolean> {}
    [System.Serializable] public class AnyArray_Boolean : AnyValue<System.Boolean[]> {}
    [System.Serializable] public class AnyList_Boolean : AnyValue<List<System.Boolean>> {}

    [System.Serializable] public class AnyValue_Byte : AnyValue<System.Byte> {}
    [System.Serializable] public class AnyArray_Byte : AnyValue<System.Byte[]> {}
    [System.Serializable] public class AnyList_Byte : AnyValue<List<System.Byte>> {}

    [System.Serializable] public class AnyValue_Char : AnyValue<System.Char> {}
    [System.Serializable] public class AnyArray_Char : AnyValue<System.Char[]> {}
    [System.Serializable] public class AnyList_Char : AnyValue<List<System.Char>> {}

    [System.Serializable] public class AnyValue_Double : AnyValue<System.Double> {}
    [System.Serializable] public class AnyArray_Double : AnyValue<System.Double[]> {}
    [System.Serializable] public class AnyList_Double : AnyValue<List<System.Double>> {}

    [System.Serializable] public class AnyValue_Int16 : AnyValue<System.Int16> {}
    [System.Serializable] public class AnyArray_Int16 : AnyValue<System.Int16[]> {}
    [System.Serializable] public class AnyList_Int16 : AnyValue<List<System.Int16>> {}

    [System.Serializable] public class AnyValue_Int32 : AnyValue<System.Int32> {}
    [System.Serializable] public class AnyArray_Int32 : AnyValue<System.Int32[]> {}
    [System.Serializable] public class AnyList_Int32 : AnyValue<List<System.Int32>> {}

    [System.Serializable] public class AnyValue_Int64 : AnyValue<System.Int64> {}
    [System.Serializable] public class AnyArray_Int64 : AnyValue<System.Int64[]> {}
    [System.Serializable] public class AnyList_Int64 : AnyValue<List<System.Int64>> {}

    [System.Serializable] public class AnyValue_IntPtr : AnyValue<System.IntPtr> {}
    [System.Serializable] public class AnyArray_IntPtr : AnyValue<System.IntPtr[]> {}
    [System.Serializable] public class AnyList_IntPtr : AnyValue<List<System.IntPtr>> {}

    [System.Serializable] public class AnyValue_SByte : AnyValue<System.SByte> {}
    [System.Serializable] public class AnyArray_SByte : AnyValue<System.SByte[]> {}
    [System.Serializable] public class AnyList_SByte : AnyValue<List<System.SByte>> {}

    [System.Serializable] public class AnyValue_Single : AnyValue<System.Single> {}
    [System.Serializable] public class AnyArray_Single : AnyValue<System.Single[]> {}
    [System.Serializable] public class AnyList_Single : AnyValue<List<System.Single>> {}

    [System.Serializable] public class AnyValue_UInt16 : AnyValue<System.UInt16> {}
    [System.Serializable] public class AnyArray_UInt16 : AnyValue<System.UInt16[]> {}
    [System.Serializable] public class AnyList_UInt16 : AnyValue<List<System.UInt16>> {}

    [System.Serializable] public class AnyValue_UInt32 : AnyValue<System.UInt32> {}
    [System.Serializable] public class AnyArray_UInt32 : AnyValue<System.UInt32[]> {}
    [System.Serializable] public class AnyList_UInt32 : AnyValue<List<System.UInt32>> {}

    [System.Serializable] public class AnyValue_UInt64 : AnyValue<System.UInt64> {}
    [System.Serializable] public class AnyArray_UInt64 : AnyValue<System.UInt64[]> {}
    [System.Serializable] public class AnyList_UInt64 : AnyValue<List<System.UInt64>> {}

    [System.Serializable] public class AnyValue_UIntPtr : AnyValue<System.UIntPtr> {}
    [System.Serializable] public class AnyArray_UIntPtr : AnyValue<System.UIntPtr[]> {}
    [System.Serializable] public class AnyList_UIntPtr : AnyValue<List<System.UIntPtr>> {}
#endregion

#region UnityEngine Types
#if UNITY_2020_1_OR_NEWER
    [System.Serializable] public class AnySerialize_Object<T> : AnyValue<T> where T : UnityEngine.Object {}
    [System.Serializable] public class AnySerialize_ObjectArray<T> : AnyValue<T[]> where T : UnityEngine.Object {}
    [System.Serializable] public class AnySerialize_ObjectList<T> : AnyValue<List<T>> where T : UnityEngine.Object {}

    [System.Serializable] public class AnyValue_Vector2 : AnyValue<UnityEngine.Vector2> {}
    [System.Serializable] public class AnyArray_Vector2 : AnyValue<UnityEngine.Vector2[]> {}
    [System.Serializable] public class AnyList_Vector2 : AnyValue<List<UnityEngine.Vector2>> {}

    [System.Serializable] public class AnyValue_Vector3 : AnyValue<UnityEngine.Vector3> {}
    [System.Serializable] public class AnyArray_Vector3 : AnyValue<UnityEngine.Vector3[]> {}
    [System.Serializable] public class AnyList_Vector3 : AnyValue<List<UnityEngine.Vector3>> {}

    [System.Serializable] public class AnyValue_Vector4 : AnyValue<UnityEngine.Vector4> {}
    [System.Serializable] public class AnyArray_Vector4 : AnyValue<UnityEngine.Vector4[]> {}
    [System.Serializable] public class AnyList_Vector4 : AnyValue<List<UnityEngine.Vector4>> {}

    [System.Serializable] public class AnyValue_Vector2Int : AnyValue<UnityEngine.Vector2Int> {}
    [System.Serializable] public class AnyArray_Vector2Int : AnyValue<UnityEngine.Vector2Int[]> {}
    [System.Serializable] public class AnyList_Vector2Int : AnyValue<List<UnityEngine.Vector2Int>> {}

    [System.Serializable] public class AnyValue_Vector3Int : AnyValue<UnityEngine.Vector3Int> {}
    [System.Serializable] public class AnyArray_Vector3Int : AnyValue<UnityEngine.Vector3Int[]> {}
    [System.Serializable] public class AnyList_Vector3Int : AnyValue<List<UnityEngine.Vector3Int>> {}

    [System.Serializable] public class AnyValue_Quaternion : AnyValue<UnityEngine.Quaternion> {}
    [System.Serializable] public class AnyArray_Quaternion : AnyValue<UnityEngine.Quaternion[]> {}
    [System.Serializable] public class AnyList_Quaternion : AnyValue<List<UnityEngine.Quaternion>> {}

    [System.Serializable] public class AnyValue_Matrix4x4 : AnyValue<UnityEngine.Matrix4x4> {}
    [System.Serializable] public class AnyArray_Matrix4x4 : AnyValue<UnityEngine.Matrix4x4[]> {}
    [System.Serializable] public class AnyList_Matrix4x4 : AnyValue<List<UnityEngine.Matrix4x4>> {}

    [System.Serializable] public class AnyValue_Color : AnyValue<UnityEngine.Color> {}
    [System.Serializable] public class AnyArray_Color : AnyValue<UnityEngine.Color[]> {}
    [System.Serializable] public class AnyList_Color : AnyValue<List<UnityEngine.Color>> {}

    [System.Serializable] public class AnyValue_Rect : AnyValue<UnityEngine.Rect> {}
    [System.Serializable] public class AnyArray_Rect : AnyValue<UnityEngine.Rect[]> {}
    [System.Serializable] public class AnyList_Rect : AnyValue<List<UnityEngine.Rect>> {}

    [System.Serializable] public class AnyValue_LayerMask : AnyValue<UnityEngine.LayerMask> {}
    [System.Serializable] public class AnyArray_LayerMask : AnyValue<UnityEngine.LayerMask[]> {}
    [System.Serializable] public class AnyList_LayerMask : AnyValue<List<UnityEngine.LayerMask>> {}
#endif
#endregion

#region Unity.Mathematics Types
#if ENABLE_UNITY_MATHEMATICS

    [System.Serializable] public class AnyValue_bool2 : AnyValue<Unity.Mathematics.bool2> {}
    [System.Serializable] public class AnyArray_bool2 : AnyValue<Unity.Mathematics.bool2[]> {}
    [System.Serializable] public class AnyList_bool2 : AnyValue<List<Unity.Mathematics.bool2>> {}

    [System.Serializable] public class AnyValue_bool2x2 : AnyValue<Unity.Mathematics.bool2x2> {}
    [System.Serializable] public class AnyArray_bool2x2 : AnyValue<Unity.Mathematics.bool2x2[]> {}
    [System.Serializable] public class AnyList_bool2x2 : AnyValue<List<Unity.Mathematics.bool2x2>> {}

    [System.Serializable] public class AnyValue_bool2x3 : AnyValue<Unity.Mathematics.bool2x3> {}
    [System.Serializable] public class AnyArray_bool2x3 : AnyValue<Unity.Mathematics.bool2x3[]> {}
    [System.Serializable] public class AnyList_bool2x3 : AnyValue<List<Unity.Mathematics.bool2x3>> {}

    [System.Serializable] public class AnyValue_bool2x4 : AnyValue<Unity.Mathematics.bool2x4> {}
    [System.Serializable] public class AnyArray_bool2x4 : AnyValue<Unity.Mathematics.bool2x4[]> {}
    [System.Serializable] public class AnyList_bool2x4 : AnyValue<List<Unity.Mathematics.bool2x4>> {}

    [System.Serializable] public class AnyValue_bool3 : AnyValue<Unity.Mathematics.bool3> {}
    [System.Serializable] public class AnyArray_bool3 : AnyValue<Unity.Mathematics.bool3[]> {}
    [System.Serializable] public class AnyList_bool3 : AnyValue<List<Unity.Mathematics.bool3>> {}

    [System.Serializable] public class AnyValue_bool3x2 : AnyValue<Unity.Mathematics.bool3x2> {}
    [System.Serializable] public class AnyArray_bool3x2 : AnyValue<Unity.Mathematics.bool3x2[]> {}
    [System.Serializable] public class AnyList_bool3x2 : AnyValue<List<Unity.Mathematics.bool3x2>> {}

    [System.Serializable] public class AnyValue_bool3x3 : AnyValue<Unity.Mathematics.bool3x3> {}
    [System.Serializable] public class AnyArray_bool3x3 : AnyValue<Unity.Mathematics.bool3x3[]> {}
    [System.Serializable] public class AnyList_bool3x3 : AnyValue<List<Unity.Mathematics.bool3x3>> {}

    [System.Serializable] public class AnyValue_bool3x4 : AnyValue<Unity.Mathematics.bool3x4> {}
    [System.Serializable] public class AnyArray_bool3x4 : AnyValue<Unity.Mathematics.bool3x4[]> {}
    [System.Serializable] public class AnyList_bool3x4 : AnyValue<List<Unity.Mathematics.bool3x4>> {}

    [System.Serializable] public class AnyValue_bool4 : AnyValue<Unity.Mathematics.bool4> {}
    [System.Serializable] public class AnyArray_bool4 : AnyValue<Unity.Mathematics.bool4[]> {}
    [System.Serializable] public class AnyList_bool4 : AnyValue<List<Unity.Mathematics.bool4>> {}

    [System.Serializable] public class AnyValue_bool4x2 : AnyValue<Unity.Mathematics.bool4x2> {}
    [System.Serializable] public class AnyArray_bool4x2 : AnyValue<Unity.Mathematics.bool4x2[]> {}
    [System.Serializable] public class AnyList_bool4x2 : AnyValue<List<Unity.Mathematics.bool4x2>> {}

    [System.Serializable] public class AnyValue_bool4x3 : AnyValue<Unity.Mathematics.bool4x3> {}
    [System.Serializable] public class AnyArray_bool4x3 : AnyValue<Unity.Mathematics.bool4x3[]> {}
    [System.Serializable] public class AnyList_bool4x3 : AnyValue<List<Unity.Mathematics.bool4x3>> {}

    [System.Serializable] public class AnyValue_bool4x4 : AnyValue<Unity.Mathematics.bool4x4> {}
    [System.Serializable] public class AnyArray_bool4x4 : AnyValue<Unity.Mathematics.bool4x4[]> {}
    [System.Serializable] public class AnyList_bool4x4 : AnyValue<List<Unity.Mathematics.bool4x4>> {}

    [System.Serializable] public class AnyValue_double2 : AnyValue<Unity.Mathematics.double2> {}
    [System.Serializable] public class AnyArray_double2 : AnyValue<Unity.Mathematics.double2[]> {}
    [System.Serializable] public class AnyList_double2 : AnyValue<List<Unity.Mathematics.double2>> {}

    [System.Serializable] public class AnyValue_double2x2 : AnyValue<Unity.Mathematics.double2x2> {}
    [System.Serializable] public class AnyArray_double2x2 : AnyValue<Unity.Mathematics.double2x2[]> {}
    [System.Serializable] public class AnyList_double2x2 : AnyValue<List<Unity.Mathematics.double2x2>> {}

    [System.Serializable] public class AnyValue_double2x3 : AnyValue<Unity.Mathematics.double2x3> {}
    [System.Serializable] public class AnyArray_double2x3 : AnyValue<Unity.Mathematics.double2x3[]> {}
    [System.Serializable] public class AnyList_double2x3 : AnyValue<List<Unity.Mathematics.double2x3>> {}

    [System.Serializable] public class AnyValue_double2x4 : AnyValue<Unity.Mathematics.double2x4> {}
    [System.Serializable] public class AnyArray_double2x4 : AnyValue<Unity.Mathematics.double2x4[]> {}
    [System.Serializable] public class AnyList_double2x4 : AnyValue<List<Unity.Mathematics.double2x4>> {}

    [System.Serializable] public class AnyValue_double3 : AnyValue<Unity.Mathematics.double3> {}
    [System.Serializable] public class AnyArray_double3 : AnyValue<Unity.Mathematics.double3[]> {}
    [System.Serializable] public class AnyList_double3 : AnyValue<List<Unity.Mathematics.double3>> {}

    [System.Serializable] public class AnyValue_double3x2 : AnyValue<Unity.Mathematics.double3x2> {}
    [System.Serializable] public class AnyArray_double3x2 : AnyValue<Unity.Mathematics.double3x2[]> {}
    [System.Serializable] public class AnyList_double3x2 : AnyValue<List<Unity.Mathematics.double3x2>> {}

    [System.Serializable] public class AnyValue_double3x3 : AnyValue<Unity.Mathematics.double3x3> {}
    [System.Serializable] public class AnyArray_double3x3 : AnyValue<Unity.Mathematics.double3x3[]> {}
    [System.Serializable] public class AnyList_double3x3 : AnyValue<List<Unity.Mathematics.double3x3>> {}

    [System.Serializable] public class AnyValue_double3x4 : AnyValue<Unity.Mathematics.double3x4> {}
    [System.Serializable] public class AnyArray_double3x4 : AnyValue<Unity.Mathematics.double3x4[]> {}
    [System.Serializable] public class AnyList_double3x4 : AnyValue<List<Unity.Mathematics.double3x4>> {}

    [System.Serializable] public class AnyValue_double4 : AnyValue<Unity.Mathematics.double4> {}
    [System.Serializable] public class AnyArray_double4 : AnyValue<Unity.Mathematics.double4[]> {}
    [System.Serializable] public class AnyList_double4 : AnyValue<List<Unity.Mathematics.double4>> {}

    [System.Serializable] public class AnyValue_double4x2 : AnyValue<Unity.Mathematics.double4x2> {}
    [System.Serializable] public class AnyArray_double4x2 : AnyValue<Unity.Mathematics.double4x2[]> {}
    [System.Serializable] public class AnyList_double4x2 : AnyValue<List<Unity.Mathematics.double4x2>> {}

    [System.Serializable] public class AnyValue_double4x3 : AnyValue<Unity.Mathematics.double4x3> {}
    [System.Serializable] public class AnyArray_double4x3 : AnyValue<Unity.Mathematics.double4x3[]> {}
    [System.Serializable] public class AnyList_double4x3 : AnyValue<List<Unity.Mathematics.double4x3>> {}

    [System.Serializable] public class AnyValue_double4x4 : AnyValue<Unity.Mathematics.double4x4> {}
    [System.Serializable] public class AnyArray_double4x4 : AnyValue<Unity.Mathematics.double4x4[]> {}
    [System.Serializable] public class AnyList_double4x4 : AnyValue<List<Unity.Mathematics.double4x4>> {}

    [System.Serializable] public class AnyValue_float2 : AnyValue<Unity.Mathematics.float2> {}
    [System.Serializable] public class AnyArray_float2 : AnyValue<Unity.Mathematics.float2[]> {}
    [System.Serializable] public class AnyList_float2 : AnyValue<List<Unity.Mathematics.float2>> {}

    [System.Serializable] public class AnyValue_float2x2 : AnyValue<Unity.Mathematics.float2x2> {}
    [System.Serializable] public class AnyArray_float2x2 : AnyValue<Unity.Mathematics.float2x2[]> {}
    [System.Serializable] public class AnyList_float2x2 : AnyValue<List<Unity.Mathematics.float2x2>> {}

    [System.Serializable] public class AnyValue_float2x3 : AnyValue<Unity.Mathematics.float2x3> {}
    [System.Serializable] public class AnyArray_float2x3 : AnyValue<Unity.Mathematics.float2x3[]> {}
    [System.Serializable] public class AnyList_float2x3 : AnyValue<List<Unity.Mathematics.float2x3>> {}

    [System.Serializable] public class AnyValue_float2x4 : AnyValue<Unity.Mathematics.float2x4> {}
    [System.Serializable] public class AnyArray_float2x4 : AnyValue<Unity.Mathematics.float2x4[]> {}
    [System.Serializable] public class AnyList_float2x4 : AnyValue<List<Unity.Mathematics.float2x4>> {}

    [System.Serializable] public class AnyValue_float3 : AnyValue<Unity.Mathematics.float3> {}
    [System.Serializable] public class AnyArray_float3 : AnyValue<Unity.Mathematics.float3[]> {}
    [System.Serializable] public class AnyList_float3 : AnyValue<List<Unity.Mathematics.float3>> {}

    [System.Serializable] public class AnyValue_float3x2 : AnyValue<Unity.Mathematics.float3x2> {}
    [System.Serializable] public class AnyArray_float3x2 : AnyValue<Unity.Mathematics.float3x2[]> {}
    [System.Serializable] public class AnyList_float3x2 : AnyValue<List<Unity.Mathematics.float3x2>> {}

    [System.Serializable] public class AnyValue_float3x3 : AnyValue<Unity.Mathematics.float3x3> {}
    [System.Serializable] public class AnyArray_float3x3 : AnyValue<Unity.Mathematics.float3x3[]> {}
    [System.Serializable] public class AnyList_float3x3 : AnyValue<List<Unity.Mathematics.float3x3>> {}

    [System.Serializable] public class AnyValue_float3x4 : AnyValue<Unity.Mathematics.float3x4> {}
    [System.Serializable] public class AnyArray_float3x4 : AnyValue<Unity.Mathematics.float3x4[]> {}
    [System.Serializable] public class AnyList_float3x4 : AnyValue<List<Unity.Mathematics.float3x4>> {}

    [System.Serializable] public class AnyValue_float4 : AnyValue<Unity.Mathematics.float4> {}
    [System.Serializable] public class AnyArray_float4 : AnyValue<Unity.Mathematics.float4[]> {}
    [System.Serializable] public class AnyList_float4 : AnyValue<List<Unity.Mathematics.float4>> {}

    [System.Serializable] public class AnyValue_float4x2 : AnyValue<Unity.Mathematics.float4x2> {}
    [System.Serializable] public class AnyArray_float4x2 : AnyValue<Unity.Mathematics.float4x2[]> {}
    [System.Serializable] public class AnyList_float4x2 : AnyValue<List<Unity.Mathematics.float4x2>> {}

    [System.Serializable] public class AnyValue_float4x3 : AnyValue<Unity.Mathematics.float4x3> {}
    [System.Serializable] public class AnyArray_float4x3 : AnyValue<Unity.Mathematics.float4x3[]> {}
    [System.Serializable] public class AnyList_float4x3 : AnyValue<List<Unity.Mathematics.float4x3>> {}

    [System.Serializable] public class AnyValue_float4x4 : AnyValue<Unity.Mathematics.float4x4> {}
    [System.Serializable] public class AnyArray_float4x4 : AnyValue<Unity.Mathematics.float4x4[]> {}
    [System.Serializable] public class AnyList_float4x4 : AnyValue<List<Unity.Mathematics.float4x4>> {}

    [System.Serializable] public class AnyValue_half : AnyValue<Unity.Mathematics.half> {}
    [System.Serializable] public class AnyArray_half : AnyValue<Unity.Mathematics.half[]> {}
    [System.Serializable] public class AnyList_half : AnyValue<List<Unity.Mathematics.half>> {}

    [System.Serializable] public class AnyValue_half2 : AnyValue<Unity.Mathematics.half2> {}
    [System.Serializable] public class AnyArray_half2 : AnyValue<Unity.Mathematics.half2[]> {}
    [System.Serializable] public class AnyList_half2 : AnyValue<List<Unity.Mathematics.half2>> {}

    [System.Serializable] public class AnyValue_half3 : AnyValue<Unity.Mathematics.half3> {}
    [System.Serializable] public class AnyArray_half3 : AnyValue<Unity.Mathematics.half3[]> {}
    [System.Serializable] public class AnyList_half3 : AnyValue<List<Unity.Mathematics.half3>> {}

    [System.Serializable] public class AnyValue_half4 : AnyValue<Unity.Mathematics.half4> {}
    [System.Serializable] public class AnyArray_half4 : AnyValue<Unity.Mathematics.half4[]> {}
    [System.Serializable] public class AnyList_half4 : AnyValue<List<Unity.Mathematics.half4>> {}

    [System.Serializable] public class AnyValue_int2 : AnyValue<Unity.Mathematics.int2> {}
    [System.Serializable] public class AnyArray_int2 : AnyValue<Unity.Mathematics.int2[]> {}
    [System.Serializable] public class AnyList_int2 : AnyValue<List<Unity.Mathematics.int2>> {}

    [System.Serializable] public class AnyValue_int2x2 : AnyValue<Unity.Mathematics.int2x2> {}
    [System.Serializable] public class AnyArray_int2x2 : AnyValue<Unity.Mathematics.int2x2[]> {}
    [System.Serializable] public class AnyList_int2x2 : AnyValue<List<Unity.Mathematics.int2x2>> {}

    [System.Serializable] public class AnyValue_int2x3 : AnyValue<Unity.Mathematics.int2x3> {}
    [System.Serializable] public class AnyArray_int2x3 : AnyValue<Unity.Mathematics.int2x3[]> {}
    [System.Serializable] public class AnyList_int2x3 : AnyValue<List<Unity.Mathematics.int2x3>> {}

    [System.Serializable] public class AnyValue_int2x4 : AnyValue<Unity.Mathematics.int2x4> {}
    [System.Serializable] public class AnyArray_int2x4 : AnyValue<Unity.Mathematics.int2x4[]> {}
    [System.Serializable] public class AnyList_int2x4 : AnyValue<List<Unity.Mathematics.int2x4>> {}

    [System.Serializable] public class AnyValue_int3 : AnyValue<Unity.Mathematics.int3> {}
    [System.Serializable] public class AnyArray_int3 : AnyValue<Unity.Mathematics.int3[]> {}
    [System.Serializable] public class AnyList_int3 : AnyValue<List<Unity.Mathematics.int3>> {}

    [System.Serializable] public class AnyValue_int3x2 : AnyValue<Unity.Mathematics.int3x2> {}
    [System.Serializable] public class AnyArray_int3x2 : AnyValue<Unity.Mathematics.int3x2[]> {}
    [System.Serializable] public class AnyList_int3x2 : AnyValue<List<Unity.Mathematics.int3x2>> {}

    [System.Serializable] public class AnyValue_int3x3 : AnyValue<Unity.Mathematics.int3x3> {}
    [System.Serializable] public class AnyArray_int3x3 : AnyValue<Unity.Mathematics.int3x3[]> {}
    [System.Serializable] public class AnyList_int3x3 : AnyValue<List<Unity.Mathematics.int3x3>> {}

    [System.Serializable] public class AnyValue_int3x4 : AnyValue<Unity.Mathematics.int3x4> {}
    [System.Serializable] public class AnyArray_int3x4 : AnyValue<Unity.Mathematics.int3x4[]> {}
    [System.Serializable] public class AnyList_int3x4 : AnyValue<List<Unity.Mathematics.int3x4>> {}

    [System.Serializable] public class AnyValue_int4 : AnyValue<Unity.Mathematics.int4> {}
    [System.Serializable] public class AnyArray_int4 : AnyValue<Unity.Mathematics.int4[]> {}
    [System.Serializable] public class AnyList_int4 : AnyValue<List<Unity.Mathematics.int4>> {}

    [System.Serializable] public class AnyValue_int4x2 : AnyValue<Unity.Mathematics.int4x2> {}
    [System.Serializable] public class AnyArray_int4x2 : AnyValue<Unity.Mathematics.int4x2[]> {}
    [System.Serializable] public class AnyList_int4x2 : AnyValue<List<Unity.Mathematics.int4x2>> {}

    [System.Serializable] public class AnyValue_int4x3 : AnyValue<Unity.Mathematics.int4x3> {}
    [System.Serializable] public class AnyArray_int4x3 : AnyValue<Unity.Mathematics.int4x3[]> {}
    [System.Serializable] public class AnyList_int4x3 : AnyValue<List<Unity.Mathematics.int4x3>> {}

    [System.Serializable] public class AnyValue_int4x4 : AnyValue<Unity.Mathematics.int4x4> {}
    [System.Serializable] public class AnyArray_int4x4 : AnyValue<Unity.Mathematics.int4x4[]> {}
    [System.Serializable] public class AnyList_int4x4 : AnyValue<List<Unity.Mathematics.int4x4>> {}

    [System.Serializable] public class AnyValue_quaternion : AnyValue<Unity.Mathematics.quaternion> {}
    [System.Serializable] public class AnyArray_quaternion : AnyValue<Unity.Mathematics.quaternion[]> {}
    [System.Serializable] public class AnyList_quaternion : AnyValue<List<Unity.Mathematics.quaternion>> {}

    [System.Serializable] public class AnyValue_Random : AnyValue<Unity.Mathematics.Random> {}
    [System.Serializable] public class AnyArray_Random : AnyValue<Unity.Mathematics.Random[]> {}
    [System.Serializable] public class AnyList_Random : AnyValue<List<Unity.Mathematics.Random>> {}

    [System.Serializable] public class AnyValue_RigidTransform : AnyValue<Unity.Mathematics.RigidTransform> {}
    [System.Serializable] public class AnyArray_RigidTransform : AnyValue<Unity.Mathematics.RigidTransform[]> {}
    [System.Serializable] public class AnyList_RigidTransform : AnyValue<List<Unity.Mathematics.RigidTransform>> {}

    [System.Serializable] public class AnyValue_uint2 : AnyValue<Unity.Mathematics.uint2> {}
    [System.Serializable] public class AnyArray_uint2 : AnyValue<Unity.Mathematics.uint2[]> {}
    [System.Serializable] public class AnyList_uint2 : AnyValue<List<Unity.Mathematics.uint2>> {}

    [System.Serializable] public class AnyValue_uint2x2 : AnyValue<Unity.Mathematics.uint2x2> {}
    [System.Serializable] public class AnyArray_uint2x2 : AnyValue<Unity.Mathematics.uint2x2[]> {}
    [System.Serializable] public class AnyList_uint2x2 : AnyValue<List<Unity.Mathematics.uint2x2>> {}

    [System.Serializable] public class AnyValue_uint2x3 : AnyValue<Unity.Mathematics.uint2x3> {}
    [System.Serializable] public class AnyArray_uint2x3 : AnyValue<Unity.Mathematics.uint2x3[]> {}
    [System.Serializable] public class AnyList_uint2x3 : AnyValue<List<Unity.Mathematics.uint2x3>> {}

    [System.Serializable] public class AnyValue_uint2x4 : AnyValue<Unity.Mathematics.uint2x4> {}
    [System.Serializable] public class AnyArray_uint2x4 : AnyValue<Unity.Mathematics.uint2x4[]> {}
    [System.Serializable] public class AnyList_uint2x4 : AnyValue<List<Unity.Mathematics.uint2x4>> {}

    [System.Serializable] public class AnyValue_uint3 : AnyValue<Unity.Mathematics.uint3> {}
    [System.Serializable] public class AnyArray_uint3 : AnyValue<Unity.Mathematics.uint3[]> {}
    [System.Serializable] public class AnyList_uint3 : AnyValue<List<Unity.Mathematics.uint3>> {}

    [System.Serializable] public class AnyValue_uint3x2 : AnyValue<Unity.Mathematics.uint3x2> {}
    [System.Serializable] public class AnyArray_uint3x2 : AnyValue<Unity.Mathematics.uint3x2[]> {}
    [System.Serializable] public class AnyList_uint3x2 : AnyValue<List<Unity.Mathematics.uint3x2>> {}

    [System.Serializable] public class AnyValue_uint3x3 : AnyValue<Unity.Mathematics.uint3x3> {}
    [System.Serializable] public class AnyArray_uint3x3 : AnyValue<Unity.Mathematics.uint3x3[]> {}
    [System.Serializable] public class AnyList_uint3x3 : AnyValue<List<Unity.Mathematics.uint3x3>> {}

    [System.Serializable] public class AnyValue_uint3x4 : AnyValue<Unity.Mathematics.uint3x4> {}
    [System.Serializable] public class AnyArray_uint3x4 : AnyValue<Unity.Mathematics.uint3x4[]> {}
    [System.Serializable] public class AnyList_uint3x4 : AnyValue<List<Unity.Mathematics.uint3x4>> {}

    [System.Serializable] public class AnyValue_uint4 : AnyValue<Unity.Mathematics.uint4> {}
    [System.Serializable] public class AnyArray_uint4 : AnyValue<Unity.Mathematics.uint4[]> {}
    [System.Serializable] public class AnyList_uint4 : AnyValue<List<Unity.Mathematics.uint4>> {}

    [System.Serializable] public class AnyValue_uint4x2 : AnyValue<Unity.Mathematics.uint4x2> {}
    [System.Serializable] public class AnyArray_uint4x2 : AnyValue<Unity.Mathematics.uint4x2[]> {}
    [System.Serializable] public class AnyList_uint4x2 : AnyValue<List<Unity.Mathematics.uint4x2>> {}

    [System.Serializable] public class AnyValue_uint4x3 : AnyValue<Unity.Mathematics.uint4x3> {}
    [System.Serializable] public class AnyArray_uint4x3 : AnyValue<Unity.Mathematics.uint4x3[]> {}
    [System.Serializable] public class AnyList_uint4x3 : AnyValue<List<Unity.Mathematics.uint4x3>> {}

    [System.Serializable] public class AnyValue_uint4x4 : AnyValue<Unity.Mathematics.uint4x4> {}
    [System.Serializable] public class AnyArray_uint4x4 : AnyValue<Unity.Mathematics.uint4x4[]> {}
    [System.Serializable] public class AnyList_uint4x4 : AnyValue<List<Unity.Mathematics.uint4x4>> {}
#endif
#endregion
}

