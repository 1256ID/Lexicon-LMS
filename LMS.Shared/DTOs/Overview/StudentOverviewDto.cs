using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.DTOs.Overview
{
    public record StudentOverviewDto
    {
        public List<ScheduleItemDto> UpcomingSchedule { get; init; } = new();
    }

    public record ScheduleItemDto
    {
        public int Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public DateTime Date { get; init; }
        public string Type { get; init; } = string.Empty;
    }
}
