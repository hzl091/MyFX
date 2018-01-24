using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MyFX.Core.BaseModel.Result;

namespace MyFX.WCF.Test
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        TestResult GetResult();
    }


    public class TestResult : ResultObject<CompositeType>
    {
        public int Count { get; set; }

        public double TestCount
        {
            get { return Count / 10; }
            set { }
        }
    }

    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
