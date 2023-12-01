using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Easy_Note.Model
{
	public class NoteModel { }
    public class Note
    {
        public Note() { }
		public Note(string title, string content) 
		{
			Title = title;
			Content = content;
		}
		private string title;

		public string Title
		{
			get { return title; }
			set 
			{ 
				if (title != value) title = value; 
			}
		}

		private string content;

		public string Content
		{
			get { return content; }
			set 
			{ 
				if(content != value) content = value; 
			}
		}
	}
}
