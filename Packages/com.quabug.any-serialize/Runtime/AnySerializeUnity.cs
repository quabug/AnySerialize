using System.Collections.Generic;

namespace AnySerialize
{

#region Primitive Types

    public class AnySerialize_Boolean : AnyValue<System.Boolean> {}
    public class AnySerialize_BooleanArray : AnyValue<System.Boolean[]> {}
    public class AnySerialize_BooleanList : AnyValue<List<System.Boolean>> {}

    public class AnySerialize_Byte : AnyValue<System.Byte> {}
    public class AnySerialize_ByteArray : AnyValue<System.Byte[]> {}
    public class AnySerialize_ByteList : AnyValue<List<System.Byte>> {}

    public class AnySerialize_Char : AnyValue<System.Char> {}
    public class AnySerialize_CharArray : AnyValue<System.Char[]> {}
    public class AnySerialize_CharList : AnyValue<List<System.Char>> {}

    public class AnySerialize_Double : AnyValue<System.Double> {}
    public class AnySerialize_DoubleArray : AnyValue<System.Double[]> {}
    public class AnySerialize_DoubleList : AnyValue<List<System.Double>> {}

    public class AnySerialize_Int16 : AnyValue<System.Int16> {}
    public class AnySerialize_Int16Array : AnyValue<System.Int16[]> {}
    public class AnySerialize_Int16List : AnyValue<List<System.Int16>> {}

    public class AnySerialize_Int32 : AnyValue<System.Int32> {}
    public class AnySerialize_Int32Array : AnyValue<System.Int32[]> {}
    public class AnySerialize_Int32List : AnyValue<List<System.Int32>> {}

    public class AnySerialize_Int64 : AnyValue<System.Int64> {}
    public class AnySerialize_Int64Array : AnyValue<System.Int64[]> {}
    public class AnySerialize_Int64List : AnyValue<List<System.Int64>> {}

    public class AnySerialize_SByte : AnyValue<System.SByte> {}
    public class AnySerialize_SByteArray : AnyValue<System.SByte[]> {}
    public class AnySerialize_SByteList : AnyValue<List<System.SByte>> {}

    public class AnySerialize_Single : AnyValue<System.Single> {}
    public class AnySerialize_SingleArray : AnyValue<System.Single[]> {}
    public class AnySerialize_SingleList : AnyValue<List<System.Single>> {}

    public class AnySerialize_UInt16 : AnyValue<System.UInt16> {}
    public class AnySerialize_UInt16Array : AnyValue<System.UInt16[]> {}
    public class AnySerialize_UInt16List : AnyValue<List<System.UInt16>> {}

    public class AnySerialize_UInt32 : AnyValue<System.UInt32> {}
    public class AnySerialize_UInt32Array : AnyValue<System.UInt32[]> {}
    public class AnySerialize_UInt32List : AnyValue<List<System.UInt32>> {}

    public class AnySerialize_UInt64 : AnyValue<System.UInt64> {}
    public class AnySerialize_UInt64Array : AnyValue<System.UInt64[]> {}
    public class AnySerialize_UInt64List : AnyValue<List<System.UInt64>> {}

    public class AnySerialize_IntPtr : AnyValue<System.IntPtr> {}
    public class AnySerialize_IntPtrArray : AnyValue<System.IntPtr[]> {}
    public class AnySerialize_IntPtrList : AnyValue<List<System.IntPtr>> {}

    public class AnySerialize_UIntPtr : AnyValue<System.UIntPtr> {}
    public class AnySerialize_UIntPtrArray : AnyValue<System.UIntPtr[]> {}
    public class AnySerialize_UIntPtrList : AnyValue<List<System.UIntPtr>> {}
#endregion

#region UnityEngine Types
    public class AnySerialize_Object<T> : AnyValue<T> where T : UnityEngine.Object {}
    public class AnySerialize_ObjectArray<T> : AnyValue<T[]> where T : UnityEngine.Object {}
    public class AnySerialize_ObjectList<T> : AnyValue<List<T>> where T : UnityEngine.Object {}

