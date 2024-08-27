namespace ZooManagement.Models.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public virtual string Filters => "";
    }
    

    public class AnimalSearchRequest : SearchRequest
    {
        public string? Name {get; set;}
        public int? SpeciesId { get; set; }
        public int? ClassificationId { get; set; }
        public int? EnclosureId { get; set; }
        public int? Age {get; set; }
        public DateTime? DateCameToZoo {get; set; }
                public override string Filters
        {
            get
            {
                var filters = "";

                if (Name != null)
                {
                    filters += $"&name={Name}";
                }
                
                if (SpeciesId != null)
                {
                    filters += $"&speciesId={SpeciesId}";
                }
                
                if (ClassificationId != null)
                {
                    filters += $"&classificationId={ClassificationId}";
                }
                
                if (EnclosureId != null)
                {
                    filters += $"&enclosureId={EnclosureId}";
                }
                
                return filters;
            }
        }
    }
}