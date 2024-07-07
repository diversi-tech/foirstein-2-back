using BL.BLApi;
using BLL.BllModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IBll
{
    public interface IbllTag : IblCrud<BllTag>
    {
        public Task<List<BllTag>> ReadAll(int itemId);
    }
}
