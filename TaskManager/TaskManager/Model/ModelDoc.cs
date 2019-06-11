using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model
{
	public class ModelDoc : ObservableObject
	{

		private string _filePath;
		public string FilePath
		{
			get { return _filePath; }
			set { OnPropertyChanged(ref _filePath, value); }
		}

		private string _fileName;
		public string FileName
		{
			get { return _fileName; }
			set { OnPropertyChanged(ref _fileName, value); }
		}

		private string _catalog;

		public string Catalog
		{
			get { return _catalog; }
			set { OnPropertyChanged(ref _catalog, value); }
		}

		private string _downloadFilePath;

		public string DonwloadFilePath
		{
			get { return _downloadFilePath; }
			set { OnPropertyChanged(ref _catalog, value); }
		}
		public bool IsEmpty
		{
			get
			{
				if (string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath))
				{
					return true;
				}
				else
				{
					return false;
				}
			}

		}
	}
}
