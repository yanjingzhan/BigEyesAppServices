namespace BigEyesAppServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bigeyesapp.users")]
    public partial class Users
    {
        public int Id { get; set; }

        [StringLength(45)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        public string PasswordSalt { get; set; }

        [StringLength(45)]
        public string PhoneNum { get; set; }

        public int? Role { get; set; }

        [StringLength(45)]
        public string RealName { get; set; }

        public bool? IsDisable { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        [NotMapped]
        public string Ticket { get; set; }

    }
}
