using Newtonsoft.Json;
using SchoolMngr.BackOffice.Model.Entities;
using Reinforced.Typings.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolMngr.BackOffice.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Grade")]
    public sealed class GradeDto : Grade
    {
        [Required]
        public override int Id { get => base.Id; set => base.Id = value; }

        [Required, MaxLength(50), Display(Name = "Año", Order = 1)]
        public override string Name { get => base.Name; set => base.Name = value; }

        [TsIgnore]
        public new IEnumerable<ClassDto> Classes { set { } }
    }
}
