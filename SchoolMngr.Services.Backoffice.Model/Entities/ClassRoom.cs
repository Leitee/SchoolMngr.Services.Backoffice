
namespace SchoolMngr.Services.Backoffice.Model.Entities
{
    using Codeit.Enterprise.Base.DomainModel;
    using System.Collections.Generic;

    public class ClassRoom : EFEntity
    {
        public string Description { get; set; }
        public short MaxCapacity { get; set; }
        public bool? HasNetworkConexion { get; set; }
        public bool? HasScreenProjector { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
