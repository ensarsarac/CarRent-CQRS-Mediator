using CarRent.Features.Mediator.Results.CarResults;
using MediatR;

namespace CarRent.Features.Mediator.Queries.CarQueries
{
    public class GetCarFilterQuery:IRequest<List<GetCarQueryResult>>
    {
        public int TakeCarLocation { get; set; }
        public int DropCarLocation { get; set; }
        public DateTime TakeCarDate { get; set; }
        public DateTime DropCarDate { get; set; }
        public GetCarFilterQuery(int takeCarLocation, int dropCarLocation, DateTime takeCarDate, DateTime dropCarDate)
        {
            TakeCarLocation = takeCarLocation;
            DropCarLocation = dropCarLocation;
            TakeCarDate = takeCarDate;
            DropCarDate = dropCarDate;
        }
    }
}
