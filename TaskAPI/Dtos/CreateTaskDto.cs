using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskAPI.Models;

public class CreateTaskDto
{

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }
}
