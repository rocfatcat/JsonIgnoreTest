
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore3.Models
{
    [ModelMetadataType(typeof(DepartmentModelMetadataType))]
    public partial class Department
    {
        
    }

    public partial class DepartmentModelMetadataType
    {
        [JsonIgnore]
        public virtual Person Instructor { get; set; }
        [JsonIgnore]
        public virtual ICollection<Course> Course { get; set; }
    }
}