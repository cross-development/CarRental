namespace CarRental;

public class Inspection
{
    public string InspectionId { get; set; }
    public DateTime Date { get; set; }
    public Inspector Inspector { get; set; }
    public InspectionResult Result { get; set; }
    public string CarId { get; set; }
}