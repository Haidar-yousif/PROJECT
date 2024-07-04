using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJECT.Repositorys.Models;
using PROJECT.Repositorys;
namespace PROJECT.Repositorys.Controler
{
    internal class Invest_controler
    {
        static public async Task<bool> Delete(int investserial)
        {
            try
            {
                using (var context = new InvEntitie())
                {
                    var target = context.Invests.Find(investserial);
                    if (target != null)
                    {
                        context.Invests.Remove(target);
                        context.SaveChanges();
                    }

                }
                return true;
            }
            catch { return false; }
            return false;
        }
    }




}
