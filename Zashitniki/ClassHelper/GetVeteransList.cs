using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zashitniki.DB;

namespace Zashitniki.ClassHelper
{
    internal class GetVeteransList
    {
        public List<Veteran> GetVeterans()
        {
            return EF.Context.Veteran
                .Include("MilitaryRank")
                .Include("AwardVeteran.Award")
                .Include("MilitaryActionMember.MilitaryAction")
                .ToList();
        }
    }
}
