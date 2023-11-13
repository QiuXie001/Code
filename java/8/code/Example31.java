package com.itheima;

import java.text.DateFormat;
import java.text.ParseException;

public class Example31 {
    public static void main(String[] args) throws ParseException {
        // 创建LONG格式的DateFormat对象
        DateFormat dt = DateFormat.getDateInstance(DateFormat.LONG);
        // 定义日期格式的字符串
        String str = "2021年05月20日";
        // 输出对应格式的字符串解析成Date对象后的结果
        System.out.println(dt.parse(str));
    }
}
