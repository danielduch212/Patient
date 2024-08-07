﻿using Patient.Domain.Entities.Actors;

namespace Patient.Domain.Entities;

public class Prescription
{
    public int Id { get; set; }
    public string MedicineName { get; set; } = default!;
    public Decimal DoseOfMedicine { get; set; }
    public string Description { get; set; } = default!;
    public DateOnly DateOfIssue { get; set; }
    public DateOnly DateOfExpiration { get; set; }



    //
    public string PatientId { get; set; } = default!;
    public Patient.Domain.Entities.Actors.Patient Patient { get; set; } = default!;
    public string DoctorId { get; set; } = default!;
    public Doctor Doctor { get; set; } = default!;

    private void CountDates()
    {
        DateOfIssue = DateOnly.FromDateTime(DateTime.Now);
        DateOfExpiration = DateOnly.FromDateTime((DateTime.Now).AddDays(30));
    }
}
