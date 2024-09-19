﻿using Patient.Domain.Constants;

namespace Patient.Domain.Entities.Actors;

public class Patient : User
{
    public string Pesel { get; set; } = default!;
    public PatientType PatientType { get; set; }




    //
    //public IEnumerable<> CurrentlyTreatedDiseases
    //public IEnumerable<> TreatedDiseasesInThePast

    public IEnumerable<Report>? Reports { get; set; } = new List<Report>();
    public IEnumerable<Doctor>? Doctors { get; set; } = new List<Doctor>();
    public IEnumerable<MedicalFile>? MedicalFiles { get; set; } = new List<MedicalFile>();
    public IEnumerable<Prescription>? Prescriptions { get; set; } = new List<Prescription>();




}
