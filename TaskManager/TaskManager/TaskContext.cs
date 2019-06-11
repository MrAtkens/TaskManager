namespace TaskManager
{
	using System;
	using System.Data.Entity;
	using System.Linq;
	using TaskManager.Model;

	public class TaskContext : DbContext
	{

		public TaskContext()
			: base("name=TaskContext")
		{
		}

		public virtual DbSet<ModelTask> TaskDb { set; get; }
	}

}