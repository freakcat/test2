//众所周知，在MySql8.0一下版本中，忘记密码只需要关闭mysql服务之后在my.ini文件末尾加入skip-grant-tables 语句，之后重新启动mysql服务，进入Mysql重置密码就可以解决了；
//
//但是最近我也遇到了这个问题，发现MySQL8.0以上版本对于skip-grant-tables和mysqld –skip-grant-tables命令已经不支持了，经过测试，我发现了如下解决方案；
//
//首先停止MySQL服务，可以从服务中停止Mysql这个服务（有的系统是MySQL80或者MySQL57），也可以使用命令行输入“net stop mysql”结束该服务；
//打开命令行，输入“mysqld --console --skip-grant-tables --shared-memory”语句，执行，这时命令行会卡住，不要着急，打开一个新的命令行，输入“mysql -u root”便可以无密码直接进入MySQL了；
//到这里我们也成功跳过权限进入了MySQL服务器；这时，我们只要执行语句：“ALTER USER “root”@“localhost” IDENTIFIED BY “88886666”;”便可以成功修改密码了；
//注意，如果在第三步中遇到“ERROR 1290 (HY000): The MySQL server is running with the --skip-grant-tables option so it cannot execute this statement”问题，只需要执行以下语句“flush privileges”之后再执行修改密码语句便可以成功修改密码了！
//修改密码完成后，关闭所有命令行窗口，在服务面板重新启动MySQL服务或者使用语句“net start mysql”，便可以关闭跳过权限的命令，正常使用MySQL服务！

//[client]
//# 设置mysql客户端默认字符集
//default-character-set=utf8MB4
// 
//[mysqld]
//# 设置3306端口
//port = 3306
//# 设置mysql的安装目录
//basedir=C:\\web\\mysql-8.0.11
//# 设置 mysql数据库的数据的存放目录，MySQL 8+ 不需要以下配置，系统自己生成即可，否则有可能报错
//# datadir=C:\\web\\sqldata
//# 允许最大连接数
//max_connections=20
//# 服务端使用的字符集默认为8比特编码的latin1字符集
//character-set-server=utf8MB4
//# 创建新表时将使用的默认存储引擎
//default-storage-engine=INNODB
//接下来我们来启动下 MySQL 数据库：
//
//以管理员身份打开 cmd 命令行工具，切换目录：
//
//cd C:\web\mysql-8.0.11\bin
//初始化数据库：
//
//mysqld --initialize --console
//执行完成后，会输出 root 用户的初始默认密码，如：
//
//...
//2018-04-20T02:35:05.464644Z 5 [Note] [MY-010454] [Server] A temporary password is generated for root@localhost: APWCY5ws&hjQ
//...
//APWCY5ws&hjQ 就是初始密码，后续登录需要用到，你也可以在登陆后修改密码。
//
//输入以下安装命令：
//
//mysqld install
//启动输入以下命令即可：
//
//net start mysql

//APi 地址 https://dev.mysql.com/doc/connectors/en/connector-net-programming-connecting-connection-string.html
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
 
public class CtrlMySql : MonoBehaviour
{
    private const string ConnectionString = "server=127.0.0.1;uid=root;pwd=123456;database=sys";

    private MySqlConnection com;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
 
            com = new MySqlConnection();
            com.ConnectionString = ConnectionString;
            com.Open();

            MySqlCommand command = com.CreateCommand();
            command.Connection = com;
            command.CommandText = "SHOW TABLES;";
            print(com.Database);

            MySqlDataReader a = command.ExecuteReader();
            foreach (DataRow r in a.GetSchemaTable().Rows)
            {
                foreach (var VARIABLE in r.ItemArray)
                {
                    print(  VARIABLE+":" + r[1]);

                }
               
            }
          
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        
        com.Close();
    }

    // Update is called once per frame
    void Update()
    {
    }
}

public sealed class SqlConnection : System.Data.Common.DbConnection, ICloneable, IDisposable
{
    public SqlConnection(string connectionString)
    {
        
    }
    protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
    {
        throw new NotImplementedException();
    }

    public override void ChangeDatabase(string databaseName)
    {
        throw new NotImplementedException();
    }

    public override void Close()
    {
        throw new NotImplementedException();
    }

    public override void Open()
    {
        throw new NotImplementedException();
    }

    public override string ConnectionString { get; set; }
    public override string Database { get; }
    public override ConnectionState State { get; }
    public override string DataSource { get; }
    public override string ServerVersion { get; }

    protected override DbCommand CreateDbCommand()
    {
        throw new NotImplementedException();
    }

    public object Clone()
    {
        throw new NotImplementedException();
    }
}