    public class AnySerialize_Vector2 : AnyValue<UnityEngine.Vector2> {}
    public class AnySerialize_Vector2Array : AnyValue<UnityEngine.Vector2[]> {}
    public class AnySerialize_Vector2List : AnyValue<List<UnityEngine.Vector2>> {}

    public class AnySerialize_Vector3 : AnyValue<UnityEngine.Vector3> {}
    public class AnySerialize_Vector3Array : AnyValue<UnityEngine.Vector3[]> {}
    public class AnySerialize_Vector3List : AnyValue<List<UnityEngine.Vector3>> {}

    public class AnySerialize_Vector4 : AnyValue<UnityEngine.Vector4> {}
    public class AnySerialize_Vector4Array : AnyValue<UnityEngine.Vector4[]> {}
    public class AnySerialize_Vector4List : AnyValue<List<UnityEngine.Vector4>> {}

    public class AnySerialize_Vector2Int : AnyValue<UnityEngine.Vector2Int> {}
    public class AnySerialize_Vector2IntArray : AnyValue<UnityEngine.Vector2Int[]> {}
    public class AnySerialize_Vector2IntList : AnyValue<List<UnityEngine.Vector2Int>> {}

    public class AnySerialize_Vector3Int : AnyValue<UnityEngine.Vector3Int> {}
    public class AnySerialize_Vector3IntArray : AnyValue<UnityEngine.Vector3Int[]> {}
    public class AnySerialize_Vector3IntList : AnyValue<List<UnityEngine.Vector3Int>> {}

    public class AnySerialize_Quaternion : AnyValue<UnityEngine.Quaternion> {}
    public class AnySerialize_QuaternionArray : AnyValue<UnityEngine.Quaternion[]> {}
    public class AnySerialize_QuaternionList : AnyValue<List<UnityEngine.Quaternion>> {}

    public class AnySerialize_Matrix4x4 : AnyValue<UnityEngine.Matrix4x4> {}
    public class AnySerialize_Matrix4x4Array : AnyValue<UnityEngine.Matrix4x4[]> {}
    public class AnySerialize_Matrix4x4List : AnyValue<List<UnityEngine.Matrix4x4>> {}

    public class AnySerialize_Color : AnyValue<UnityEngine.Color> {}
    public class AnySerialize_ColorArray : AnyValue<UnityEngine.Color[]> {}
    public class AnySerialize_ColorList : AnyValue<List<UnityEngine.Color>> {}

    public class AnySerialize_Rect : AnyValue<UnityEngine.Rect> {}
    public class AnySerialize_RectArray : AnyValue<UnityEngine.Rect[]> {}
    public class AnySerialize_RectList : AnyValue<List<UnityEngine.Rect>> {}

    public class AnySerialize_LayerMask : AnyValue<UnityEngine.LayerMask> {}
    public class AnySerialize_LayerMaskArray : AnyValue<UnityEngine.LayerMask[]> {}
    public class AnySerialize_LayerMaskList : AnyValue<List<UnityEngine.LayerMask>> {}
#endregion

#region Unity.Mathematics Types
#if ENABLE_UNITY_MATHEMATICS

    public class AnySerialize_bool2 : AnyValue<Unity.Mathematics.bool2> {}
    public class AnySerialize_bool2Array : AnyValue<Unity.Mathematics.bool2[]> {}
    public class AnySerialize_bool2List : AnyValue<List<Unity.Mathematics.bool2>> {}

    public class AnySerialize_bool2x2 : AnyValue<Unity.Mathematics.bool2x2> {}
    public class AnySerialize_bool2x2Array : AnyValue<Unity.Mathematics.bool2x2[]> {}
    public class AnySerialize_bool2x2List : AnyValue<List<Unity.Mathematics.bool2x2>> {}

    public class AnySerialize_bool2x3 : AnyValue<Unity.Mathematics.bool2x3> {}
    public class AnySerialize_bool2x3Array : AnyValue<Unity.Mathematics.bool2x3[]> {}
    public class AnySerialize_bool2x3List : AnyValue<List<Unity.Mathematics.bool2x3>> {}

