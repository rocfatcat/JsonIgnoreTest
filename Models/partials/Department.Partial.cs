
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AspNetCore3.Models
{
    [MetadataType(typeof(DepartmentModelMetadataType))]
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