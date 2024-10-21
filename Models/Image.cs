using System;
using System.Collections.Generic;

namespace DLC_Project.Models;

public partial class Image
{
    public int ImageId { get; set; }

    public string ProductId { get; set; } = null!;

    public string ImageName { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
