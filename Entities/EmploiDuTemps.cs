using System;
using WebApi.Entities;

public class EmploiDuTemps
{
    public int Id { get; set; }
    public User Kin� { get; set; }
    public int Kin�Id { get; set; }
    public DateTime DateEmploi { get; set; }
    public TimeSpan HD�butMatin�e { get; set; }
    public TimeSpan HFinMatin�e { get; set; }
    public TimeSpan HDebutApMidi { get; set; }
    public TimeSpan HFinApMidi { get; set; }
    public TimeSpan HD�butSoir { get; set; }
    public TimeSpan HFinSoir { get; set; }

}