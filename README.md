# ASP.Net Core 3.1 Partial Class With ModelMetadataType WebApi Example

Use `System.Text.Json`

Test `System.Text.Json.Serialization.JsonIgnoreAttribute` in ModelMetadataType

## Test Enpoint Url

<http://localhost:5000/api/Department>

## Test Result

Throw Excertion Message

> System.Text.Json.JsonException: A possible object cycle was detected which is not supported. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.

### Domain Class

```csharp
    public partial class Department
    {
        public Department()
        {
            Course = new HashSet<Course>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorId { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual Person Instructor { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
```

### Partial Class

```csharp
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
```

...

```csharp
    [ModelMetadataType(typeof(DepartmentModelMetadataType))]
    public partial class Department
    {
        ...
    }

    public partial class DepartmentModelMetadataType
    {
        [JsonIgnore]
        public virtual Person Instructor { get; set; }
        [JsonIgnore]
        public virtual ICollection<Course> Course { get; set; }
    }
```
