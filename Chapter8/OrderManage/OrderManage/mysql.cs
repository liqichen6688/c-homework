
using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Configuration;
using System.Data;
namespace MysqlDemo
{
    // 为了我们使用的方便我将此类设置为静态类
    static class MysqlTool
    {

        private static MySqlConnection con;
        private static MySqlCommand com;
        //1、连接数据库
        public static void ConnectMysql(string sql)
        {
            con = new MySqlConnection(sql);
            try
            {
                Console.WriteLine("连接成功");
                com = new MySqlCommand();
                com.Connection = con;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        // 操作数据库（增删改）
        public static void OperatorMysql(string sql)
        {
            com.CommandText = sql;
            if (com.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("操作成功");
            }
        }
        // 读
        public static void ReadMysql(string sql)
        {
            com.CommandText = sql;
            MySqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                if (read.HasRows)
                {
                    Console.WriteLine(read.GetString(0) + ", " + read.GetString(1));
                }
            }
        }
        //打开数据库
        public static void OpenMysql()
        {
            con.Open();
        }
        //关闭数据库
        public static void CloseMysql()
        {
            con.Close();
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 连接数据库
            MysqlTool.ConnectMysql("server=localhost;User Id=root;password=lqc199795;Database=Student");
            MysqlTool.OpenMysql();
            // 创建一个表
            MysqlTool.OperatorMysql("create table if not exists student (number int,age int)");
            // 插入一个数据
            MysqlTool.OperatorMysql("insert into student values(1,18)");
            MysqlTool.OperatorMysql("insert into student values(2,19)");
            MysqlTool.OperatorMysql("insert into student values(3,20)");
            // 读取数据
            MysqlTool.ReadMysql("select * from student");
            MysqlTool.CloseMysql();
        }
    }
}

