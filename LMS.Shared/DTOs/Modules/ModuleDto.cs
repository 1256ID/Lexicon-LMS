using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.DTOs.Modules
{
    public record ModuleDto
    {
        public int Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }

        public int CourseId { get; init; }
    }

}
