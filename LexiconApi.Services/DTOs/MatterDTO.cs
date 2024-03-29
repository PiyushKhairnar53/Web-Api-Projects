﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LexiconApi.Services.DTOs
{
    public class MatterDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public int IsActive { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }

        [Required]
        public int JurisdictionId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int BillingAttorneyId { get; set; }

        [Required]
        public int ResponsibleAttorneyId { get; set; }

    }
}
