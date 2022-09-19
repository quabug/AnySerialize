# AnySerialize for Unity3D

A complete serializer for Unity3D based on Unity3D serializer.

`T[][]` `Dictionary` `record` `T?` `Lazy` `Guid` `TimeSpan` `DateTime` or your own type.

## Requirement
Unity3D >= 2021.3

## Installation

## Usage
Use `AnySerializeAttribute` for any property need to be serialized and edit in inspector.
``` c#
public class MyComponent : MonoBehaviour
{
    [AnySerialize] public Dictionary<int, Lazy<Dictionary<Guid, TimeSpan>>> Value { get; }
}
```

<table>
  
<tr>
  <td align="center"><strong>Type</strong></td> <td align="center"><strong>Inspector</strong></td>
</tr>
<tr>
  <td>

```
T[]
T[][]
T[][][]
```

  </td>
  <td><img width="464" alt="image" src="https://user-images.githubusercontent.com/683655/190845247-f41d2334-a085-43a2-bd64-886d5637c931.png"></td>
</tr>

<tr>
  <td>

```
List<T>
IList<T>
IReadOnlyList<T>
```

  </td>
  <td><img width="468" alt="image" src="https://user-images.githubusercontent.com/683655/190845505-794e6fd1-e4d3-4a5e-91b3-ca003cb5f22b.png"></td>
</tr>

<tr>
  <td>

```
Dictionary<TKey, TValue>
IDictionary<TKey, TValue>
IReadOnlyDictionary<TKey, TValue>
```

  </td>
  <td><img width="484" alt="image" src="https://user-images.githubusercontent.com/683655/190845565-44e05a1b-ea41-43c6-a391-11c07f465f63.png"></td>
</tr>

<tr>
  <td>

`T?`

  </td>
  <td><img width="488" alt="image" src="https://user-images.githubusercontent.com/683655/190846367-dd4ccd39-52b9-4d40-a1fd-14d952758b52.png"></td>
</tr>

<tr>
  <td>

`Lazy<T>`

  </td>
  <td><img width="469" alt="image" src="https://user-images.githubusercontent.com/683655/190846399-a9dab39b-8dc3-415b-8a4a-0bb0fb949c95.png"></td>
</tr>

<tr>
  <td>

`Guid`

  </td>
  <td><img width="466" alt="image" src="https://user-images.githubusercontent.com/683655/190846610-2681ab46-2913-43d0-bf5c-6bf5fb0802a5.png"></td>
</tr>

<tr>
  <td>

`TimeSpan`

  </td>
  <td><img width="460" alt="image" src="https://user-images.githubusercontent.com/683655/190846623-258ea4ca-cc6d-4ff4-8ce4-4589e9db922a.png"></td>
</tr>

<tr>
  <td>

`DateTime`

  </td>
  <td><img width="464" alt="image" src="https://user-images.githubusercontent.com/683655/190846634-f1dac799-7817-48bb-ac6c-6c500afeeb69.png"></td>
</tr>

<tr>
  <td>

```
[AnySerializable]
public class AnySerializableClass
{
    [AnySerializeFieldOrder(0)] // optional, but recommend. prevent issue on reorder fields.
    public int[][] Array2;
    
    [AnySerializeFieldOrder(1)]
    public Dictionary<int, string> Dict;
    
    [AnySerializeFieldOrder(2)]
    public int? Nullable;
    
    [AnySerializeFieldOrder(3)]
    public Lazy<int> Lazy;
}
```

  </td>
  <td><img width="485" alt="image" src="https://user-images.githubusercontent.com/683655/190846815-070ac215-325d-49f2-a813-70dee839013a.png"></td>
</tr>

</table>

[More Samples](Assets/Samples)

## Custom Serializable Types
``` c#
// custom serializable value type
[Serializable]
public class AnyGuid : 
    IReadOnlyAny<Guid>, // IReadOnlyAny<T> for readonly property (get only)
    IAny<Guid>          // IAny<T> for read-write property (get and set)
{
    [SerializeField] private string _guid; // unity serialize field

    public Guid Value
    {
        get => Guid.Parse(_guid);          // convert serialize field to output value
        set => _guid = value.ToString();   // convert output value to serialize field
    }
}
```
``` c#
// custom serializable container type
[Serializable]
// use AnyConstraintTypeAttribute on generic parameter to automatically find type by its constraint
// e.g. T is int, then TAny will be replaced by AnyValue_Int32
public class ReadOnlyAnyList<T, [AnyConstraintType] TAny>
    : IReadOnlyAny<List<T>>
    where TAny : IReadOnlyAny<T>
{
    [SerializeField] private List<TAny> _value = default!;
    public List<T> Value => _value.Select(v => v.Value);
}
```
