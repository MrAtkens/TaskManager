using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Model;

namespace TaskManager.ViewModel
{
	public class TaskVM
	{
		public ModelTask Task { get; private set; }

		public ModelDoc Document { get; private set; }
		public DateTime StartDate { get; set; }

		private object lockObject = new object();

		public ICommand AddTaskCommand { get; }
		public ICommand TaskCommandStart { get; }

		public TaskVM(ModelTask task, ModelDoc doc)
		{
			doc.FilePath = string.Empty;
			doc.FileName = string.Empty;
			doc.Catalog = string.Empty;
			Task = task;
			Document = doc;
			TaskCommandStart = new RelayCommand(TaskTimer);
		}

		public void TaskTimer()
		{
			Timer timer = new Timer(TaskStart, null,0, 60000);
		}

		public void TaskStart(object task)
		{
			StartDate = DateTime.Now;
			if (StartDate == Task.ActionDate && StartDate.Hour == Task.ActionTime.Hours && StartDate.Minute == Task.ActionTime.Minutes)
			{
				if (Task.ActionType == "Email Send")
				{
					MailSend();
				}
				else if (Task.ActionType == "File Download")
				{
					Download();
				}
				else if (Task.ActionType == "File Transfer")
				{
					FileTransfer();
				}
			}
		}

		private void FileTransfer()
		{
			lock (lockObject)
			{
				DirectoryInfo dir = new DirectoryInfo(Document.Catalog);
				dir.MoveTo(Document.FilePath);
			}
		}
		private void MailSend()
		{
			lock (lockObject)
			{
				var fromAddress = new MailAddress("bikingraiyum@gmail.com");
				var toAddress = new MailAddress("bikingraiyum@gmail.com");
				const string fromPassword = "make.belive";

				var smtp = new SmtpClient
				{
					Host = "smtp.gmail.com",
					Port = 587,
					EnableSsl = true,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					UseDefaultCredentials = false,
					Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
				};
				smtp.EnableSsl = true;
				using (var message = new MailMessage(fromAddress, toAddress)
				{ Subject = Task.HeadMessage, Body = Task.BodyMessage })
				{
					smtp.Send(message);
				}
			}
		}

		private void Download()
		{
			lock (lockObject)
			{
				using (var client = new WebClient())
				{
					client.DownloadFile(Document.DonwloadFilePath, Document.FileName);
				}
			}
		}
	}
}
