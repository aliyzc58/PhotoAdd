using Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        int IUnitOfWork.SaveChanges()
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    int commit = _context.SaveChanges();
                    tran.Commit();
                    return commit;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return 0;
                }
            }
        }
    }
}
