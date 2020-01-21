using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace orzServer {
    interface IMoonServer 
    {
        /*******************************/   //主要操作
        int DiceRoller();          //抽奖冲冲冲！！！
        /*******************************/   //用户相关
        void ImportUsersList();     //导入用户列表
        List<string> GetUsersList();     //查看用户列表
        void AddWinners(string strUserName, string strDate);
        List<Msg> GetWinnersList();
    }
}
