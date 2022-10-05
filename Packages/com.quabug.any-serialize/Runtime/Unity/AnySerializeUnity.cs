
using System.Collections.Generic;

namespace AnySerialize
{
    [System.Serializable] public class AnyValue_Object<T> : AnyValue<T> where T : UnityEngine.Object {}
    [System.Serializable] public class AnyArray_Object<T> : AnyValue<T[]> where T : UnityEngine.Object {}
    [System.Serializable] public class AnyList_Object<T> : AnyValue<List<T>> where T : UnityEngine.Object {}

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
}