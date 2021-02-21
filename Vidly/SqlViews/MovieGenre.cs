namespace Vidly.SqlViews
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MovieGenre")]
    public partial class MovieGenre
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime ReleaseDate { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime DateAdded { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte NumberInStock { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte GenreId { get; set; }

        [Key]
        [Column(Order = 6)]
        public byte NumberAvailable { get; set; }

        [Key]
        [Column(Order = 7)]
        public decimal Amount { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(255)]
        public string GenreName { get; set; }
    }
}
