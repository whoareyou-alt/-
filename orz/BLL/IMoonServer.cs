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
        void AddWinner(string strUserName, string strPrize);
        DataTable GetDTWinners();   //查看获奖名单
        Dictionary<string, int> GetPrizeCount();
        void SelectPrize(DataRow[] rows, string strUserName, int iPrizeCount = 1);      //删除行
        /*******************************/   //奖品相关
        void ImportPizesList();     //导入奖品
        List<string> GetPizesList();     //查看奖品列表
        void DeletePrize(string strPrizeName);
        /*******************************/   //其他操作
        void ExportWinnersList();   //导出获奖名单
    }
}
