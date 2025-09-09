using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.DTOs.Documents
{
    public record DocumentDto
    {
        public int Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string FileName { get; init; } = string.Empty;
        public string? ContentType { get; init; }
        public long? SizeBytes { get; init; }
        public string? Url { get; init; }
    }
}
