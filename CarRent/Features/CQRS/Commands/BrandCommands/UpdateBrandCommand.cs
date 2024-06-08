namespace CarRent.Features.CQRS.Commands.BrandCommands
{
    public class UpdateBrandCommand
    {
        public int BrandId { get; set; }
        public string BrandTitle { get; set; }
    }
}
