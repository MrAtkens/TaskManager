using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model
{
	public class ModelTask : ObservableObject
	{
		private string _taskName;
		public string TaskName
		{
			get { return _taskName; }
			set { OnPropertyChanged(ref _taskName, value); }
		}

		private string _period;
		public string Period
		{
			get { return _period; }
			set { OnPropertyChanged(ref _period, value); }
		}

		private string _actionType;
		public string ActionType
		{
			get { return _actionType; }
			set { OnPropertyChanged(ref _actionType, value); }
		}

		private DateTime _actionDate;
		public DateTime ActionDate
		{
			get { return _actionDate; }
			set { OnPropertyChanged(ref _actionDate, value); }
		}

		private TimeSpan _actionTime;
		public TimeSpan ActionTime
		{
			get { return _actionTime; }
			set { OnPropertyChanged(ref _actionTime, value); }
		}

		private string _headMessage;

		public string HeadMessage
		{
			get { return _headMessage; }
			set { OnPropertyChanged(ref _headMessage, value); }
		}

		private string _bodyMessage;

		public string BodyMessage
		{
			get { return _bodyMessage; }
			set { OnPropertyChanged(ref _bodyMessage, value); }
		}
	}
}
