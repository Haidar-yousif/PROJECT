using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Repositorys.Controler
{
    internal class Village_controler
    {   // Pbirth and th ResidDDL are filled by villages database
        static async public void PopulateNationDDL(ComboBox country_field)
        {
            using (var context = new InvEntitie())
            {
                var villages = context.Villages.ToList();
                foreach (var N in villages)
                {
                    country_field.Items.Add(N.Label);
                }
            }
        }
    }
}
