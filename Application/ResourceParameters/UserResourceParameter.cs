using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResourceParameters
{
    public class UserResourceParameter
    {
        const int maxPageSize = 10;

        public int PageNumber { get; set; } = 1;

        private int pageSize = 5;

        public int PageSize {
            get => pageSize;
            set => pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

    }
}
