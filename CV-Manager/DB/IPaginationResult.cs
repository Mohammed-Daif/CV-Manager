using System.Collections.Generic;

namespace CV_Manager.DB
{
    public class PaginationResult<T>
    {
        public List<T> data { get; set; }
        public int count { get; set; }
    }
}
