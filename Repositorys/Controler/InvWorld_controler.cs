using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Repositorys.Controler
{
    internal class InvWorld_controler
    {
        static public async Task<bool> Delete(int investserial,int Code=-1)
        {
            try
            {
                using (var context = new InvEntitie())
                {
                    var target1 = context.Invworlds.FirstOrDefault(v => ((v.Serial == investserial)&&((Code==-1)?true:(v.Code==Code))));
                    while (target1 != null)
                    {
                        context.Invworlds.Remove(target1);
                        context.SaveChanges();
                        target1 = context.Invworlds.FirstOrDefault(v => ((v.Serial == investserial) && ((Code == -1) ? true : (v.Code == Code))));
                    }
                    return true;
                }
            }
            catch { return false; }
            return false;
        }
    }

}
