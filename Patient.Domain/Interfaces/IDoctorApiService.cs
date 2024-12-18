﻿using Patient.Domain.Entities.DTOs.MedicalFiles;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;
using Patient.Domain.Entities.DTOs.Recommandation;
using Patient.Domain.Entities.DTOs.Reports;
using Shared.Dtos;

namespace Patient.Domain.Interfaces;

public interface IDoctorApiService
{
    Task<List<ReportForDoctorDto>> GetReports(CancellationToken cancellationToken);
    Task<ReportForDoctorToShowDto> GetReport(string id, CancellationToken cancellationToken);
    Task<bool> AddRecommandation(MedicalRecommandationDto dto, CancellationToken cancellationToken);
    Task<List<PrescriptionRequestToShowToDoctorDto>> GetPrescriptionRequests(CancellationToken cancellationToken);
    Task<bool> PrescribePrescription(PrescriptionRequestToShowToDoctorDto dto, CancellationToken cancellationToken);
    Task<List<PatientsDiseaseDto>> GetPatientsDiseases(string patientId, CancellationToken cancellationToken);
    Task<List<MedicalFileToShowDto>> GetPatientsMedicalDoc(string patientId, CancellationToken cancellationToken);

}
