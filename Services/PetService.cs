using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contentful.AspNetCore;

namespace PetAdoption.Services
{
    public class PetService
    {
        private readonly IContentfulClient _contentfulClient;

        public PetService(IContentfulClient contentfulClient)
        {
            _contentfulClient = contentfulClient;
        }

        public async Task<List<Pet>> GetAvailablePetsAsync()
        {
            var query = QueryBuilder<Pet>.New.ContentTypeIs("pet").FieldEquals("sex", "true");

            var entries = await _contentfulClient.GetEntries<Pet>(query);

            return entries.ToList();
        }
    }

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
