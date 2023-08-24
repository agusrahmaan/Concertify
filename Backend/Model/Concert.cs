﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Model
{
    public class Concert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Musisi { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Venue { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public Category Category { get; set; }
    }
}
