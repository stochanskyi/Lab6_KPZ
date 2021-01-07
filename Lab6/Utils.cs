using Lab5.data.projects.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    static class Utils
    {

        public static int IndexOfFirst(this IList<Project> projects, Predicate<Project> predicate)
        {
            var item = projects.FirstOrDefault(project => predicate(project));

            if (item == null) return -1;

            var index = projects.IndexOf(item);

            if (index < 0) return -1;
            else return index;
        }
    }
}
