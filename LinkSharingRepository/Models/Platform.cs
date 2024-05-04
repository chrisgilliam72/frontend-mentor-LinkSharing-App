﻿using System.ComponentModel.DataAnnotations;

namespace LinkSharingRepository.Models;

public class Platform
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public String Icon { get; set; } = default!;
}