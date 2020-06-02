using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Remember
{
    public class PrintingNotifier : IMemoDueNotifier
    {
        TextWriter _writer;
        
        // Construct the notifier with the stream onto which it will . print notifications.
        
        public PrintingNotifier(TextWriter writer)
        {
            _writer = writer;
        }

        // Print the details of an overdue memo onto the text stream. 
        public void MemoIsDue(Memo memo)
        {
            _writer.WriteLine("Memo '{0}' is due!", memo.Title);
        }
    }
}