    public class AnySerialize_bool2x4 : AnyValue<Unity.Mathematics.bool2x4> {}
    public class AnySerialize_bool2x4Array : AnyValue<Unity.Mathematics.bool2x4[]> {}
    public class AnySerialize_bool2x4List : AnyValue<List<Unity.Mathematics.bool2x4>> {}

    public class AnySerialize_bool3 : AnyValue<Unity.Mathematics.bool3> {}
    public class AnySerialize_bool3Array : AnyValue<Unity.Mathematics.bool3[]> {}
    public class AnySerialize_bool3List : AnyValue<List<Unity.Mathematics.bool3>> {}

    public class AnySerialize_bool3x2 : AnyValue<Unity.Mathematics.bool3x2> {}
    public class AnySerialize_bool3x2Array : AnyValue<Unity.Mathematics.bool3x2[]> {}
    public class AnySerialize_bool3x2List : AnyValue<List<Unity.Mathematics.bool3x2>> {}

    public class AnySerialize_bool3x3 : AnyValue<Unity.Mathematics.bool3x3> {}
    public class AnySerialize_bool3x3Array : AnyValue<Unity.Mathematics.bool3x3[]> {}
    public class AnySerialize_bool3x3List : AnyValue<List<Unity.Mathematics.bool3x3>> {}

    public class AnySerialize_bool3x4 : AnyValue<Unity.Mathematics.bool3x4> {}
    public class AnySerialize_bool3x4Array : AnyValue<Unity.Mathematics.bool3x4[]> {}
    public class AnySerialize_bool3x4List : AnyValue<List<Unity.Mathematics.bool3x4>> {}

    public class AnySerialize_bool4 : AnyValue<Unity.Mathematics.bool4> {}
    public class AnySerialize_bool4Array : AnyValue<Unity.Mathematics.bool4[]> {}
    public class AnySerialize_bool4List : AnyValue<List<Unity.Mathematics.bool4>> {}

    public class AnySerialize_bool4x2 : AnyValue<Unity.Mathematics.bool4x2> {}
    public class AnySerialize_bool4x2Array : AnyValue<Unity.Mathematics.bool4x2[]> {}
    public class AnySerialize_bool4x2List : AnyValue<List<Unity.Mathematics.bool4x2>> {}

    public class AnySerialize_bool4x3 : AnyValue<Unity.Mathematics.bool4x3> {}
    public class AnySerialize_bool4x3Array : AnyValue<Unity.Mathematics.bool4x3[]> {}
    public class AnySerialize_bool4x3List : AnyValue<List<Unity.Mathematics.bool4x3>> {}

    public class AnySerialize_bool4x4 : AnyValue<Unity.Mathematics.bool4x4> {}
    public class AnySerialize_bool4x4Array : AnyValue<Unity.Mathematics.bool4x4[]> {}
    public class AnySerialize_bool4x4List : AnyValue<List<Unity.Mathematics.bool4x4>> {}

    public class AnySerialize_double2 : AnyValue<Unity.Mathematics.double2> {}
    public class AnySerialize_double2Array : AnyValue<Unity.Mathematics.double2[]> {}
    public class AnySerialize_double2List : AnyValue<List<Unity.Mathematics.double2>> {}

    public class AnySerialize_double2x2 : AnyValue<Unity.Mathematics.double2x2> {}
    public class AnySerialize_double2x2Array : AnyValue<Unity.Mathematics.double2x2[]> {}
    public class AnySerialize_double2x2List : AnyValue<List<Unity.Mathematics.double2x2>> {}

    public class AnySerialize_double2x3 : AnyValue<Unity.Mathematics.double2x3> {}
    public class AnySerialize_double2x3Array : AnyValue<Unity.Mathematics.double2x3[]> {}
    public class AnySerialize_double2x3List : AnyValue<List<Unity.Mathematics.double2x3>> {}

