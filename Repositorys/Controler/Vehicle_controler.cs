using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Repositorys.Controler
{
    internal class Vehicle_controler
    {
        static public async Task<bool> Delete(int investserial)
        {
            try
            {
                using (var context = new InvEntitie())
                {
                    var target1 = context.Vehicles.FirstOrDefault(v => (v.SerialNb == investserial));
                    while (target1 != null)
                    {
                        context.Vehicles.Remove(target1);
                        context.SaveChanges();
                        target1 = context.Vehicles.FirstOrDefault(v => (v.SerialNb == investserial));
                    }
                    return true;
                }

            }
            catch { return false; }
            return false;
        }
    }
}
