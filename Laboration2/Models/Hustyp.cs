using System;
namespace Laboration2.Models
{
    public class Hustyp
    {
        public int Id { get; set; }
        public string Hustypen { get; set; }
        public string? Bildlänk { get; set; }
        public List<Ägare>? Ägare { get; set; }
    }
}

