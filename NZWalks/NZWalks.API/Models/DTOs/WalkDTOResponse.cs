namespace NZWalks.API.Models.DTOs
{
    public class WalkDTOResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

      
        //public Guid DifficultyId { get; set; }

        //public Guid RegionId { get; set; }

        public RegionDTOResponse  Region { get; set; }
        public DifficultyDTOResponse Difficulty { get; set; }
    }
}
