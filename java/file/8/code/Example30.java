package com.itheima;

import java.text.DateFormat;
import java.text.ParseException;
import java.util.Date;

public class Example30 {
    public static void main(String[] args) throws ParseException {
        // 创建Date对象
        Date date = new Date();
        // Full格式的日期格式器对象
        DateFormat fullFormat =
                DateFormat.getDateInstance(DateFormat.FULL);
        // LONG格式的日期格式器对象
        DateFormat longFormat =
                DateFormat.getDateInstance(DateFormat.LONG);
        // MEDIUM格式的日期/时间 格式器对象
        DateFormat mediumFormat = DateFormat.getDateTimeInstance(
                DateFormat.MEDIUM, DateFormat.MEDIUM);
        // SHORT格式的日期/时间格式器对象
        DateFormat shortFormat = DateFormat.getDateTimeInstance(
                DateFormat.SHORT, DateFormat.SHORT);
        // 打印格式化后的日期或者日期/时间
        System.out.println("当前日期的完整格式为："
                + fullFormat.format(date));
        System.out.println("当前日期的长格式为："
                + longFormat.format(date));
        System.out.println("当前日期的普通格式为："
                + mediumFormat.format(date));
        System.out.println("当前日期的短格式为："
                + shortFormat.format(date));
    }
}
