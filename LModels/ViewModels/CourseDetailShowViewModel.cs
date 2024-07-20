using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LModels.ViewModels
{
    public class CourseDetailShowViewModel
    {
        public Course Course { get; set; }
        public ICollection<CourseDetail> CourseDetails { get; set; }
    }
}
