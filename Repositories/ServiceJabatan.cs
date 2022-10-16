using New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace New.Repositories
{
    public class ServiceJabatan
    {
        private readonly IAllRepo<Jabatan> _repoJabatan;
        //private readonly IAllRepo<UnitKerja> _repoUnitKerja;

        public ServiceJabatan(IAllRepo<Jabatan> repoJabatan)
        {
            _repoJabatan = repoJabatan;
        }

        public IEnumerable<Jabatan> GetAll()
        {
            var rowList = _repoJabatan.Get();
            return rowList;
        }

        public Jabatan GetById(int Id)
        {
            var rowData = _repoJabatan.GetById(Id);
            return rowData;
        }
    }
}
