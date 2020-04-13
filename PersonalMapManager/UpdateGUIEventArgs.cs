using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalMapManager
{
	public class UpdateGUIEventArgs : EventArgs
	{
		private string _background;
		private string _foreground;

		public UpdateGUIEventArgs(string newBackground, string newForeground)
		{
			_background = newBackground;
			_foreground = newForeground;
		}

		//Propriétés
		public string Background
		{
			get
			{
				return _background;
			}
		}
		public string Foreground
		{
			get
			{
				return _foreground;
			}
		}
	}
}
