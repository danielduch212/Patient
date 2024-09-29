using Patient.Domain.Entities.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Domain.Entities.DTOs.Prescription;

public class PrescriptionDto
{
    public List<string> MedicineNames { get; set; } = new();

    //public Decimal DoseOfMedicine { get; set; }
    public string Description { get; set; } = default!;
    //public DateOnly DateOfIssue { get; set; }
    //public DateOnly DateOfExpiration { get; set; }



    // 
    public string PatientId { get; set; } = default!;


}
