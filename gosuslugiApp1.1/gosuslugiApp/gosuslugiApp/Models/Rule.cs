public class Rule
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public int CharacteristicTypeId { get; set; }
    public string CharacteristicTypeName { get; set; } 
    public string Name { get; set; }
    public string Value { get; set; }
    public int Deadline { get; set; }
    public string Operator { get; set; }
}