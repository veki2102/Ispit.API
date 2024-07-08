using System;
using System.Collections.Generic;

namespace TodoData.Models;

public partial class TodoList
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool? IsCompleted { get; set; }
}
