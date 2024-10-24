﻿using MediatR;
using Patient.Domain.Entities.DTOs.MedicalFiles;

namespace Patient.Application.MedicalData.Queries.Patient.GetMedicalFiles;

public class GetPatientsMedicalFilesQuery : IRequest<List<MedicalFileToShowDto>>
{

}
