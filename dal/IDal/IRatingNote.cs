using DAL.DalApi;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IDal
{
    public interface IRatingNote:IblCrud<RatingNote>
    {
        Task<RatingNote> GetByUserAndItem(int userId, int itemId);
    }
}
