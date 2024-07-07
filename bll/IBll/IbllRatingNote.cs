using BL.BLApi;
using BLL.BllModels;
using dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BLL.IBll
{
    public interface IbllRatingNote:IblCrud<BllRatingNote>
    {
        Task<BllRatingNote> getRatingNote(int userId, int itemId);
    }
}
