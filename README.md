# -
orz233
使用的C#语言， .Net Framework 4.0
使用第三方库Spire操作Excel数据

读取Excel，把其中用户数据，读取到DataTable，然后转为List数据（List顺序未打乱）。
使用Guid生成随机数把生成的数作为Random的种子，并把所得数值约束在List.Count()内。
详细操作可以查看BLL文件夹中MoonServer中DiceRoller（）方法

对应界面操作，rbtnDiceRoller_Click()。
