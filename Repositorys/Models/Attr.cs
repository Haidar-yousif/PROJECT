using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PROJECT.Repositorys.Models;

[Table("Attr")]
public partial class Attr
{
    [Key]
    public int Code { get; set; }

    [StringLength(100)]
    public string? Label { get; set; }
    [Timestamp]
    [Column("RowVersion")]
    public byte[]? RowVersion { get; set; }
}
