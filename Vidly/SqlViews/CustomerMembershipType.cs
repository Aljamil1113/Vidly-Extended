namespace Vidly.SqlViews
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerMembershipType")]
    public partial class CustomerMembershipType
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool IsSubscribedToNewsLetter { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte MembershipTypeId { get; set; }

        public DateTime? BirthDate { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool IsDelinquent { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte RentLimit { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DiscountRate { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short SignUpFree { get; set; }

        [Key]
        [Column(Order = 8)]
        public byte DurationInMonths { get; set; }

        public string MembershipTypeName { get; set; }
    }
}
