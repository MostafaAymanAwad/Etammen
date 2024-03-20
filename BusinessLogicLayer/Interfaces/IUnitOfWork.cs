﻿using DataAccessLayerEF.Models;

namespace BusinessLogicLayer.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Clinic> Clinics  { get; }
	public IDoctorRepository Doctors { get; }
	IGenericRepository<Patient> Patients { get; }
    IGenericRepository<Appointment> Appointments { get; }
    IGenericRepository<DoctorReviews> DoctorReviews { get; }
    Task<int> Commit();


}
