using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PROJECT.Repositorys.Models;

[Table("INVEST")]
public partial class Invest
{
    [Key]
    [Column("SERIAL")]
    public int Serial { get; set; }

    [Column("DFILE", TypeName = "date")]
    public DateTime Dfile { get; set; }

    [Column("DMAHDAR", TypeName = "date")]
    public DateTime Dmahdar { get; set; }

    [Column("CRIME")]
    [StringLength(50)]
    public string? Crime { get; set; }

    [Column("MADBOUT")]
    [StringLength(1)]
    public string? Madbout { get; set; }

    [Column("RESUME")]
    [StringLength(1)]
    public string? Resume { get; set; }

    [Column("REM", TypeName = "text")]
    public string? Rem { get; set; }
    [Column("RowVersion")]
    public byte[]? RowVersion { get; set; }
}
