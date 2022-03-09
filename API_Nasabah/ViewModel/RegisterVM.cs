using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Nasabah.ViewModel
{
    public class RegisterVM
    {
        public string NIK { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string TempatLahir { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string NoHandphone { get; set; }
    }
}
