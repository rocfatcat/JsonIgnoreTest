# ASP.Net Core 3.1 Partial Class With MetadataType WebApi Example

Use `Newtonsoft.Json;`

Test `Newtonsoft.Json.JsonIgnoreAttribute` in MetadataType

## Test Enpoint Url

<http://localhost:5000/api/Department>

## Test Result

Success return data

```json
[
    {
        "departmentId": 1,
        "name": "MIS",
        "budget": 1000.0,
        "startDate": "2019-12-15T15:11:40.9639822+08:00",
        "instructorId": 1,
        "rowVersion": null
    }
]
```

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
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
```

...

```csharp
    [MetadataType(typeof(DepartmentModelMetadataType))]
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
