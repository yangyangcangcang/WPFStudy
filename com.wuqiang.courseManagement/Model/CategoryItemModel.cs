using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wuqiang.courseManagement.Model
{
    public class CategoryItemModel
    {
        public bool IsSelected { get; set; }
        public string CategoryName { get; set; }

        public CategoryItemModel()
        {

        }

        public CategoryItemModel(string name,bool isSelectFlg)
        {
            this.IsSelected = isSelectFlg;
            this.CategoryName = name;
        }
    }
}