    public class AnySerialize_double2x4 : AnyValue<Unity.Mathematics.double2x4> {}
    public class AnySerialize_double2x4Array : AnyValue<Unity.Mathematics.double2x4[]> {}
    public class AnySerialize_double2x4List : AnyValue<List<Unity.Mathematics.double2x4>> {}

    public class AnySerialize_double3 : AnyValue<Unity.Mathematics.double3> {}
    public class AnySerialize_double3Array : AnyValue<Unity.Mathematics.double3[]> {}
    public class AnySerialize_double3List : AnyValue<List<Unity.Mathematics.double3>> {}

    public class AnySerialize_double3x2 : AnyValue<Unity.Mathematics.double3x2> {}
    public class AnySerialize_double3x2Array : AnyValue<Unity.Mathematics.double3x2[]> {}
    public class AnySerialize_double3x2List : AnyValue<List<Unity.Mathematics.double3x2>> {}

    public class AnySerialize_double3x3 : AnyValue<Unity.Mathematics.double3x3> {}
    public class AnySerialize_double3x3Array : AnyValue<Unity.Mathematics.double3x3[]> {}
    public class AnySerialize_double3x3List : AnyValue<List<Unity.Mathematics.double3x3>> {}

    public class AnySerialize_double3x4 : AnyValue<Unity.Mathematics.double3x4> {}
    public class AnySerialize_double3x4Array : AnyValue<Unity.Mathematics.double3x4[]> {}
    public class AnySerialize_double3x4List : AnyValue<List<Unity.Mathematics.double3x4>> {}

    public class AnySerialize_double4 : AnyValue<Unity.Mathematics.double4> {}
    public class AnySerialize_double4Array : AnyValue<Unity.Mathematics.double4[]> {}
    public class AnySerialize_double4List : AnyValue<List<Unity.Mathematics.double4>> {}

    public class AnySerialize_double4x2 : AnyValue<Unity.Mathematics.double4x2> {}
    public class AnySerialize_double4x2Array : AnyValue<Unity.Mathematics.double4x2[]> {}
    public class AnySerialize_double4x2List : AnyValue<List<Unity.Mathematics.double4x2>> {}

    public class AnySerialize_double4x3 : AnyValue<Unity.Mathematics.double4x3> {}
    public class AnySerialize_double4x3Array : AnyValue<Unity.Mathematics.double4x3[]> {}
    public class AnySerialize_double4x3List : AnyValue<List<Unity.Mathematics.double4x3>> {}

    public class AnySerialize_double4x4 : AnyValue<Unity.Mathematics.double4x4> {}
    public class AnySerialize_double4x4Array : AnyValue<Unity.Mathematics.double4x4[]> {}
    public class AnySerialize_double4x4List : AnyValue<List<Unity.Mathematics.double4x4>> {}

    public class AnySerialize_float2 : AnyValue<Unity.Mathematics.float2> {}
    public class AnySerialize_float2Array : AnyValue<Unity.Mathematics.float2[]> {}
    public class AnySerialize_float2List : AnyValue<List<Unity.Mathematics.float2>> {}

    public class AnySerialize_float2x2 : AnyValue<Unity.Mathematics.float2x2> {}
    public class AnySerialize_float2x2Array : AnyValue<Unity.Mathematics.float2x2[]> {}
    public class AnySerialize_float2x2List : AnyValue<List<Unity.Mathematics.float2x2>> {}

    public class AnySerialize_float2x3 : AnyValue<Unity.Mathematics.float2x3> {}
    public class AnySerialize_float2x3Array : AnyValue<Unity.Mathematics.float2x3[]> {}
    public class AnySerialize_float2x3List : AnyValue<List<Unity.Mathematics.float2x3>> {}

    public class AnySerialize_float2x4 : AnyValue<Unity.Mathematics.float2x4> {}
    public class AnySerialize_float2x4Array : AnyValue<Unity.Mathematics.float2x4[]> {}
    public class AnySerialize_float2x4List : AnyValue<List<Unity.Mathematics.float2x4>> {}

