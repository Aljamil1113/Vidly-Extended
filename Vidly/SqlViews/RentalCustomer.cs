namespace Vidly.SqlViews
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RentalCustomer")]
    public partial class RentalCustomer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RentalId { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime DateRented { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Customer_Id { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal Price { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(255)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool IsSubscribedToNewsLetter { get; set; }

        [Key]
        [Column(Order = 7)]
        public byte MembershipTypeId { get; set; }

        public DateTime? BirthDate { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool IsDelinquent { get; set; }

        [Key]
        [Column(Order = 9)]
        public byte RentLimit { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DiscountRate { get; set; }
    }
}
