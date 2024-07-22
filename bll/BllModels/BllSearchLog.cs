using dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BllModels
{
    public class BllSearchLog
    {
        public int LogId { get; set; }

        public int UserId { get; set; }

        public string SearchQuery { get; set; } = null!;

        public DateTime? SearchDate { get; set; }
    }
}