    public class AnySerialize_float3 : AnyValue<Unity.Mathematics.float3> {}
    public class AnySerialize_float3Array : AnyValue<Unity.Mathematics.float3[]> {}
    public class AnySerialize_float3List : AnyValue<List<Unity.Mathematics.float3>> {}

    public class AnySerialize_float3x2 : AnyValue<Unity.Mathematics.float3x2> {}
    public class AnySerialize_float3x2Array : AnyValue<Unity.Mathematics.float3x2[]> {}
    public class AnySerialize_float3x2List : AnyValue<List<Unity.Mathematics.float3x2>> {}

    public class AnySerialize_float3x3 : AnyValue<Unity.Mathematics.float3x3> {}
    public class AnySerialize_float3x3Array : AnyValue<Unity.Mathematics.float3x3[]> {}
    public class AnySerialize_float3x3List : AnyValue<List<Unity.Mathematics.float3x3>> {}

    public class AnySerialize_float3x4 : AnyValue<Unity.Mathematics.float3x4> {}
    public class AnySerialize_float3x4Array : AnyValue<Unity.Mathematics.float3x4[]> {}
    public class AnySerialize_float3x4List : AnyValue<List<Unity.Mathematics.float3x4>> {}

    public class AnySerialize_float4 : AnyValue<Unity.Mathematics.float4> {}
    public class AnySerialize_float4Array : AnyValue<Unity.Mathematics.float4[]> {}
    public class AnySerialize_float4List : AnyValue<List<Unity.Mathematics.float4>> {}

    public class AnySerialize_float4x2 : AnyValue<Unity.Mathematics.float4x2> {}
    public class AnySerialize_float4x2Array : AnyValue<Unity.Mathematics.float4x2[]> {}
    public class AnySerialize_float4x2List : AnyValue<List<Unity.Mathematics.float4x2>> {}

    public class AnySerialize_float4x3 : AnyValue<Unity.Mathematics.float4x3> {}
    public class AnySerialize_float4x3Array : AnyValue<Unity.Mathematics.float4x3[]> {}
    public class AnySerialize_float4x3List : AnyValue<List<Unity.Mathematics.float4x3>> {}

    public class AnySerialize_float4x4 : AnyValue<Unity.Mathematics.float4x4> {}
    public class AnySerialize_float4x4Array : AnyValue<Unity.Mathematics.float4x4[]> {}
    public class AnySerialize_float4x4List : AnyValue<List<Unity.Mathematics.float4x4>> {}

    public class AnySerialize_half : AnyValue<Unity.Mathematics.half> {}
    public class AnySerialize_halfArray : AnyValue<Unity.Mathematics.half[]> {}
    public class AnySerialize_halfList : AnyValue<List<Unity.Mathematics.half>> {}

    public class AnySerialize_half2 : AnyValue<Unity.Mathematics.half2> {}
    public class AnySerialize_half2Array : AnyValue<Unity.Mathematics.half2[]> {}
    public class AnySerialize_half2List : AnyValue<List<Unity.Mathematics.half2>> {}

    public class AnySerialize_half3 : AnyValue<Unity.Mathematics.half3> {}
    public class AnySerialize_half3Array : AnyValue<Unity.Mathematics.half3[]> {}
    public class AnySerialize_half3List : AnyValue<List<Unity.Mathematics.half3>> {}

    public class AnySerialize_half4 : AnyValue<Unity.Mathematics.half4> {}
    public class AnySerialize_half4Array : AnyValue<Unity.Mathematics.half4[]> {}
    public class AnySerialize_half4List : AnyValue<List<Unity.Mathematics.half4>> {}

    public class AnySerialize_int2 : AnyValue<Unity.Mathematics.int2> {}
    public class AnySerialize_int2Array : AnyValue<Unity.Mathematics.int2[]> {}
    public class AnySerialize_int2List : AnyValue<List<Unity.Mathematics.int2>> {}

    public class AnySerialize_int2x2 : AnyValue<Unity.Mathematics.int2x2> {}
    public class AnySerialize_int2x2Array : AnyValue<Unity.Mathematics.int2x2[]> {}
    public class AnySerialize_int2x2List : AnyValue<List<Unity.Mathematics.int2x2>> {}

