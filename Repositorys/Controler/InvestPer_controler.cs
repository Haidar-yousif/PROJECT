﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Repositorys.Controler
{
    internal class InvestPer_controler
    {
        static public async Task<bool> Delete(int investserial, int perserial = -1)
        {
            try
            {
                using (var context = new InvEntitie())
                {
                    var target1 = context.Invpersons.FirstOrDefault(v => (v.Serial == investserial) && ((perserial == -1) ? true : v.Serpers == perserial));
                    while (target1 != null)
                    {
                        context.Invpersons.Remove(target1);
                        context.SaveChanges();
                        target1 = context.Invpersons.FirstOrDefault(v => (v.Serial == investserial) && ((perserial == -1) ? true : v.Serpers == perserial));
                    }
                    return true;
                }

            }
            catch { return false; }
            return false;
        }
    }
}
