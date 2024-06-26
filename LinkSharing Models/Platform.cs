﻿using System.ComponentModel.DataAnnotations;

namespace LinkSharingRepository.Models;

public class Platform
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public String Icon { get; set; } = default!;
    public String BrandingColor { get; set; } = default!;
    public String URL { get; set; } = default!;

}