    public class AnySerialize_int2x3 : AnyValue<Unity.Mathematics.int2x3> {}
    public class AnySerialize_int2x3Array : AnyValue<Unity.Mathematics.int2x3[]> {}
    public class AnySerialize_int2x3List : AnyValue<List<Unity.Mathematics.int2x3>> {}

    public class AnySerialize_int2x4 : AnyValue<Unity.Mathematics.int2x4> {}
    public class AnySerialize_int2x4Array : AnyValue<Unity.Mathematics.int2x4[]> {}
    public class AnySerialize_int2x4List : AnyValue<List<Unity.Mathematics.int2x4>> {}

    public class AnySerialize_int3 : AnyValue<Unity.Mathematics.int3> {}
    public class AnySerialize_int3Array : AnyValue<Unity.Mathematics.int3[]> {}
    public class AnySerialize_int3List : AnyValue<List<Unity.Mathematics.int3>> {}

    public class AnySerialize_int3x2 : AnyValue<Unity.Mathematics.int3x2> {}
    public class AnySerialize_int3x2Array : AnyValue<Unity.Mathematics.int3x2[]> {}
    public class AnySerialize_int3x2List : AnyValue<List<Unity.Mathematics.int3x2>> {}

    public class AnySerialize_int3x3 : AnyValue<Unity.Mathematics.int3x3> {}
    public class AnySerialize_int3x3Array : AnyValue<Unity.Mathematics.int3x3[]> {}
    public class AnySerialize_int3x3List : AnyValue<List<Unity.Mathematics.int3x3>> {}

    public class AnySerialize_int3x4 : AnyValue<Unity.Mathematics.int3x4> {}
    public class AnySerialize_int3x4Array : AnyValue<Unity.Mathematics.int3x4[]> {}
    public class AnySerialize_int3x4List : AnyValue<List<Unity.Mathematics.int3x4>> {}

    public class AnySerialize_int4 : AnyValue<Unity.Mathematics.int4> {}
    public class AnySerialize_int4Array : AnyValue<Unity.Mathematics.int4[]> {}
    public class AnySerialize_int4List : AnyValue<List<Unity.Mathematics.int4>> {}

    public class AnySerialize_int4x2 : AnyValue<Unity.Mathematics.int4x2> {}
    public class AnySerialize_int4x2Array : AnyValue<Unity.Mathematics.int4x2[]> {}
    public class AnySerialize_int4x2List : AnyValue<List<Unity.Mathematics.int4x2>> {}

    public class AnySerialize_int4x3 : AnyValue<Unity.Mathematics.int4x3> {}
    public class AnySerialize_int4x3Array : AnyValue<Unity.Mathematics.int4x3[]> {}
    public class AnySerialize_int4x3List : AnyValue<List<Unity.Mathematics.int4x3>> {}

    public class AnySerialize_int4x4 : AnyValue<Unity.Mathematics.int4x4> {}
    public class AnySerialize_int4x4Array : AnyValue<Unity.Mathematics.int4x4[]> {}
    public class AnySerialize_int4x4List : AnyValue<List<Unity.Mathematics.int4x4>> {}

    public class AnySerialize_quaternion : AnyValue<Unity.Mathematics.quaternion> {}
    public class AnySerialize_quaternionArray : AnyValue<Unity.Mathematics.quaternion[]> {}
    public class AnySerialize_quaternionList : AnyValue<List<Unity.Mathematics.quaternion>> {}

    public class AnySerialize_Random : AnyValue<Unity.Mathematics.Random> {}
    public class AnySerialize_RandomArray : AnyValue<Unity.Mathematics.Random[]> {}
    public class AnySerialize_RandomList : AnyValue<List<Unity.Mathematics.Random>> {}

    public class AnySerialize_RigidTransform : AnyValue<Unity.Mathematics.RigidTransform> {}
    public class AnySerialize_RigidTransformArray : AnyValue<Unity.Mathematics.RigidTransform[]> {}
    public class AnySerialize_RigidTransformList : AnyValue<List<Unity.Mathematics.RigidTransform>> {}

