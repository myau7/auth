using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class Applicant
{
    public int Id { get; set; }

    public int SpecialityId { get; set; }

    public string? NameApplicants { get; set; }

    public string? SurnameApplicants { get; set; }

    public string? MiddleOfNameApplicants { get; set; }

    public virtual Specialty Speciality { get; set; } = null!;
}
