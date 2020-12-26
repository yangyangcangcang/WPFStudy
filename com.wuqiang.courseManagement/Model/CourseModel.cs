using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wuqiang.courseManagement.Model
{
    public class CourseModel
    {
        public string CourseName { get; set; }
        public string Cover { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public List<string> Teachers { get; set; }

        /// <summary>
        /// 在获取数据缓冲时 显示
        /// </summary>
        public bool IsShowSkeleton { get; set; }
    }
}