    public class AnySerialize_uint2 : AnyValue<Unity.Mathematics.uint2> {}
    public class AnySerialize_uint2Array : AnyValue<Unity.Mathematics.uint2[]> {}
    public class AnySerialize_uint2List : AnyValue<List<Unity.Mathematics.uint2>> {}

    public class AnySerialize_uint2x2 : AnyValue<Unity.Mathematics.uint2x2> {}
    public class AnySerialize_uint2x2Array : AnyValue<Unity.Mathematics.uint2x2[]> {}
    public class AnySerialize_uint2x2List : AnyValue<List<Unity.Mathematics.uint2x2>> {}

    public class AnySerialize_uint2x3 : AnyValue<Unity.Mathematics.uint2x3> {}
    public class AnySerialize_uint2x3Array : AnyValue<Unity.Mathematics.uint2x3[]> {}
    public class AnySerialize_uint2x3List : AnyValue<List<Unity.Mathematics.uint2x3>> {}

    public class AnySerialize_uint2x4 : AnyValue<Unity.Mathematics.uint2x4> {}
    public class AnySerialize_uint2x4Array : AnyValue<Unity.Mathematics.uint2x4[]> {}
    public class AnySerialize_uint2x4List : AnyValue<List<Unity.Mathematics.uint2x4>> {}

    public class AnySerialize_uint3 : AnyValue<Unity.Mathematics.uint3> {}
    public class AnySerialize_uint3Array : AnyValue<Unity.Mathematics.uint3[]> {}
    public class AnySerialize_uint3List : AnyValue<List<Unity.Mathematics.uint3>> {}

    public class AnySerialize_uint3x2 : AnyValue<Unity.Mathematics.uint3x2> {}
    public class AnySerialize_uint3x2Array : AnyValue<Unity.Mathematics.uint3x2[]> {}
    public class AnySerialize_uint3x2List : AnyValue<List<Unity.Mathematics.uint3x2>> {}

    public class AnySerialize_uint3x3 : AnyValue<Unity.Mathematics.uint3x3> {}
    public class AnySerialize_uint3x3Array : AnyValue<Unity.Mathematics.uint3x3[]> {}
    public class AnySerialize_uint3x3List : AnyValue<List<Unity.Mathematics.uint3x3>> {}

    public class AnySerialize_uint3x4 : AnyValue<Unity.Mathematics.uint3x4> {}
    public class AnySerialize_uint3x4Array : AnyValue<Unity.Mathematics.uint3x4[]> {}
    public class AnySerialize_uint3x4List : AnyValue<List<Unity.Mathematics.uint3x4>> {}

    public class AnySerialize_uint4 : AnyValue<Unity.Mathematics.uint4> {}
    public class AnySerialize_uint4Array : AnyValue<Unity.Mathematics.uint4[]> {}
    public class AnySerialize_uint4List : AnyValue<List<Unity.Mathematics.uint4>> {}

    public class AnySerialize_uint4x2 : AnyValue<Unity.Mathematics.uint4x2> {}
    public class AnySerialize_uint4x2Array : AnyValue<Unity.Mathematics.uint4x2[]> {}
    public class AnySerialize_uint4x2List : AnyValue<List<Unity.Mathematics.uint4x2>> {}

    public class AnySerialize_uint4x3 : AnyValue<Unity.Mathematics.uint4x3> {}
    public class AnySerialize_uint4x3Array : AnyValue<Unity.Mathematics.uint4x3[]> {}
    public class AnySerialize_uint4x3List : AnyValue<List<Unity.Mathematics.uint4x3>> {}

    public class AnySerialize_uint4x4 : AnyValue<Unity.Mathematics.uint4x4> {}
    public class AnySerialize_uint4x4Array : AnyValue<Unity.Mathematics.uint4x4[]> {}
    public class AnySerialize_uint4x4List : AnyValue<List<Unity.Mathematics.uint4x4>> {}
#endif
#endregion
}

