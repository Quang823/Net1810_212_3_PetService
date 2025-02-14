﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PetService.Data.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int CustomerId { get; set; }

    public DateTime Time { get; set; }

    public bool IsCancel { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
}