using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace API_Nasabah.Models
{
    [Table("TB_M_NASABAH")]
    public class Nasabah
    {

        [Key]
        public string NIK { get; set; }
        [Required]
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string TempatLahir { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string NoHandphone { get; set; }
    }
}
