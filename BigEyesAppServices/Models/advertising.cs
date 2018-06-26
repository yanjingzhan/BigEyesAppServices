namespace BigEyesAppServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bigeyesapp.advertising")]
    public partial class Advertising
    {
        public int Id { get; set; }

        public int? Position { get; set; }

        public int? Type { get; set; }

        [StringLength(1024)]
        public string SourceUrl { get; set; }

        [StringLength(1024)]
        public string DirectUrl { get; set; }

        public int? Platform { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }
    }
}
