using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LModels.ViewModels
{
	public class CourseDetailCreateViewModel
	{
		public int CourseID { get; set; }
		public string DetailType { get; set; }

		// Fields for FullStack
		public string? Curriculum { get; set; }
		public string? TargetAudience { get; set; }
		public string? Benefits { get; set; }
		public string? Certification { get; set; }

		// Fields for FrontEnd
		public string? Technologies { get; set; }
		public string? LearningObjectives { get; set; }
		public string? Demand { get; set; }
		public string? Salary { get; set; }

		// Fields for BackEnd
		public string? Languages { get; set; }
		public string? Frameworks { get; set; }
		public string? Databases { get; set; }
		public string? Architecture { get; set; }

		// Fields for Game
		public string? GameEngines { get; set; }
		public string? GameDesign { get; set; }
		public string? ProgrammingLanguages { get; set; }
		public string? GameDevelopmentProcess { get; set; }

        
    }
}
