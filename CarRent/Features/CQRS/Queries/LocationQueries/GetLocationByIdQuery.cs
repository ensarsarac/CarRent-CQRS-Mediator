namespace CarRent.Features.CQRS.Queries.LocationQueries
{
    public class GetLocationByIdQuery
    {
        public int Id { get; set; }

        public GetLocationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
