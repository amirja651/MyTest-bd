namespace CarAuction.Commands;

using MediatR;
using System;

public class PriceCalculationHandler : IRequestHandler<PriceCalculationCommand, decimal>
{
    public Task<decimal> Handle(PriceCalculationCommand command, CancellationToken cancellationToken)
    {
        decimal total = command.BasePrice;
        decimal basicFee = CalculateBasicFee(command.BasePrice, command.VehicleType);
        decimal specialFee = CalculateSpecialFee(command.BasePrice, command.VehicleType);
        decimal associationFee = CalculateAssociationFee(command.BasePrice);
        decimal storageFee = 100;  // Fixed fee

        total += basicFee + specialFee + associationFee + storageFee;
        return Task.FromResult(total);
    }

    private decimal CalculateBasicFee(decimal price, string type)
    {
        decimal fee = price * 0.1m;  // 10%
        if (type == "Common")
            return Math.Clamp(fee, 10, 50);
        else
            return Math.Clamp(fee, 25, 200);
    }

    private decimal CalculateSpecialFee(decimal price, string type)
    {
        return type == "Common" ? price * 0.02m : price * 0.04m;  // 2% for Common, 4% for Luxury
    }

    private decimal CalculateAssociationFee(decimal price)
    {
        if (price <= 500) return 5;
        if (price <= 1000) return 10;
        if (price <= 3000) return 15;
        return 20;
    }
}

