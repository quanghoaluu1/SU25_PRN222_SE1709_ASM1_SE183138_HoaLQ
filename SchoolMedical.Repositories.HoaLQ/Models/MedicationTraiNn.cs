﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SchoolMedical.Repositories.HoaLQ.Models;

public partial class MedicationTraiNn
{
    public int MedicationTraiNnid { get; set; }

    public int? DonguiId { get; set; }

    public string MedicineName { get; set; }

    public int? Quantity { get; set; }

    public string Unit { get; set; }

    public string Type { get; set; }

    public bool? Status { get; set; }

    public string ParentNote { get; set; }

    public string NurseNote { get; set; }

    public DateTime? ReceiveDate { get; set; }

    public virtual MedicationOrderTraiNn Dongui { get; set; }
}