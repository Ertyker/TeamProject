using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class Test
    {
        string TestName { get; set; }
        bool IsPass { get; set; }
        public Test(string testName, bool isPass)
        {
            TestName = testName;
            IsPass = isPass;
        }
        public Test() : this("ТРПО", false) { }
        public override string ToString()
        {
            return $"Название предмета: {TestName} Сдан ли зачет: {IsPass}";
        }
    }
}
