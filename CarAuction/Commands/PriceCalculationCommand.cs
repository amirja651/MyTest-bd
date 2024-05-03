namespace CarAuction.Commands;

using MediatR;

public class PriceCalculationCommand : IRequest<decimal>
{
    public decimal BasePrice { get; set; }
    public string VehicleType { get; set; }  // "Common" or "Luxury"
}

