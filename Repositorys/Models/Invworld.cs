using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PROJECT.Repositorys.Models;

[PrimaryKey("Serial", "Id")]
[Table("Invworld")]
public partial class Invworld
{
    [Key]
    [Column("SERIAL")]
    public int Serial { get; set; }

    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public int Code { get; set; }
    [Column("RowVersion")]
    public byte[]? RowVersion { get; set; }
}
