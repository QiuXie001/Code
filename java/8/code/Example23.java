package com.itheima;

import java.util.Calendar;

public class Example23 {
    public static void main(String[] args) {
        // 获取表示当前时间的Calendar对象
        Calendar calendar = Calendar.getInstance();
        // 设置指定日期
        calendar.set(2021, 1, 1);
        // 为指定日期增加时间
        calendar.add(Calendar.DATE, 100);
        // 返回指定日期的年
        int year = calendar.get(Calendar.YEAR);
        // 返回指定日期的月
        int month = calendar.get(Calendar.MONTH) + 1;
        // 返回指定日期的日
        int date = calendar.get(Calendar.DATE);
        System.out.println("计划竣工日期为:" + year + "年"
                + month + "月" + date + "日");
    }
}
