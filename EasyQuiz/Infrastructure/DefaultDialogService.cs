using Microsoft.Win32;

namespace EasyQuiz.Infrastructure
{
	public class DefaultDialogService : IDialogService
	{
		public string FilePath { get; set; }

		public bool OpenFileDialog()
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "All json files (*.json) |*.json";
			if (dialog.ShowDialog() == true)
			{
				FilePath = dialog.FileName;
				return true;
			}
			return false;
		}

		public bool SaveFileDialog(string fileName)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.FileName = fileName;
			dialog.DefaultExt = ".json";
			dialog.AddExtension = true;
			dialog.Filter = "All json files (*.json) |*.json";
			if (dialog.ShowDialog() == true)
			{
				FilePath = dialog.FileName;
				return true;
			}
			return false;
		}
	}
}
