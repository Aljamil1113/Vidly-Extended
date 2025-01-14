﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime DateRented { get; set; }

        public Customer Customer { get; set; }
    }
}