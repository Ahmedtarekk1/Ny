using System;
namespace Laboration2.Models
{
    public class Ägare
    {
       
        
            public int Id { get; set; }
            public string Namn { get; set; }
            public Hustyp? Hustyp { get; set; }
            public int HustypId { get; set; }
        
    }
}

