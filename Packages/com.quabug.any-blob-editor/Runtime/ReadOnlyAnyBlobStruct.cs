
using System;
using UnityEngine;
using Unity.Assertions;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace AnySerialize.Blob
{
    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
    {
        [SerializeField] private TAny0 _field0 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 1);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 2);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 3);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 4);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 5);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 6);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 7);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
        where TAny7 : IReadOnlyAnyBlob<T7>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 8);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);

            var fieldOffset7 = UnsafeUtility.GetFieldOffset(fields[7]);
            ref var fieldData7 = ref UnsafeUtility.AsRef<T7>(dataPtr + fieldOffset7);
            _field7.Build(ref builder, ref fieldData7);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
        where TAny7 : IReadOnlyAnyBlob<T7>
        where TAny8 : IReadOnlyAnyBlob<T8>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 9);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);

            var fieldOffset7 = UnsafeUtility.GetFieldOffset(fields[7]);
            ref var fieldData7 = ref UnsafeUtility.AsRef<T7>(dataPtr + fieldOffset7);
            _field7.Build(ref builder, ref fieldData7);

            var fieldOffset8 = UnsafeUtility.GetFieldOffset(fields[8]);
            ref var fieldData8 = ref UnsafeUtility.AsRef<T8>(dataPtr + fieldOffset8);
            _field8.Build(ref builder, ref fieldData8);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
        where TAny7 : IReadOnlyAnyBlob<T7>
        where TAny8 : IReadOnlyAnyBlob<T8>
        where TAny9 : IReadOnlyAnyBlob<T9>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 10);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);

            var fieldOffset7 = UnsafeUtility.GetFieldOffset(fields[7]);
            ref var fieldData7 = ref UnsafeUtility.AsRef<T7>(dataPtr + fieldOffset7);
            _field7.Build(ref builder, ref fieldData7);

            var fieldOffset8 = UnsafeUtility.GetFieldOffset(fields[8]);
            ref var fieldData8 = ref UnsafeUtility.AsRef<T8>(dataPtr + fieldOffset8);
            _field8.Build(ref builder, ref fieldData8);

            var fieldOffset9 = UnsafeUtility.GetFieldOffset(fields[9]);
            ref var fieldData9 = ref UnsafeUtility.AsRef<T9>(dataPtr + fieldOffset9);
            _field9.Build(ref builder, ref fieldData9);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
        where TAny7 : IReadOnlyAnyBlob<T7>
        where TAny8 : IReadOnlyAnyBlob<T8>
        where TAny9 : IReadOnlyAnyBlob<T9>
        where TAny10 : IReadOnlyAnyBlob<T10>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 11);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);

            var fieldOffset7 = UnsafeUtility.GetFieldOffset(fields[7]);
            ref var fieldData7 = ref UnsafeUtility.AsRef<T7>(dataPtr + fieldOffset7);
            _field7.Build(ref builder, ref fieldData7);

            var fieldOffset8 = UnsafeUtility.GetFieldOffset(fields[8]);
            ref var fieldData8 = ref UnsafeUtility.AsRef<T8>(dataPtr + fieldOffset8);
            _field8.Build(ref builder, ref fieldData8);

            var fieldOffset9 = UnsafeUtility.GetFieldOffset(fields[9]);
            ref var fieldData9 = ref UnsafeUtility.AsRef<T9>(dataPtr + fieldOffset9);
            _field9.Build(ref builder, ref fieldData9);

            var fieldOffset10 = UnsafeUtility.GetFieldOffset(fields[10]);
            ref var fieldData10 = ref UnsafeUtility.AsRef<T10>(dataPtr + fieldOffset10);
            _field10.Build(ref builder, ref fieldData10);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
        where TAny7 : IReadOnlyAnyBlob<T7>
        where TAny8 : IReadOnlyAnyBlob<T8>
        where TAny9 : IReadOnlyAnyBlob<T9>
        where TAny10 : IReadOnlyAnyBlob<T10>
        where TAny11 : IReadOnlyAnyBlob<T11>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 12);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);

            var fieldOffset7 = UnsafeUtility.GetFieldOffset(fields[7]);
            ref var fieldData7 = ref UnsafeUtility.AsRef<T7>(dataPtr + fieldOffset7);
            _field7.Build(ref builder, ref fieldData7);

            var fieldOffset8 = UnsafeUtility.GetFieldOffset(fields[8]);
            ref var fieldData8 = ref UnsafeUtility.AsRef<T8>(dataPtr + fieldOffset8);
            _field8.Build(ref builder, ref fieldData8);

            var fieldOffset9 = UnsafeUtility.GetFieldOffset(fields[9]);
            ref var fieldData9 = ref UnsafeUtility.AsRef<T9>(dataPtr + fieldOffset9);
            _field9.Build(ref builder, ref fieldData9);

            var fieldOffset10 = UnsafeUtility.GetFieldOffset(fields[10]);
            ref var fieldData10 = ref UnsafeUtility.AsRef<T10>(dataPtr + fieldOffset10);
            _field10.Build(ref builder, ref fieldData10);

            var fieldOffset11 = UnsafeUtility.GetFieldOffset(fields[11]);
            ref var fieldData11 = ref UnsafeUtility.AsRef<T11>(dataPtr + fieldOffset11);
            _field11.Build(ref builder, ref fieldData11);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where T12 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
        where TAny7 : IReadOnlyAnyBlob<T7>
        where TAny8 : IReadOnlyAnyBlob<T8>
        where TAny9 : IReadOnlyAnyBlob<T9>
        where TAny10 : IReadOnlyAnyBlob<T10>
        where TAny11 : IReadOnlyAnyBlob<T11>
        where TAny12 : IReadOnlyAnyBlob<T12>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 13);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);

            var fieldOffset7 = UnsafeUtility.GetFieldOffset(fields[7]);
            ref var fieldData7 = ref UnsafeUtility.AsRef<T7>(dataPtr + fieldOffset7);
            _field7.Build(ref builder, ref fieldData7);

            var fieldOffset8 = UnsafeUtility.GetFieldOffset(fields[8]);
            ref var fieldData8 = ref UnsafeUtility.AsRef<T8>(dataPtr + fieldOffset8);
            _field8.Build(ref builder, ref fieldData8);

            var fieldOffset9 = UnsafeUtility.GetFieldOffset(fields[9]);
            ref var fieldData9 = ref UnsafeUtility.AsRef<T9>(dataPtr + fieldOffset9);
            _field9.Build(ref builder, ref fieldData9);

            var fieldOffset10 = UnsafeUtility.GetFieldOffset(fields[10]);
            ref var fieldData10 = ref UnsafeUtility.AsRef<T10>(dataPtr + fieldOffset10);
            _field10.Build(ref builder, ref fieldData10);

            var fieldOffset11 = UnsafeUtility.GetFieldOffset(fields[11]);
            ref var fieldData11 = ref UnsafeUtility.AsRef<T11>(dataPtr + fieldOffset11);
            _field11.Build(ref builder, ref fieldData11);

            var fieldOffset12 = UnsafeUtility.GetFieldOffset(fields[12]);
            ref var fieldData12 = ref UnsafeUtility.AsRef<T12>(dataPtr + fieldOffset12);
            _field12.Build(ref builder, ref fieldData12);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where T12 : unmanaged
        where T13 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
        where TAny7 : IReadOnlyAnyBlob<T7>
        where TAny8 : IReadOnlyAnyBlob<T8>
        where TAny9 : IReadOnlyAnyBlob<T9>
        where TAny10 : IReadOnlyAnyBlob<T10>
        where TAny11 : IReadOnlyAnyBlob<T11>
        where TAny12 : IReadOnlyAnyBlob<T12>
        where TAny13 : IReadOnlyAnyBlob<T13>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 14);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);

            var fieldOffset7 = UnsafeUtility.GetFieldOffset(fields[7]);
            ref var fieldData7 = ref UnsafeUtility.AsRef<T7>(dataPtr + fieldOffset7);
            _field7.Build(ref builder, ref fieldData7);

            var fieldOffset8 = UnsafeUtility.GetFieldOffset(fields[8]);
            ref var fieldData8 = ref UnsafeUtility.AsRef<T8>(dataPtr + fieldOffset8);
            _field8.Build(ref builder, ref fieldData8);

            var fieldOffset9 = UnsafeUtility.GetFieldOffset(fields[9]);
            ref var fieldData9 = ref UnsafeUtility.AsRef<T9>(dataPtr + fieldOffset9);
            _field9.Build(ref builder, ref fieldData9);

            var fieldOffset10 = UnsafeUtility.GetFieldOffset(fields[10]);
            ref var fieldData10 = ref UnsafeUtility.AsRef<T10>(dataPtr + fieldOffset10);
            _field10.Build(ref builder, ref fieldData10);

            var fieldOffset11 = UnsafeUtility.GetFieldOffset(fields[11]);
            ref var fieldData11 = ref UnsafeUtility.AsRef<T11>(dataPtr + fieldOffset11);
            _field11.Build(ref builder, ref fieldData11);

            var fieldOffset12 = UnsafeUtility.GetFieldOffset(fields[12]);
            ref var fieldData12 = ref UnsafeUtility.AsRef<T12>(dataPtr + fieldOffset12);
            _field12.Build(ref builder, ref fieldData12);

            var fieldOffset13 = UnsafeUtility.GetFieldOffset(fields[13]);
            ref var fieldData13 = ref UnsafeUtility.AsRef<T13>(dataPtr + fieldOffset13);
            _field13.Build(ref builder, ref fieldData13);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny14> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where T12 : unmanaged
        where T13 : unmanaged
        where T14 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
        where TAny7 : IReadOnlyAnyBlob<T7>
        where TAny8 : IReadOnlyAnyBlob<T8>
        where TAny9 : IReadOnlyAnyBlob<T9>
        where TAny10 : IReadOnlyAnyBlob<T10>
        where TAny11 : IReadOnlyAnyBlob<T11>
        where TAny12 : IReadOnlyAnyBlob<T12>
        where TAny13 : IReadOnlyAnyBlob<T13>
        where TAny14 : IReadOnlyAnyBlob<T14>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;
        [SerializeField] private TAny14 _field14 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 15);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);

            var fieldOffset7 = UnsafeUtility.GetFieldOffset(fields[7]);
            ref var fieldData7 = ref UnsafeUtility.AsRef<T7>(dataPtr + fieldOffset7);
            _field7.Build(ref builder, ref fieldData7);

            var fieldOffset8 = UnsafeUtility.GetFieldOffset(fields[8]);
            ref var fieldData8 = ref UnsafeUtility.AsRef<T8>(dataPtr + fieldOffset8);
            _field8.Build(ref builder, ref fieldData8);

            var fieldOffset9 = UnsafeUtility.GetFieldOffset(fields[9]);
            ref var fieldData9 = ref UnsafeUtility.AsRef<T9>(dataPtr + fieldOffset9);
            _field9.Build(ref builder, ref fieldData9);

            var fieldOffset10 = UnsafeUtility.GetFieldOffset(fields[10]);
            ref var fieldData10 = ref UnsafeUtility.AsRef<T10>(dataPtr + fieldOffset10);
            _field10.Build(ref builder, ref fieldData10);

            var fieldOffset11 = UnsafeUtility.GetFieldOffset(fields[11]);
            ref var fieldData11 = ref UnsafeUtility.AsRef<T11>(dataPtr + fieldOffset11);
            _field11.Build(ref builder, ref fieldData11);

            var fieldOffset12 = UnsafeUtility.GetFieldOffset(fields[12]);
            ref var fieldData12 = ref UnsafeUtility.AsRef<T12>(dataPtr + fieldOffset12);
            _field12.Build(ref builder, ref fieldData12);

            var fieldOffset13 = UnsafeUtility.GetFieldOffset(fields[13]);
            ref var fieldData13 = ref UnsafeUtility.AsRef<T13>(dataPtr + fieldOffset13);
            _field13.Build(ref builder, ref fieldData13);

            var fieldOffset14 = UnsafeUtility.GetFieldOffset(fields[14]);
            ref var fieldData14 = ref UnsafeUtility.AsRef<T14>(dataPtr + fieldOffset14);
            _field14.Build(ref builder, ref fieldData14);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny14, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny15> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where T12 : unmanaged
        where T13 : unmanaged
        where T14 : unmanaged
        where T15 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
        where TAny7 : IReadOnlyAnyBlob<T7>
        where TAny8 : IReadOnlyAnyBlob<T8>
        where TAny9 : IReadOnlyAnyBlob<T9>
        where TAny10 : IReadOnlyAnyBlob<T10>
        where TAny11 : IReadOnlyAnyBlob<T11>
        where TAny12 : IReadOnlyAnyBlob<T12>
        where TAny13 : IReadOnlyAnyBlob<T13>
        where TAny14 : IReadOnlyAnyBlob<T14>
        where TAny15 : IReadOnlyAnyBlob<T15>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;
        [SerializeField] private TAny14 _field14 = default!;
        [SerializeField] private TAny15 _field15 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 16);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);

            var fieldOffset7 = UnsafeUtility.GetFieldOffset(fields[7]);
            ref var fieldData7 = ref UnsafeUtility.AsRef<T7>(dataPtr + fieldOffset7);
            _field7.Build(ref builder, ref fieldData7);

            var fieldOffset8 = UnsafeUtility.GetFieldOffset(fields[8]);
            ref var fieldData8 = ref UnsafeUtility.AsRef<T8>(dataPtr + fieldOffset8);
            _field8.Build(ref builder, ref fieldData8);

            var fieldOffset9 = UnsafeUtility.GetFieldOffset(fields[9]);
            ref var fieldData9 = ref UnsafeUtility.AsRef<T9>(dataPtr + fieldOffset9);
            _field9.Build(ref builder, ref fieldData9);

            var fieldOffset10 = UnsafeUtility.GetFieldOffset(fields[10]);
            ref var fieldData10 = ref UnsafeUtility.AsRef<T10>(dataPtr + fieldOffset10);
            _field10.Build(ref builder, ref fieldData10);

            var fieldOffset11 = UnsafeUtility.GetFieldOffset(fields[11]);
            ref var fieldData11 = ref UnsafeUtility.AsRef<T11>(dataPtr + fieldOffset11);
            _field11.Build(ref builder, ref fieldData11);

            var fieldOffset12 = UnsafeUtility.GetFieldOffset(fields[12]);
            ref var fieldData12 = ref UnsafeUtility.AsRef<T12>(dataPtr + fieldOffset12);
            _field12.Build(ref builder, ref fieldData12);

            var fieldOffset13 = UnsafeUtility.GetFieldOffset(fields[13]);
            ref var fieldData13 = ref UnsafeUtility.AsRef<T13>(dataPtr + fieldOffset13);
            _field13.Build(ref builder, ref fieldData13);

            var fieldOffset14 = UnsafeUtility.GetFieldOffset(fields[14]);
            ref var fieldData14 = ref UnsafeUtility.AsRef<T14>(dataPtr + fieldOffset14);
            _field14.Build(ref builder, ref fieldData14);

            var fieldOffset15 = UnsafeUtility.GetFieldOffset(fields[15]);
            ref var fieldData15 = ref UnsafeUtility.AsRef<T15>(dataPtr + fieldOffset15);
            _field15.Build(ref builder, ref fieldData15);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyFieldType(nameof(T))] T16, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny14, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny15, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny16> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where T12 : unmanaged
        where T13 : unmanaged
        where T14 : unmanaged
        where T15 : unmanaged
        where T16 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
        where TAny7 : IReadOnlyAnyBlob<T7>
        where TAny8 : IReadOnlyAnyBlob<T8>
        where TAny9 : IReadOnlyAnyBlob<T9>
        where TAny10 : IReadOnlyAnyBlob<T10>
        where TAny11 : IReadOnlyAnyBlob<T11>
        where TAny12 : IReadOnlyAnyBlob<T12>
        where TAny13 : IReadOnlyAnyBlob<T13>
        where TAny14 : IReadOnlyAnyBlob<T14>
        where TAny15 : IReadOnlyAnyBlob<T15>
        where TAny16 : IReadOnlyAnyBlob<T16>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;
        [SerializeField] private TAny14 _field14 = default!;
        [SerializeField] private TAny15 _field15 = default!;
        [SerializeField] private TAny16 _field16 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 17);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);

            var fieldOffset7 = UnsafeUtility.GetFieldOffset(fields[7]);
            ref var fieldData7 = ref UnsafeUtility.AsRef<T7>(dataPtr + fieldOffset7);
            _field7.Build(ref builder, ref fieldData7);

            var fieldOffset8 = UnsafeUtility.GetFieldOffset(fields[8]);
            ref var fieldData8 = ref UnsafeUtility.AsRef<T8>(dataPtr + fieldOffset8);
            _field8.Build(ref builder, ref fieldData8);

            var fieldOffset9 = UnsafeUtility.GetFieldOffset(fields[9]);
            ref var fieldData9 = ref UnsafeUtility.AsRef<T9>(dataPtr + fieldOffset9);
            _field9.Build(ref builder, ref fieldData9);

            var fieldOffset10 = UnsafeUtility.GetFieldOffset(fields[10]);
            ref var fieldData10 = ref UnsafeUtility.AsRef<T10>(dataPtr + fieldOffset10);
            _field10.Build(ref builder, ref fieldData10);

            var fieldOffset11 = UnsafeUtility.GetFieldOffset(fields[11]);
            ref var fieldData11 = ref UnsafeUtility.AsRef<T11>(dataPtr + fieldOffset11);
            _field11.Build(ref builder, ref fieldData11);

            var fieldOffset12 = UnsafeUtility.GetFieldOffset(fields[12]);
            ref var fieldData12 = ref UnsafeUtility.AsRef<T12>(dataPtr + fieldOffset12);
            _field12.Build(ref builder, ref fieldData12);

            var fieldOffset13 = UnsafeUtility.GetFieldOffset(fields[13]);
            ref var fieldData13 = ref UnsafeUtility.AsRef<T13>(dataPtr + fieldOffset13);
            _field13.Build(ref builder, ref fieldData13);

            var fieldOffset14 = UnsafeUtility.GetFieldOffset(fields[14]);
            ref var fieldData14 = ref UnsafeUtility.AsRef<T14>(dataPtr + fieldOffset14);
            _field14.Build(ref builder, ref fieldData14);

            var fieldOffset15 = UnsafeUtility.GetFieldOffset(fields[15]);
            ref var fieldData15 = ref UnsafeUtility.AsRef<T15>(dataPtr + fieldOffset15);
            _field15.Build(ref builder, ref fieldData15);

            var fieldOffset16 = UnsafeUtility.GetFieldOffset(fields[16]);
            ref var fieldData16 = ref UnsafeUtility.AsRef<T16>(dataPtr + fieldOffset16);
            _field16.Build(ref builder, ref fieldData16);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyFieldType(nameof(T))] T16, [AnyFieldType(nameof(T))] T17, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny14, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny15, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny16, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny17> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where T12 : unmanaged
        where T13 : unmanaged
        where T14 : unmanaged
        where T15 : unmanaged
        where T16 : unmanaged
        where T17 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
        where TAny7 : IReadOnlyAnyBlob<T7>
        where TAny8 : IReadOnlyAnyBlob<T8>
        where TAny9 : IReadOnlyAnyBlob<T9>
        where TAny10 : IReadOnlyAnyBlob<T10>
        where TAny11 : IReadOnlyAnyBlob<T11>
        where TAny12 : IReadOnlyAnyBlob<T12>
        where TAny13 : IReadOnlyAnyBlob<T13>
        where TAny14 : IReadOnlyAnyBlob<T14>
        where TAny15 : IReadOnlyAnyBlob<T15>
        where TAny16 : IReadOnlyAnyBlob<T16>
        where TAny17 : IReadOnlyAnyBlob<T17>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;
        [SerializeField] private TAny14 _field14 = default!;
        [SerializeField] private TAny15 _field15 = default!;
        [SerializeField] private TAny16 _field16 = default!;
        [SerializeField] private TAny17 _field17 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 18);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);

            var fieldOffset7 = UnsafeUtility.GetFieldOffset(fields[7]);
            ref var fieldData7 = ref UnsafeUtility.AsRef<T7>(dataPtr + fieldOffset7);
            _field7.Build(ref builder, ref fieldData7);

            var fieldOffset8 = UnsafeUtility.GetFieldOffset(fields[8]);
            ref var fieldData8 = ref UnsafeUtility.AsRef<T8>(dataPtr + fieldOffset8);
            _field8.Build(ref builder, ref fieldData8);

            var fieldOffset9 = UnsafeUtility.GetFieldOffset(fields[9]);
            ref var fieldData9 = ref UnsafeUtility.AsRef<T9>(dataPtr + fieldOffset9);
            _field9.Build(ref builder, ref fieldData9);

            var fieldOffset10 = UnsafeUtility.GetFieldOffset(fields[10]);
            ref var fieldData10 = ref UnsafeUtility.AsRef<T10>(dataPtr + fieldOffset10);
            _field10.Build(ref builder, ref fieldData10);

            var fieldOffset11 = UnsafeUtility.GetFieldOffset(fields[11]);
            ref var fieldData11 = ref UnsafeUtility.AsRef<T11>(dataPtr + fieldOffset11);
            _field11.Build(ref builder, ref fieldData11);

            var fieldOffset12 = UnsafeUtility.GetFieldOffset(fields[12]);
            ref var fieldData12 = ref UnsafeUtility.AsRef<T12>(dataPtr + fieldOffset12);
            _field12.Build(ref builder, ref fieldData12);

            var fieldOffset13 = UnsafeUtility.GetFieldOffset(fields[13]);
            ref var fieldData13 = ref UnsafeUtility.AsRef<T13>(dataPtr + fieldOffset13);
            _field13.Build(ref builder, ref fieldData13);

            var fieldOffset14 = UnsafeUtility.GetFieldOffset(fields[14]);
            ref var fieldData14 = ref UnsafeUtility.AsRef<T14>(dataPtr + fieldOffset14);
            _field14.Build(ref builder, ref fieldData14);

            var fieldOffset15 = UnsafeUtility.GetFieldOffset(fields[15]);
            ref var fieldData15 = ref UnsafeUtility.AsRef<T15>(dataPtr + fieldOffset15);
            _field15.Build(ref builder, ref fieldData15);

            var fieldOffset16 = UnsafeUtility.GetFieldOffset(fields[16]);
            ref var fieldData16 = ref UnsafeUtility.AsRef<T16>(dataPtr + fieldOffset16);
            _field16.Build(ref builder, ref fieldData16);

            var fieldOffset17 = UnsafeUtility.GetFieldOffset(fields[17]);
            ref var fieldData17 = ref UnsafeUtility.AsRef<T17>(dataPtr + fieldOffset17);
            _field17.Build(ref builder, ref fieldData17);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyFieldType(nameof(T))] T16, [AnyFieldType(nameof(T))] T17, [AnyFieldType(nameof(T))] T18, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny14, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny15, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny16, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny17, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny18> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where T12 : unmanaged
        where T13 : unmanaged
        where T14 : unmanaged
        where T15 : unmanaged
        where T16 : unmanaged
        where T17 : unmanaged
        where T18 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
        where TAny7 : IReadOnlyAnyBlob<T7>
        where TAny8 : IReadOnlyAnyBlob<T8>
        where TAny9 : IReadOnlyAnyBlob<T9>
        where TAny10 : IReadOnlyAnyBlob<T10>
        where TAny11 : IReadOnlyAnyBlob<T11>
        where TAny12 : IReadOnlyAnyBlob<T12>
        where TAny13 : IReadOnlyAnyBlob<T13>
        where TAny14 : IReadOnlyAnyBlob<T14>
        where TAny15 : IReadOnlyAnyBlob<T15>
        where TAny16 : IReadOnlyAnyBlob<T16>
        where TAny17 : IReadOnlyAnyBlob<T17>
        where TAny18 : IReadOnlyAnyBlob<T18>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;
        [SerializeField] private TAny14 _field14 = default!;
        [SerializeField] private TAny15 _field15 = default!;
        [SerializeField] private TAny16 _field16 = default!;
        [SerializeField] private TAny17 _field17 = default!;
        [SerializeField] private TAny18 _field18 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 19);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);

            var fieldOffset7 = UnsafeUtility.GetFieldOffset(fields[7]);
            ref var fieldData7 = ref UnsafeUtility.AsRef<T7>(dataPtr + fieldOffset7);
            _field7.Build(ref builder, ref fieldData7);

            var fieldOffset8 = UnsafeUtility.GetFieldOffset(fields[8]);
            ref var fieldData8 = ref UnsafeUtility.AsRef<T8>(dataPtr + fieldOffset8);
            _field8.Build(ref builder, ref fieldData8);

            var fieldOffset9 = UnsafeUtility.GetFieldOffset(fields[9]);
            ref var fieldData9 = ref UnsafeUtility.AsRef<T9>(dataPtr + fieldOffset9);
            _field9.Build(ref builder, ref fieldData9);

            var fieldOffset10 = UnsafeUtility.GetFieldOffset(fields[10]);
            ref var fieldData10 = ref UnsafeUtility.AsRef<T10>(dataPtr + fieldOffset10);
            _field10.Build(ref builder, ref fieldData10);

            var fieldOffset11 = UnsafeUtility.GetFieldOffset(fields[11]);
            ref var fieldData11 = ref UnsafeUtility.AsRef<T11>(dataPtr + fieldOffset11);
            _field11.Build(ref builder, ref fieldData11);

            var fieldOffset12 = UnsafeUtility.GetFieldOffset(fields[12]);
            ref var fieldData12 = ref UnsafeUtility.AsRef<T12>(dataPtr + fieldOffset12);
            _field12.Build(ref builder, ref fieldData12);

            var fieldOffset13 = UnsafeUtility.GetFieldOffset(fields[13]);
            ref var fieldData13 = ref UnsafeUtility.AsRef<T13>(dataPtr + fieldOffset13);
            _field13.Build(ref builder, ref fieldData13);

            var fieldOffset14 = UnsafeUtility.GetFieldOffset(fields[14]);
            ref var fieldData14 = ref UnsafeUtility.AsRef<T14>(dataPtr + fieldOffset14);
            _field14.Build(ref builder, ref fieldData14);

            var fieldOffset15 = UnsafeUtility.GetFieldOffset(fields[15]);
            ref var fieldData15 = ref UnsafeUtility.AsRef<T15>(dataPtr + fieldOffset15);
            _field15.Build(ref builder, ref fieldData15);

            var fieldOffset16 = UnsafeUtility.GetFieldOffset(fields[16]);
            ref var fieldData16 = ref UnsafeUtility.AsRef<T16>(dataPtr + fieldOffset16);
            _field16.Build(ref builder, ref fieldData16);

            var fieldOffset17 = UnsafeUtility.GetFieldOffset(fields[17]);
            ref var fieldData17 = ref UnsafeUtility.AsRef<T17>(dataPtr + fieldOffset17);
            _field17.Build(ref builder, ref fieldData17);

            var fieldOffset18 = UnsafeUtility.GetFieldOffset(fields[18]);
            ref var fieldData18 = ref UnsafeUtility.AsRef<T18>(dataPtr + fieldOffset18);
            _field18.Build(ref builder, ref fieldData18);
        }
    }

    [Serializable, AnySerializePriority(AnySerializePriorityAttribute.AnyClassPriority)]
    public class ReadOnlyAnyBlobStruct<T, [AnyFieldType(nameof(T))] T0, [AnyFieldType(nameof(T))] T1, [AnyFieldType(nameof(T))] T2, [AnyFieldType(nameof(T))] T3, [AnyFieldType(nameof(T))] T4, [AnyFieldType(nameof(T))] T5, [AnyFieldType(nameof(T))] T6, [AnyFieldType(nameof(T))] T7, [AnyFieldType(nameof(T))] T8, [AnyFieldType(nameof(T))] T9, [AnyFieldType(nameof(T))] T10, [AnyFieldType(nameof(T))] T11, [AnyFieldType(nameof(T))] T12, [AnyFieldType(nameof(T))] T13, [AnyFieldType(nameof(T))] T14, [AnyFieldType(nameof(T))] T15, [AnyFieldType(nameof(T))] T16, [AnyFieldType(nameof(T))] T17, [AnyFieldType(nameof(T))] T18, [AnyFieldType(nameof(T))] T19, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny0, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny1, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny2, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny3, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny4, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny5, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny6, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny7, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny8, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny9, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny10, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny11, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny12, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny13, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny14, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny15, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny16, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny17, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny18, [AnyPropertyCodeGenOrConstraintType(nameof(T))] TAny19> : IReadOnlyAnyBlob<T>
        where T : unmanaged
        where T0 : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where T12 : unmanaged
        where T13 : unmanaged
        where T14 : unmanaged
        where T15 : unmanaged
        where T16 : unmanaged
        where T17 : unmanaged
        where T18 : unmanaged
        where T19 : unmanaged
        where TAny0 : IReadOnlyAnyBlob<T0>
        where TAny1 : IReadOnlyAnyBlob<T1>
        where TAny2 : IReadOnlyAnyBlob<T2>
        where TAny3 : IReadOnlyAnyBlob<T3>
        where TAny4 : IReadOnlyAnyBlob<T4>
        where TAny5 : IReadOnlyAnyBlob<T5>
        where TAny6 : IReadOnlyAnyBlob<T6>
        where TAny7 : IReadOnlyAnyBlob<T7>
        where TAny8 : IReadOnlyAnyBlob<T8>
        where TAny9 : IReadOnlyAnyBlob<T9>
        where TAny10 : IReadOnlyAnyBlob<T10>
        where TAny11 : IReadOnlyAnyBlob<T11>
        where TAny12 : IReadOnlyAnyBlob<T12>
        where TAny13 : IReadOnlyAnyBlob<T13>
        where TAny14 : IReadOnlyAnyBlob<T14>
        where TAny15 : IReadOnlyAnyBlob<T15>
        where TAny16 : IReadOnlyAnyBlob<T16>
        where TAny17 : IReadOnlyAnyBlob<T17>
        where TAny18 : IReadOnlyAnyBlob<T18>
        where TAny19 : IReadOnlyAnyBlob<T19>
    {
        [SerializeField] private TAny0 _field0 = default!;
        [SerializeField] private TAny1 _field1 = default!;
        [SerializeField] private TAny2 _field2 = default!;
        [SerializeField] private TAny3 _field3 = default!;
        [SerializeField] private TAny4 _field4 = default!;
        [SerializeField] private TAny5 _field5 = default!;
        [SerializeField] private TAny6 _field6 = default!;
        [SerializeField] private TAny7 _field7 = default!;
        [SerializeField] private TAny8 _field8 = default!;
        [SerializeField] private TAny9 _field9 = default!;
        [SerializeField] private TAny10 _field10 = default!;
        [SerializeField] private TAny11 _field11 = default!;
        [SerializeField] private TAny12 _field12 = default!;
        [SerializeField] private TAny13 _field13 = default!;
        [SerializeField] private TAny14 _field14 = default!;
        [SerializeField] private TAny15 _field15 = default!;
        [SerializeField] private TAny16 _field16 = default!;
        [SerializeField] private TAny17 _field17 = default!;
        [SerializeField] private TAny18 _field18 = default!;
        [SerializeField] private TAny19 _field19 = default!;

        public unsafe void Build(ref BlobBuilder builder, ref T data)
        {
            var dataPtr = (byte*)UnsafeUtility.AddressOf(ref data);
            var fields = AnyClassUtility.GetOrderedFields<T>();
            Assert.AreEqual(fields.Count, 20);

            var fieldOffset0 = UnsafeUtility.GetFieldOffset(fields[0]);
            ref var fieldData0 = ref UnsafeUtility.AsRef<T0>(dataPtr + fieldOffset0);
            _field0.Build(ref builder, ref fieldData0);

            var fieldOffset1 = UnsafeUtility.GetFieldOffset(fields[1]);
            ref var fieldData1 = ref UnsafeUtility.AsRef<T1>(dataPtr + fieldOffset1);
            _field1.Build(ref builder, ref fieldData1);

            var fieldOffset2 = UnsafeUtility.GetFieldOffset(fields[2]);
            ref var fieldData2 = ref UnsafeUtility.AsRef<T2>(dataPtr + fieldOffset2);
            _field2.Build(ref builder, ref fieldData2);

            var fieldOffset3 = UnsafeUtility.GetFieldOffset(fields[3]);
            ref var fieldData3 = ref UnsafeUtility.AsRef<T3>(dataPtr + fieldOffset3);
            _field3.Build(ref builder, ref fieldData3);

            var fieldOffset4 = UnsafeUtility.GetFieldOffset(fields[4]);
            ref var fieldData4 = ref UnsafeUtility.AsRef<T4>(dataPtr + fieldOffset4);
            _field4.Build(ref builder, ref fieldData4);

            var fieldOffset5 = UnsafeUtility.GetFieldOffset(fields[5]);
            ref var fieldData5 = ref UnsafeUtility.AsRef<T5>(dataPtr + fieldOffset5);
            _field5.Build(ref builder, ref fieldData5);

            var fieldOffset6 = UnsafeUtility.GetFieldOffset(fields[6]);
            ref var fieldData6 = ref UnsafeUtility.AsRef<T6>(dataPtr + fieldOffset6);
            _field6.Build(ref builder, ref fieldData6);

            var fieldOffset7 = UnsafeUtility.GetFieldOffset(fields[7]);
            ref var fieldData7 = ref UnsafeUtility.AsRef<T7>(dataPtr + fieldOffset7);
            _field7.Build(ref builder, ref fieldData7);

            var fieldOffset8 = UnsafeUtility.GetFieldOffset(fields[8]);
            ref var fieldData8 = ref UnsafeUtility.AsRef<T8>(dataPtr + fieldOffset8);
            _field8.Build(ref builder, ref fieldData8);

            var fieldOffset9 = UnsafeUtility.GetFieldOffset(fields[9]);
            ref var fieldData9 = ref UnsafeUtility.AsRef<T9>(dataPtr + fieldOffset9);
            _field9.Build(ref builder, ref fieldData9);

            var fieldOffset10 = UnsafeUtility.GetFieldOffset(fields[10]);
            ref var fieldData10 = ref UnsafeUtility.AsRef<T10>(dataPtr + fieldOffset10);
            _field10.Build(ref builder, ref fieldData10);

            var fieldOffset11 = UnsafeUtility.GetFieldOffset(fields[11]);
            ref var fieldData11 = ref UnsafeUtility.AsRef<T11>(dataPtr + fieldOffset11);
            _field11.Build(ref builder, ref fieldData11);

            var fieldOffset12 = UnsafeUtility.GetFieldOffset(fields[12]);
            ref var fieldData12 = ref UnsafeUtility.AsRef<T12>(dataPtr + fieldOffset12);
            _field12.Build(ref builder, ref fieldData12);

            var fieldOffset13 = UnsafeUtility.GetFieldOffset(fields[13]);
            ref var fieldData13 = ref UnsafeUtility.AsRef<T13>(dataPtr + fieldOffset13);
            _field13.Build(ref builder, ref fieldData13);

            var fieldOffset14 = UnsafeUtility.GetFieldOffset(fields[14]);
            ref var fieldData14 = ref UnsafeUtility.AsRef<T14>(dataPtr + fieldOffset14);
            _field14.Build(ref builder, ref fieldData14);

            var fieldOffset15 = UnsafeUtility.GetFieldOffset(fields[15]);
            ref var fieldData15 = ref UnsafeUtility.AsRef<T15>(dataPtr + fieldOffset15);
            _field15.Build(ref builder, ref fieldData15);

            var fieldOffset16 = UnsafeUtility.GetFieldOffset(fields[16]);
            ref var fieldData16 = ref UnsafeUtility.AsRef<T16>(dataPtr + fieldOffset16);
            _field16.Build(ref builder, ref fieldData16);

            var fieldOffset17 = UnsafeUtility.GetFieldOffset(fields[17]);
            ref var fieldData17 = ref UnsafeUtility.AsRef<T17>(dataPtr + fieldOffset17);
            _field17.Build(ref builder, ref fieldData17);

            var fieldOffset18 = UnsafeUtility.GetFieldOffset(fields[18]);
            ref var fieldData18 = ref UnsafeUtility.AsRef<T18>(dataPtr + fieldOffset18);
            _field18.Build(ref builder, ref fieldData18);

            var fieldOffset19 = UnsafeUtility.GetFieldOffset(fields[19]);
            ref var fieldData19 = ref UnsafeUtility.AsRef<T19>(dataPtr + fieldOffset19);
            _field19.Build(ref builder, ref fieldData19);
        }
    }

}
