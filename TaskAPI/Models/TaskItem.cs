using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskAPI.Models;

public  class TaskItem
{
    [Key]
    public int Tid { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Status { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? DueDate { get; set; }
}
