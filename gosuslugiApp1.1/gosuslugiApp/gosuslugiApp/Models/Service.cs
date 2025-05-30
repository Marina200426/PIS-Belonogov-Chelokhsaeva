using System;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Requirements { get; set; }
    public DateTime DateActivated { get; set; }
    public DateTime? DateDeactivated { get; set; }
    public int ResponsibleId { get; set; }
}