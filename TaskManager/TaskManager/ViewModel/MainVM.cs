
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model;

namespace TaskManager.ViewModel
{
	public class MainVM
	{
		private ModelDoc _document;
		private ModelTask _task;

		public TaskVM Task { get; set; }


		public MainVM()
		{
			_document = new ModelDoc();
			Task = new TaskVM(_task, _document);
		}
	}
}
