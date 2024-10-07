﻿using Microsoft.AspNetCore.Http;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;
using Patient.Domain.Entities.DTOs.Recommandation;
using Patient.Domain.Interfaces;
using System.Net.Http.Json;

namespace Patient.Infrastructure.Services;

public class DoctorApiService : IDoctorApiService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DoctorApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;

    }
    public async Task<HttpResponseMessage> SendRequestGetReports()
    {
        AddCookiesToRequest();
        var response = await _httpClient.GetAsync("/api/ReportsController/getReportsForDoctor"); //musi dawac raporty tylko dla tego lekarza
        return response;
    }

    public async Task<HttpResponseMessage> SendRequestGetReport(string id)
    {
        AddCookiesToRequest();
        var url = $"/api/ReportsController/getReportForDoctor?Id={id}";
        var response = await _httpClient.GetAsync(url);
        return response;
    }   
    public async Task<HttpResponseMessage> SendRequestGetMedicalFiles(string userId)
    {
        AddCookiesToRequest();
        var response = await _httpClient.GetAsync("/api/MedicalDataController/getUserMedicalData");
        return response;
    }
    
    public async Task<HttpResponseMessage> SendRequestAddRecommandation(MedicalRecommandationDto dto)
    {
        AddCookiesToRequest();
        var response = await _httpClient.PostAsJsonAsync("/api/RecommandationController/createRecommandation", dto);
        return response;
    }

    public async Task<HttpResponseMessage> SendRequestGetPrescriptionRequests()
    {
        AddCookiesToRequest();
        var response = await _httpClient.GetAsync("/api/PrescriptionRequestController/getDoctorsPrescriptionRequests");
        return response;
    }

    public async Task<HttpResponseMessage> SendRequestPrescribePrescription(PrescriptionRequestToShowToDoctorDto dto)
    {
        AddCookiesToRequest();
        var response = await _httpClient.PostAsJsonAsync("/api/PrescriptionRequestController/prescribePrescriptionFromRequest", dto);
        return response;
    }

    private void AddCookiesToRequest()
    {
        var cookies = _httpContextAccessor.HttpContext.Request.Headers["Cookie"].ToString();
        _httpClient.DefaultRequestHeaders.Add("Cookie", cookies);
    }
}
