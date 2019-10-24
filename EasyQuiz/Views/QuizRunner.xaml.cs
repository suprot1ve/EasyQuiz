using EasyQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EasyQuiz.Views
{
	/// <summary>
	/// Логика взаимодействия для QuizRunner.xaml
	/// </summary>
	public partial class QuizRunner : Window
	{
		public QuizRunner(Quiz quiz)
		{
			InitializeComponent();
		}
	}
}
