using System;

public class Applications
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ServiceId { get; set; }
    public string ServiceName { get; set; } 
    public string UserName { get; set; } 
    public string Requirements { get; set; } 
    public DateTime DateSubmitted { get; set; }
    public DateTime PlannedDate { get; set; }
    public ApplicationStatus Status { get; set; }
    public string Result { get; set; }
}




