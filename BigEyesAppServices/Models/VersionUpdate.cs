namespace BigEyesAppServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bigeyesapp.versionupdate")]
    public partial class VersionUpdate
    {
        public int Id { get; set; }

        [StringLength(45)]
        public string Version { get; set; }

        [StringLength(500)]
        public string DownloadUrl { get; set; }

        public int? Platform { get; set; }

        public bool? IsForced { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }
    }
}
