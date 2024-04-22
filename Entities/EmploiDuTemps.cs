using System;
using WebApi.Entities;

public class EmploiDuTemps
{
    public int Id { get; set; }
    public User Kiné { get; set; }
    public int KinéId { get; set; }
    public DateTime DateEmploi { get; set; }
    public TimeSpan HDébutMatinée { get; set; }
    public TimeSpan HFinMatinée { get; set; }
    public TimeSpan HDebutApMidi { get; set; }
    public TimeSpan HFinApMidi { get; set; }
    public TimeSpan HDébutSoir { get; set; }
    public TimeSpan HFinSoir { get; set; }

}