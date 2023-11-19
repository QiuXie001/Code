package com.itheima;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Example33 {
    public static void main(String args[]) throws ParseException {
        String strDate = "2021-03-02 17:26:11.234";     //定义日期时间的字符串
        String pat = "yyyy-MM-dd HH:mm:ss.SSS";         //定义日期时间的模板
        // 创建一个SimpleDateFormat对象
        SimpleDateFormat sdf = new SimpleDateFormat(pat);
        // 将一个包含日期/时间的字符串格式化为Date对象
        Date d = sdf.parse(strDate);
        System.out.println(d);
    }
}
