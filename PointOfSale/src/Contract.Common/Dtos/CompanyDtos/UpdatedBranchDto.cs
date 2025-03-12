﻿namespace POS.Contract.Dtos.CompanyDtos;

public class UpdatedBranchDto
{
    public UpdatedBranchDto()
    {
        UpdateDate = DateTime.Now;
        UpdateDate.ToString("yyyy-MM-dd hh:mm:ss.fff tt zzz");
    }

    [Required]
    public int BranchId { get; set; }
    public string? Name { get; set; }
    public IFormFile? Logo { get; set; }
    public int LogoWidth { get; set; } = 200;
    public int LogoHeight { get; set; } = 100;
    public string? Address { get; set; }
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
    public bool Active { get; set; } = true;
    public bool Suspend { get; set; } = false;
    public DateTime UpdateDate { get; set; }
}