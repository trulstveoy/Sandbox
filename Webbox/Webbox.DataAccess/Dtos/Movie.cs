using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webbox.DataAccess.Dtos
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}