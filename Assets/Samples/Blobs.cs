using Unity.Entities;
using UnityEngine;

namespace AnySerialize
{
    public class Blobs : MonoBehaviour
    {
        [AnySerialize] public BlobAssetReference<int> IntBlob { get; }
        [AnySerialize] public BlobAssetReference<BlobPtr<int>> IntPtrBlob { get; }
        [AnySerialize] public BlobAssetReference<BlobString> StringBlob { get; }
        [AnySerialize] public BlobAssetReference<BlobArray<BlobString>> StringArrayBlob { get; }

        [ContextMenu(nameof(Print))]
        void Print()
        {
            Debug.Log($"{nameof(IntBlob)} = {IntBlob.Value}");
            Debug.Log($"{nameof(IntPtrBlob)} = {IntPtrBlob.Value.Value}");
            Debug.Log($"{nameof(StringBlob)} = {StringBlob.Value.ToString()}");
            var stringArray = new string[StringArrayBlob.Value.Length];
            for (var i = 0; i < stringArray.Length; i++) stringArray[i] = StringArrayBlob.Value[i].ToString();
            Debug.Log($"{nameof(StringArrayBlob)} = {string.Join(",", stringArray)}");
        }
    }
}