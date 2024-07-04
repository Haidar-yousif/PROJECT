using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Repositorys.Controler
{
    internal class Nation_controler
    {
        static async public void PopulateNationDDL(ComboBox Nation_field)
        {
            using (var context = new InvEntitie())
            {
                var NAtions = context.Nations.ToList();
                foreach (var N in NAtions)
                {
                    Nation_field.Items.Add(N.Alabel);
                }
            }
        }
        static async public Task<int> GetNationId(ComboBox Nation_field)
        {
            int id = -1;
            if (Nation_field.Text.Length > 0)
            {
                using (var context = new InvEntitie())
                {
                    var nations = context.Nations.ToList();
                    foreach (var N in nations)
                    {
                        if (N.Alabel == Nation_field.Text)
                        {
                            id = N.Code; break;
                        }
                    }
                }
            }
            return id;
        }
        static async public Task<string> GetNationLabel(int id)
        {

            string label = "";

            using (var context = new InvEntitie())
            {
                var nations = context.Nations.ToList();
                foreach (var N in nations)
                {
                    if (N.Code == id)
                    {
                        label = N.Alabel; break;
                    }
                }

            }
            return label;
        }
    }
}
