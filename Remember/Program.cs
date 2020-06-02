using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Remember
{
    class Program
    {
        static void Main(string[] args)
        {


            IQueryable<Memo> memos = new List<Memo>() {
            new Memo { Title = "Release Autofac 1.0", DueAt = new DateTime(2007, 12, 14) },
            new Memo { Title = "Write CodeProject Article", DueAt = DateTime.Now },
            new Memo { Title = "Release Autofac 2.3", DueAt = new DateTime(2010, 07, 01) }
            }.AsQueryable();


            var builder = new ContainerBuilder();
            builder.Register(c => new
              MemoChecker(c.Resolve<IQueryable<Memo>>(),
                          c.Resolve<IMemoDueNotifier>()));
            builder.Register(c => new
              PrintingNotifier(c.Resolve<TextWriter>())).As<IMemoDueNotifier>();
            builder.RegisterInstance(memos);
            builder.RegisterInstance(Console.Out).As<TextWriter>().ExternallyOwned();

            using (var container = builder.Build())
            {
                container.Resolve<MemoChecker>().CheckNow();
            }

        }

    }
}
