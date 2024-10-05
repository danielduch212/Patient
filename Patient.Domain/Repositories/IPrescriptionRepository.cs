﻿using Patient.Domain.Entities;

namespace Patient.Domain.Repositories;

public interface IPrescriptionRepository
{
    public Task<int> CountPatientsPrescriptions(string patientId);
    public Task<List<Prescription>> GetPatientsPrescriptions(string patientId);

}
