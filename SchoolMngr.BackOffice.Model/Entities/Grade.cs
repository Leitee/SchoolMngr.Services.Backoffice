using Newtonsoft.Json;
using SchoolMngr.NetStdLibrary.Base.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMngr.BackOffice.Model.Entities
{
    [Table("Grades", Schema = "School")]
    public class Grade : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }

        [Required, MaxLength(50)]
        public virtual string Name { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Class> Classes { get; set; }
    }
}
