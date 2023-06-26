using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmListBlazor.Shared
{
    public class FilmList
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string DurationTime { get; set; } = string.Empty;
        public string HappinessScale { get; set; } = string.Empty;
        public Watch? Watch { get; set; }
        public int WatchId { get; set; }
    }
}
