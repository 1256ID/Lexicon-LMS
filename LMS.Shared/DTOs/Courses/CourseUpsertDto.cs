using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.DTOs.Courses;
public record CourseUpsertDto(
    string Name,
    string Description,
    DateTime StartDate,
    DateTime EndDate
);
