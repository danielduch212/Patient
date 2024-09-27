using Patient.Domain.Entities.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Domain.Entities.DTOs.Prescription;

public class PrescriptionDto
{
    public string MedicineName { get; set; } = default!;
    //public Decimal DoseOfMedicine { get; set; }
    public string Description { get; set; } = default!;
    public DateOnly DateOfIssue { get; set; }
    public DateOnly DateOfExpiration { get; set; }
    public bool AskForVisit { get; set; }


    //
    public string PatientId { get; set; } = default!;
    public string DoctorId { get; set; } = default!;

}
