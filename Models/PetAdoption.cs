using System;
using System.Collections.Generic;
using Contentful.Core.Models;


namespace PetAdoption.Models
{
    public class Pet
    {
        public string Name { get; set; } 
        public int Age { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public bool Castrated { get; set; }
        public bool Adopted { get; set; }
        public string Description { get; set; }
        public List<Asset> Image { get; set; }
    }
}
