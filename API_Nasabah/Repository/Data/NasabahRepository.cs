using API_Nasabah.Context;
using API_Nasabah.Models;
using API_Nasabah.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace API_Nasabah.Repository.Data
{
    public class NasabahRepository : GeneralRepository<MyContext, Nasabah, string>
    {
        private readonly MyContext myContext;
        public NasabahRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int Register(RegisterVM registerVM)
        {
            var cekNik = myContext.Nasabahs.Find(registerVM.NIK);
            var cekPhone = myContext.Nasabahs.Where(ph => ph.NoHandphone == registerVM.NoHandphone).FirstOrDefault();
            if (cekNik != null)
            {
                return 1;
            }
            if (cekPhone != null)
            {
                return 2;
            }

            Nasabah e = new Nasabah()
            {
                NIK = registerVM.NIK,
                Nama = registerVM.Nama,
                Alamat = registerVM.Alamat,
                TempatLahir = registerVM.TempatLahir,
                TanggalLahir = registerVM.TanggalLahir,
                NoHandphone = registerVM.NoHandphone
            };

            myContext.Nasabahs.Add(e);
            myContext.SaveChanges();

            
            return 0;

        }

        public IEnumerable EmployeeAllData()
        {
            var query = from e in myContext.Set<Nasabah>()

                        select new

                        {
                            e.NIK,
                            e.Nama,
                            e.Alamat,
                            e.TempatLahir,
                            e.TanggalLahir,
                            e.NoHandphone
                        };
            return query.ToList();
        }

        public IEnumerable<RegisterVM> GetProfile(string Key)
        {

            var getProfile = (from e in myContext.Nasabahs
                              where e.NIK == Key
                              select new RegisterVM
                              {
                                  NIK = e.NIK,
                                  Nama = e.Nama,
                                  Alamat = e.Alamat,
                                  TempatLahir = e.TempatLahir,
                                  TanggalLahir = e.TanggalLahir,
                                  NoHandphone = e.NoHandphone

                              });

            return getProfile.ToList();

        }
    }
}
