using System.ComponentModel.DataAnnotations;

namespace Bipow.Domain.Entities.Products.Bikes;

public sealed class FrameSizeEntity
{
    [Required]
    public int FrameId { get; set; }
    [Required]
    public string FrameSize { get; set; } = null!;
    public int? FrameSizeCentimeters { get; set; }
    public int? FrameSizeInches { get; set; }
    public int? RiderHeightSizeMin { get; set; }
    public int? RiderHeightSizeMax { get; set; }
}
