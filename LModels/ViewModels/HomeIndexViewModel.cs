using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LModels.ViewModels
{
	public class HomeIndexViewModel
	{
		public IEnumerable<Course> Courses { get; set; }
		public IEnumerable<Teacher> Teachers { get; set; }
	}
}
