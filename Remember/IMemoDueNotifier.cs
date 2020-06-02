using System;
using System.Collections.Generic;
using System.Text;

namespace Remember
{
    public interface IMemoDueNotifier
    {
        public void MemoIsDue(Memo memo);
    }
}
