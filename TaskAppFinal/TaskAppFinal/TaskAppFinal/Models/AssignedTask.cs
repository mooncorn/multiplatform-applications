using System;
namespace TaskAppFinal.Models
{
	public class AssignedTask
	{
		public string Description { get; set; }
		public string AssignedToUid { get; set; }
		public string Done { get; set; }
		public string AssignedToName { get; set; }
		public string CreatedByName { get; set; }
		public string CreatedByUid { get; set; }
		public string TaskUid { get; set; }

		public AssignedTask()
		{
		}
	}
}

