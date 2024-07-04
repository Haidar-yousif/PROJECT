using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Repositorys.Controler
{
    internal class WorldKey_controler
    {
        static async public Task<int> GetWorldKeyCode(string label)
        {
            int id = -1;
           
                using (var context = new InvEntitie())
                {
                    var worldkeys = context.Worldkeys.ToList();
                    foreach (var N in worldkeys)
                    {
                        if (N.Label == label)
                        {
                            id = N.Code; break;
                        }
                    }
                }
            
            return id;
        }
        static async public Task<string> GetWorldKeyLabel(int code)
        {

            string label = "";

            using (var context = new InvEntitie())
            {
                var worldkeys = context.Worldkeys.ToList();
                foreach (var N in worldkeys)
                {
                    if (N.Code == code)
                    {
                        label = N.Label; break;
                    }
                }

            }
            return label;
        }
    }
}
