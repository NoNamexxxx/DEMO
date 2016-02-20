using System;
using cn.bmob.io;
/// <summary>
/// 用户账户信息
/// </summary>
public class BmobGameObject : BmobTable
{
    public BmobInt password { get; set; }

    public String userid { get; set; }


    public override void readFields(BmobInput input)
    {
        base.readFields(input);

        this.password = input.getInt("password");
        this.userid = input.getString("userid");
    }

    public override void write(BmobOutput output, Boolean all)
    {
        base.write(output, all);

        output.Put("password", this.password);
        output.Put("userid", this.userid);
    }
}
