using CarRental.Enums;

namespace CarRental.Models;

public record Deal(
    Guid Id,
    Guid CarId,
    Guid CompanyId,
    Guid CustomerId,
    decimal Price,
    DateTime DealDate,
    DealType DealType);
